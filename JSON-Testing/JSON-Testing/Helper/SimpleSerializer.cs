using Newtonsoft.Json;

namespace JSON_Testing.Helper
{
	public class SimpleSerializer
	{
		/// <summary>
		/// Serializes an object and saves it to a file in JSON format.
		/// </summary>
		/// <typeparam name="T">The type of object to serialize (Person, Product, etc.)</typeparam>
		/// <param name="serializedObject">The object to serialize & save</param>
		/// <param name="path">The file name of the serialized to be saved (ex. filename.json)</param>
		public static void SaveAndSerialize<T>(T serializedObject, string path)
		{
			// serialize the object into a JSON string
			string json = JsonConvert.SerializeObject(serializedObject, Formatting.Indented);

			// try/catch block to handle any errors that may occur when writing IO
			try
			{
				// save the JSON string to a file
				File.WriteAllText(path, json);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error serializing object: {serializedObject}");
				Console.WriteLine(e.Message);
			}
			
		}

		/// <summary>
		/// Deserializes a JSON file and loads it into an object.
		/// </summary>
		/// <typeparam name="T">The type of object to deserialize (Person, Product, etc.)</typeparam>
		/// <param name="path">The file name of the serialized object (ex. filename.json)</param>
		/// <param name="deserializedObject">The outputted object that was de-serialized from the given JSON file.</param>
		/// <returns>If the JSON was properly de-serialized and converted to an object.</returns>
		public static bool DeserializeAndLoad<T>(string path, out T deserializedObject)
		{
			// default to true, if any errors occur, set to false
			bool success = true;

			// try/catch block to handle any errors that may occur when reading IO
			try
			{
				// check if file exists
				if (File.Exists(path))
				{
					// read contents of file
					string json = File.ReadAllText(path);

					// check if file is empty ("" or null string)
					if (!string.IsNullOrEmpty(json))
					{
						// deserialize the JSON into an object, and set the outputted object
						deserializedObject = JsonConvert.DeserializeObject<T>(json);
					}
					else
					{
						// if file is empty, set outputted object to default, and set success to false
						deserializedObject = default;
						success = false;
						Console.WriteLine($"Serialized file is empty: {path}");
					}
				}
				else
				{
					// if file doesn't exist, set outputted object to default, and set success to false
					deserializedObject = default;
					success = false;
					Console.WriteLine($"Serialized file not found: {path}");
				}
			}
			catch (IOException e)
			{
				// if any errors occur, set outputted object to default, and set success to false
				deserializedObject = default;
				success = false;
				Console.WriteLine($"Error reading contents of serialized file: {path}");
				Console.WriteLine(e.Message);
			}

			// return whether the JSON was properly de-serialized and converted to an object
			return success;
		}

		/// <summary>
		/// Clears the contents of a serialized file.
		/// Can optionally delete the file as well.
		/// </summary>
		/// <param name="path">The file name of the serialized object (ex. filename.json)</param>
		/// <param name="deleteFile">Whether to delete the file containing the serialized data (defaulted to FALSE)</param>
		public static void ClearSerializedFiles(string path, bool deleteFile = false)
		{
			// check if file exists
			if (File.Exists(path))
			{
				// check if file should be deleted or just cleared
				if (deleteFile)
				{
					// try/catch block to handle any errors that may occur when deleting IO
					try
					{
						// delete file
						File.Delete(path);
						Console.WriteLine($"Serialized file deleted: {path}");
					}
					catch (IOException e)
					{
						// if any errors occur, print error message
						Console.WriteLine($"Error deleting serialized file: {path}");
						Console.WriteLine(e.Message);
					}
				}
				else
				{
					// clear file
					File.WriteAllText(path, "");
				}
			}
		}
	}
}
