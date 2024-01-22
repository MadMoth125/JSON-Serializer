using CustomConsole;
using GenericParse;
using JSON_Testing.Helper;
using JSON_Testing.Classes;

namespace JSON_Testing
{
	internal class Program
	{
		// Serialized files land in bin/Debug/net6.0/
		// too lazy to make it generate custom paths...
		private const string _personJsonPath = "SerializedPerson.json";

		private static string[] _menu1 = new string[] { "Serialize list of people", "Load serialized list of people", "Clear serialized data of people"};
		private static string[] _menu2 = new string[] { "Exit program" };

		private static bool _loopMain = true;

		static void Main(string[] args)
		{
			while (_loopMain)
			{
				PrintMenu();
				SelectMenuOption();
			}

			ConsoleHelper.HaltProgram();
		}

		/// <summary>
		/// Displays all menu options in the console.
		/// </summary>
		private static void PrintMenu()
		{
			Console.WriteLine("JSON Serializer demo.");
			ConsoleHelper.PrintBlank();
			ConsoleHelper.PrintStrings(_menu1, _menu2);
		}

		/// <summary>
		/// Waits for user input and calls SwitchOnMenuSelection(), passing the user's input as a parameter.
		/// </summary>
		private static void SelectMenuOption()
		{
			// looping until a valid option is selected
			while (true)
			{
				ConsoleHelper.PrintBlank();
				Console.WriteLine("Select Option: ");
				int tempSelect = GenericReadLine.TryReadLine<int>();

				if (!SwitchOnMenuSelection(tempSelect)) break;
			}
		}

		/// <summary>
		/// Uses a switch statement to call the appropriate method based on the user's menu selection.
		/// </summary>
		/// <param name="selection">The user's menu selection</param>
		/// <returns>The desired loop state</returns>
		private static bool SwitchOnMenuSelection(int selection)
		{
			bool tempReturnValue = true;

			// clearing console and printing menu again to prevent clutter
			Console.Clear();
			PrintMenu();
			ConsoleHelper.PrintBlank();

			switch (selection)
			{
				case 1: // serialize list of people
					SimpleSerializer.SaveAndSerialize<List<Person>>(Person.people, _personJsonPath);
					Console.WriteLine("Serialized a preset list of people.");

					break;

				case 2: // load serialized list of people
					if (SimpleSerializer.DeserializeAndLoad<List<Person>>(_personJsonPath, out List<Person> people))
					{
						Console.WriteLine("Loaded serialized list of people.");
						Person.PrintPeople(people);
					}

					break;

				case 3: // clear serialized data of people
					SimpleSerializer.ClearSerializedFiles(_personJsonPath);
					Console.WriteLine("Cleared serialized data of people.");

					break;

				case 4: // exit
					tempReturnValue = false;
					_loopMain = false;

					break;

				default:
					break;
			}

			return tempReturnValue;
		}
	}
}