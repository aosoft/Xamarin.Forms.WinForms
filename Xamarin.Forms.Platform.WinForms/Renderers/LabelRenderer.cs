using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.WinForms
{
	public class LabelRenderer : ViewRenderer<Label, System.Windows.Forms.Label>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.Label());
				}

				UpdateText(Control);
				UpdateTextColor(Control);
				UpdateAlign(Control);
				UpdateFont(Control);
			}
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

		void UpdateText(System.Windows.Forms.Label nativeElement)
		{
			if (nativeElement == null)
				return;

			Label label = Element;
			if (label != null)
			{
				nativeElement.Text = label.Text;
			}
		}

		void UpdateTextColor(System.Windows.Forms.Label nativeElement)
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

		void UpdateAlign(System.Windows.Forms.Label nativeElement)
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

		void UpdateFont(System.Windows.Forms.Label nativeElement)
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
