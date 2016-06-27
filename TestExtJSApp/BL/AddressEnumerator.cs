using System.Collections;
using System.Collections.Generic;

namespace TestExtJSApp.BL
{
	public class AddressEnumerator : IEnumerator<IAddress>
	{
		private IAddressIterator _iterator;
		private int _index;

		public AddressEnumerator(IAddressIterator iterator)
		{
			_iterator = iterator;
			_index = -1;
		}

		public void Dispose()
		{
			_iterator = null;
		}

		public bool MoveNext()
		{
			return ++_index < _iterator.Count;
		}

		public void Reset()
		{
			_index = 0;
		}

		public IAddress Current => _iterator[_index];

		object IEnumerator.Current => Current;
	}
}