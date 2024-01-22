namespace JSON_Testing.Classes
{
	/// <summary>
	/// An example class to demonstrate JSON serialization.
	/// </summary>
	public class Person
	{
		// list of people for demo purposes
		public static readonly List<Person> people = new List<Person>()
		{
			new Person("John", 30, "California"),
			new Person("Jane", 25, "Oklahoma"),
			new Person("Joe", 40, "Mississippi"),
			new Person("Jack", 35, "Wyoming"),
			new Person("Jill", 20, "Virginia"),
			new Person("Jim", 45, "Arkansas"),
			new Person("Jenny", 15, "Kansas"),
			new Person("Jared", 50, "New York"),
			new Person("Jasmine", 10, "Michigan"),
			new Person("Jesse", 55, "Hawaii"),
		};

		// constructor
		public Person(string name, int age, string city)
		{
			Name = name;
			Age = age;
			City = city;
		}

		// properties (getters)
		public string Name { get; } = "";
		public int Age { get; } = 0;
		public string City { get; } = "";

		/// <summary>
		/// Prints a list of people to the console.
		/// Each person's information is on a new line.
		/// </summary>
		public static void PrintPeople(List<Person> people)
		{
			if (people == null || people.Count == 0) return;

			for (int i = 0; i < people.Count; i++)
			{
				PrintPerson(people[i]);
			}
		}

		/// <summary>
		/// Prints a person's information to the console. 
		/// Each property is on a new line.
		/// </summary>
		public static void PrintPerson(Person person)
		{
			Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}.");
		}
	}
}