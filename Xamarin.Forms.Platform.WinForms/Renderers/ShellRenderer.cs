using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class ShellRenderer : IVisualElementRenderer, IShellContext
	{
		VisualElementRendererCollection IVisualElementRenderer.Children => throw new NotImplementedException();

		VisualElement IVisualElementRenderer.Element => throw new NotImplementedException();

		Control IVisualElementRenderer.NativeElement => throw new NotImplementedException();

		Shell IShellContext.Shell => throw new NotImplementedException();

		event EventHandler<VisualElementChangedEventArgs> IVisualElementRenderer.ElementChanged
		{
			add
			{
				throw new NotImplementedException();
			}

			remove
			{
				throw new NotImplementedException();
			}
		}

		IVisualElementRenderer IVisualElementRenderer.CreateChildRenderer(VisualElement element)
		{
			throw new NotImplementedException();
		}

		void IDisposable.Dispose()
		{
			throw new NotImplementedException();
		}

		SizeRequest IVisualElementRenderer.GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			throw new NotImplementedException();
		}

		void IVisualElementRenderer.SetElement(VisualElement element)
		{
			throw new NotImplementedException();
		}
	}
}
