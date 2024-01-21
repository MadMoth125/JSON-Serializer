using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Testing.Classes
{
	/// <summary>
	/// An example class to demonstrate JSON serialization.
	/// </summary>
	public class Person
	{
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
	}
}