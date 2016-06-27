namespace TestExtJSApp.Services
{
	public interface IAddress
	{
		string City { get; }
		string Country { get; }
		string House { get; }
		int Id { get; }
	}
}