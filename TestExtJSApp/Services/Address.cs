namespace TestExtJSApp.Services
{
	// Можно реализовать другой клас, не завязаный на передаваемый в конструктор id
	public class Address : IAddress
	{
		public Address(int id)
		{
			Id = id;
		}

		public int Id { get; }
		public string Country => $"Страна{Id}";
		public string City => $"Город{Id}";
		public string House => $"Дом{Id}";
	}
}