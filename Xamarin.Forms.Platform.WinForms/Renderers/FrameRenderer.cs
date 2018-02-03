using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class FrameRenderer : DrawingViewRenderer<Frame, WForms.Control>
	{
		Brush _brush = null;
		VisualElement _currentView;

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				_brush?.Dispose();
				_brush = null;
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.Control());
				}

				UpdateOutlineColor(Control);
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

			if (e.PropertyName == Frame.ContentProperty.PropertyName)
			{
				UpdateContent(Control);
			}
			else if (e.PropertyName == Frame.OutlineColorProperty.PropertyName ||
				e.PropertyName == Frame.HasShadowProperty.PropertyName)
			{
				UpdateOutlineColor(Control);
			}
		}

		void UpdateContent(WForms.Control nativeElement)
		{
			if (nativeElement == null)
				return;

			if (_currentView != null)
			{
				_currentView.Cleanup(); // cleanup old view
			}

			_currentView = Element.Content;
			if (_currentView != null)
			{
				var r = _currentView.GetOrCreateRenderer();
				if (r != null)
				{
					r.NativeElement.Parent = nativeElement;
				}
			}
		}

		void UpdateOutlineColor(WForms.Control nativeElement)
		{
			if (nativeElement == null)
				return;

			_brush?.Dispose();
			_brush = null;
			var element = Element;
			if (element != null)
			{
				_brush = new SolidBrush(element.OutlineColor.ToWindowsColor());
			}
		}
	}
}
