using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class FrameRenderer : DrawingViewRenderer<Frame, WForms.Control>
	{
		Pen _pen = null;
		VisualElement _currentView;

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				_pen?.Dispose();
				_pen = null;
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

			if (control != null && _pen != null)
			{
				e.Graphics.DrawRectangle(
					_pen,
					new System.Drawing.Rectangle(0, 0, control.Width - 1, control.Height - 1));
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
			else if (e.PropertyName == Frame.CornerRadiusProperty.PropertyName)
			{
				UpdateCornerRadius(Control);
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

			_pen?.Dispose();
			_pen = null;
			var element = Element;
			if (element != null)
			{
				_pen = new Pen(element.OutlineColor.ToWindowsColor());
			}

			nativeElement.Invalidate();
		}

		void UpdateCornerRadius(WForms.Control nativeElement)
		{
			if (nativeElement == null)
				return;

			nativeElement.Invalidate();
		}
	}
}
