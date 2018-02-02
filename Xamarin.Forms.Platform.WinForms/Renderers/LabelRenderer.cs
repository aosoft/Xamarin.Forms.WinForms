using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class LabelRenderer : ViewRenderer<Label, WForms.Label>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.Label());
				}

				UpdateText(Control);
				UpdateTextColor(Control);
				UpdateAlign(Control);
				UpdateFont(Control);
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Label.TextProperty.PropertyName || e.PropertyName == Label.FormattedTextProperty.PropertyName)
			{
				UpdateText(Control);
			}
			else if (e.PropertyName == Label.TextColorProperty.PropertyName)
			{
				UpdateTextColor(Control);
			}
			else if (e.PropertyName == Label.HorizontalTextAlignmentProperty.PropertyName ||
				e.PropertyName == Label.VerticalTextAlignmentProperty.PropertyName)
			{
				UpdateAlign(Control);
			}
			else if (e.PropertyName == Label.FontSizeProperty.PropertyName ||
				e.PropertyName == Label.FontAttributesProperty.PropertyName)
			{
				UpdateFont(Control);
			}

			base.OnElementPropertyChanged(sender, e);
		}


		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateText(WForms.Label nativeElement)
		{
			if (nativeElement == null)
				return;

			Label label = Element;
			if (label != null)
			{
				nativeElement.Text = label.Text;
			}
		}

		void UpdateTextColor(WForms.Label nativeElement)
		{
			if (nativeElement == null)
				return;

			Label label = Element;
			if (label != null)
			{
				var color = label.TextColor;
				nativeElement.ForeColor =
					color == Color.Default ?
						System.Drawing.SystemColors.ControlText :
						color.ToWindowsColor();
			}
		}

		void UpdateAlign(WForms.Label nativeElement)
		{
			if (nativeElement == null)
				return;

			Label label = Element;
			if (label != null)
			{
				nativeElement.TextAlign = Platform.ToWindowsContentAlignment(
					label.HorizontalTextAlignment, label.VerticalTextAlignment);
			}
		}

		void UpdateFont(WForms.Label nativeElement)
		{
			if (nativeElement == null)
				return;

			Label label = Element;
			if (label != null)
			{
				nativeElement.Font = new System.Drawing.Font(
					label.FontFamily,
					Math.Max((float)label.FontSize, 1.0f),
					label.FontAttributes.ToWindowsFontStyle());
			}
		}

		#endregion
	}
}
