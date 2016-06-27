using System.Collections.Generic;
using TestExtJSApp.Services;

namespace TestExtJSApp.BL
{
	public interface IAddressIterator : IEnumerable<IAddress>
	{
		int Count { get; }

		IAddress this[int index] { get; }
	}
}