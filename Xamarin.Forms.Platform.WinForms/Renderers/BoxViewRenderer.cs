using System;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
	public class BoxViewRenderer : ViewRenderer<BoxView, System.Windows.Forms.Control>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.Control());
				}

				UpdateColor(Control);
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == BoxView.ColorProperty.PropertyName)
				UpdateColor(Control);
		}

		void UpdateColor(System.Windows.Forms.Control nativeElement)
		{
			if (nativeElement == null)
				return;

			nativeElement.ForeColor = Element?.Color.ToWindowsColor() ?? System.Drawing.SystemColors.Control;
		}
	}
}

