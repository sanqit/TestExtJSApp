using System.Collections.Generic;

namespace TestExtJSApp.Services
{
	public interface IAddressIterator : IEnumerable<IAddress>
	{
		int Count { get; }

		IAddress this[int index] { get; }
	}
}