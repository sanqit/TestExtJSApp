using System.Collections;
using System.Collections.Generic;

namespace TestExtJSApp.BL
{
	// Можно организовать в этом классе хранение или создание экземпляров реализации IAddress
	public class AddressIterator : IAddressIterator
	{

		public AddressIterator(int count)
		{
			Count = count;
		}

		public int Count { get; }

		// можно реализовать здесь сеттер, и складывать экземпляры IAddress в какое нибудь хранилище
		public IAddress this[int index] => new Address(index + 1);

		public IEnumerator<IAddress> GetEnumerator()
		{
			return new AddressEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}