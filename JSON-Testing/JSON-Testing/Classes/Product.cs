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
	public class Product
	{
		// constructor
		public Product(string name, int price, CategoryType category)
		{
			Name = name;
			Price = price;
			Category = category;
		}

		// properties (getters)
		public string Name { get; } = "";
		public int Price { get; } = 0;
		public CategoryType Category { get; } = CategoryType.Other;

		// enum for demo purposes
		public enum CategoryType
		{
			Food,
			Beverage,
			Other
		}
	}
}
