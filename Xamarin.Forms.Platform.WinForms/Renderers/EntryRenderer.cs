using System;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
	public class EntryRenderer : ViewRenderer<Entry, System.Windows.Forms.TextBox>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				base.OnElementChanged(e);

				if (e.NewElement != null)
				{
					if (Control == null)
					{
						SetNativeControl(new System.Windows.Forms.TextBox());
						Control.TextChanged += OnTextChanged;
					}

					Control.Multiline = false;

					UpdateText();
					UpdateTextColor();
					UpdateFont();
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Entry.TextProperty.PropertyName)
			{
				UpdateText();
			}
			else if (e.PropertyName == Entry.TextColorProperty.PropertyName)
			{
				UpdateTextColor();
			}
			else if (e.PropertyName == Entry.FontSizeProperty.PropertyName ||
				e.PropertyName == Entry.FontAttributesProperty.PropertyName)
			{
				UpdateFont();
			}

			base.OnElementPropertyChanged(sender, e);
		}

		void OnTextChanged(object sender, EventArgs e)
		{
			((IElementController)Element).SetValueFromRenderer(Entry.TextProperty, Control.Text);
		}

		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateText()
		{
			var nativeElement = Control;
			if (nativeElement != null)
			{
				nativeElement.Text = Element.Text;
			}
		}

		void UpdateTextColor()
		{
			var nativeElement = Control;
			if (nativeElement != null)
			{
				var color = Element.TextColor;
				nativeElement.ForeColor =
					color == Color.Default ?
						System.Drawing.SystemColors.ControlText :
						color.ToWindowsColor();
			}
		}

		void UpdateFont()
		{
			var nativeElement = Control;
			var element = Element;
			if (nativeElement != null)
			{
				nativeElement.Font = new System.Drawing.Font(
					element.FontFamily,
					(float)element.FontSize,
					element.FontAttributes.ToWindowsFontStyle());
			}
		}

		#endregion
	}
}
