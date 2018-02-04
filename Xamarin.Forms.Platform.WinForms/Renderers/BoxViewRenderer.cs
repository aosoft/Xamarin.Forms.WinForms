using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class BoxViewRenderer : DrawingViewRenderer<BoxView, WForms.Control>
	{
		Brush _brush = null;

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				_brush?.Dispose();
				_brush = null;
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.Control());
				}

				UpdateColor(Control);
			}

			base.OnElementChanged(e);
		}

		protected override void OnPaint(object sender, PaintEventArgs e)
		{
			base.OnPaint(sender, e);

			var control = sender as WForms.Control;

			if (control != null && _brush != null)
			{
				e.Graphics.FillRectangle(
					_brush,
					new RectangleF(0.0f, 0.0f, control.Width, control.Height));
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == BoxView.ColorProperty.PropertyName)
				UpdateColor(Control);
		}

		void UpdateColor(WForms.Control nativeElement)
		{
			if (nativeElement == null)
				return;

			_brush?.Dispose();
			_brush = null;
			var element = Element;
			if (element != null)
			{
				_brush = new SolidBrush(element.Color.ToWindowsColor());
			}

			nativeElement.Invalidate();
		}

	}
}

