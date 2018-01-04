using System;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
	public class ButtonRenderer : ViewRenderer<Button, System.Windows.Forms.Button>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.Button());
					Control.Click += OnClick;
				}

				UpdateText(Control);
				UpdateTextColor(Control);
				UpdateFont(Control);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Button.TextProperty.PropertyName)
			{
				UpdateText(Control);
			}
			else if (e.PropertyName == Button.TextColorProperty.PropertyName)
			{
				UpdateTextColor(Control);
			}
			else if (e.PropertyName == Button.FontSizeProperty.PropertyName ||
				e.PropertyName == Button.FontAttributesProperty.PropertyName)
			{
				UpdateFont(Control);
			}

			base.OnElementPropertyChanged(sender, e);
		}

		void OnClick(object sender, EventArgs e)
		{
			((IButtonController)Element)?.SendReleased();
			((IButtonController)Element)?.SendClicked();
		}


		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateText(System.Windows.Forms.Button nativeElement)
		{
			if (nativeElement == null)
				return;

			Button Button = Element;
			if (Button != null)
			{
				nativeElement.Text = Button.Text;
			}
		}

		void UpdateTextColor(System.Windows.Forms.Button nativeElement)
		{
			if (nativeElement == null)
				return;

			Button button = Element;
			if (button != null)
			{
				var color = button.TextColor;
				nativeElement.ForeColor =
					color == Color.Default ?
						System.Drawing.SystemColors.ControlText :
						color.ToWindowsColor();
			}
		}

		void UpdateFont(System.Windows.Forms.Button nativeElement)
		{
			if (nativeElement == null)
				return;

			Button button = Element;
			if (button != null)
			{
				nativeElement.Font = new System.Drawing.Font(
					button.FontFamily,
					(float)button.FontSize,
					button.FontAttributes.ToWindowsFontStyle());
			}
		}

		#endregion
	}
}
