using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class ScrollViewRenderer : ViewRenderer<ScrollView, WForms.Panel>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ScrollView> e)
		{
			if (e.OldElement != null)
			{
				e.OldElement.ScrollToRequested -= OnScrollToRequested;
			}

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.Panel());
				}
				e.NewElement.ScrollToRequested += OnScrollToRequested;
				UpdateOrientation();
				UpdateScrollXPosition();
				UpdateScrollYPosition();
				UpdateContentSize();
				UpdateMargins();
			}

			base.OnElementChanged(e);
		}

		protected override void OnNativeElementChanged(NativeElementChangedEventArgs<WForms.Panel> e)
		{
			base.OnNativeElementChanged(e);
			if (e.OldControl != null)
			{
			}

			if (e.NewControl != null)
			{
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == ScrollView.ContentSizeProperty.PropertyName)
				UpdateContentSize();
			else if (e.PropertyName == ScrollView.OrientationProperty.PropertyName)
				UpdateOrientation();
			else if (e.PropertyName == ScrollView.ScrollXProperty.PropertyName)
				UpdateScrollXPosition();
			else if (e.PropertyName == ScrollView.ScrollYProperty.PropertyName)
				UpdateScrollYPosition();
		}

		void OnScrollToRequested(object sender, ScrollToRequestedEventArgs e)
		{
			UpdatePropertyHelper((element, control) =>
			{
				//if (_animatable == null && e.ShouldAnimate)
				//	_animatable = new Animatable();

				var position = e.Position;
				int x = (int)e.ScrollX;
				int y = (int)e.ScrollY;

				if (e.Mode == ScrollToMode.Element)
				{
					var itemPosition = element.GetScrollPositionForElement(e.Element as VisualElement, e.Position);
					x = (int)itemPosition.X;
					y = (int)itemPosition.Y;
				}

				if (control.VerticalScroll.Value == y && control.HorizontalScroll.Value == x)
					return;

				/*if (e.ShouldAnimate)
				{
					var animation = new Animation(v => { UpdateScrollOffset(GetDistance(Control.ViewportWidth, x, v), GetDistance(Control.ViewportHeight, y, v)); });

					animation.Commit(_animatable, "ScrollTo", length: 500, easing: Easing.CubicInOut, finished: (v, d) =>
					{
						UpdateScrollOffset(x, y);
						element.SendScrollFinished();
					});
				}
				else*/
				{
					UpdateScrollOffset(x, y);
					element.SendScrollFinished();
				}
			});
		}

		void UpdateContentSize()
		{
			UpdatePropertyHelper((element, control) =>
			{
				var size = element.ContentSize;
				control.HorizontalScroll.Minimum = 0;
				control.HorizontalScroll.Maximum = Math.Max(1, ((int)size.Width) - 1);
				control.VerticalScroll.Minimum = 0;
				control.VerticalScroll.Maximum = Math.Max(1, ((int)size.Height) - 1);
			});
		}

		void UpdateOrientation()
		{
			UpdatePropertyHelper((element, control) =>
			{
				switch (element.Orientation)
				{
					case ScrollOrientation.Vertical:
						{
							control.HorizontalScroll.Visible = false;
							control.VerticalScroll.Visible = true;
						}
						break;

					case ScrollOrientation.Horizontal:
						{
							control.HorizontalScroll.Visible = true;
							control.VerticalScroll.Visible = false;
						}
						break;

					case ScrollOrientation.Both:
						{
							control.HorizontalScroll.Visible = true;
							control.VerticalScroll.Visible = true;
						}
						break;
				}
			});
		}

		void UpdateScrollXPosition()
		{
			UpdatePropertyHelper((element, control) =>
			{
				control.HorizontalScroll.Value = (int)element.ScrollX;
			});
		}

		void UpdateScrollYPosition()
		{
			UpdatePropertyHelper((element, control) =>
			{
				control.VerticalScroll.Value = (int)element.ScrollY;
			});
		}

		void UpdateScrollOffset(double x, double y)
		{
			UpdatePropertyHelper((element, control) =>
			{
				if (element.Orientation == ScrollOrientation.Horizontal)
					control.HorizontalScroll.Value = (int)x;
				else
					control.VerticalScroll.Value = (int)y;
			});
		}
	}
}
