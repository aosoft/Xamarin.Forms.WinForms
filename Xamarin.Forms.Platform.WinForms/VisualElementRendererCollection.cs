using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.WinForms
{
	internal class VisualElementRendererCollection : IEnumerable<IVisualElementRenderer>
	{
		IVisualElementRenderer _owner = null;
		System.Windows.Forms.Control _ownerNativeElement = null;
		List<IVisualElementRenderer> _collection = new List<IVisualElementRenderer>();

		public VisualElementRendererCollection(IVisualElementRenderer owner)
		{
			_owner = owner;
			_ownerNativeElement = owner.GetNativeElement();
		}

		public IVisualElementRenderer this[int index] => _collection[index];

		public int Count => _collection.Count;

		public void Add(IVisualElementRenderer renderer)
		{
			if (_collection.IndexOf(renderer) < 0)
			{
				var nativeElement = renderer.GetNativeElement();
				if (nativeElement != null)
				{
					_ownerNativeElement.Controls.Add(nativeElement);
				}
				_collection.Add(renderer);
			}
		}

		public void RemoveAt(int index)
		{
			var item = _collection[index];
			var nativeElement = item.GetNativeElement();
			if (nativeElement != null)
			{
				_ownerNativeElement.Controls.Remove(nativeElement);
			}
			_collection.RemoveAt(index);
		}

		public void Remove(IVisualElementRenderer renderer)
		{
			var index = _collection.IndexOf(renderer);
			if (index < 0)
			{
				return;
			}
			RemoveAt(index);
		}

		public void Clear()
		{
			foreach (var item in _collection)
			{
				var nativeElement = item.GetNativeElement();
				if (nativeElement != null)
				{
					_ownerNativeElement.Controls.Remove(nativeElement);
				}
			}
			_collection.Clear();
		}

		IEnumerator<IVisualElementRenderer> IEnumerable<IVisualElementRenderer>.GetEnumerator()
			=> ((IEnumerable<IVisualElementRenderer>)_collection).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> ((IEnumerable<IVisualElementRenderer>)_collection).GetEnumerator();
	}
}
