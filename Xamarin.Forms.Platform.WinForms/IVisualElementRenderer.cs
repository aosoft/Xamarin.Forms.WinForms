using System;
using System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public interface IVisualElementRenderer : IRegisterable, IDisposable
	{
		Control ContainerElement { get; }

		VisualElement Element { get; }

		event EventHandler<VisualElementChangedEventArgs> ElementChanged;

		SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint);

		void SetElement(VisualElement element);

		Control GetNativeElement();
	}
}