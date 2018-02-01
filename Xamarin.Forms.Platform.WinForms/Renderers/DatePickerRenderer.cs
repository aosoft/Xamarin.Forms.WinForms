using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.WinForms
{
	public class DatePickerRenderer : ViewRenderer<DatePicker, System.Windows.Forms.DateTimePicker>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.DateTimePicker());
					Control.ValueChanged += DateTimePicker_OnValueChanged;
				}

				// Update control property 
				UpdateDate(Control);
				UpdateMinimumDate(Control);
				UpdateMaximumDate(Control);
				UpdateTextColor(Control);
			}

			base.OnElementChanged(e);
		}

		void UpdateDate(System.Windows.Forms.DateTimePicker nativeElement)
		{
			var element = Element;
			if (nativeElement != null && element != null)
			{
				nativeElement.Value = Element.Date;
			}
		}

		void UpdateMaximumDate(System.Windows.Forms.DateTimePicker nativeElement)
		{
			var element = Element;
			if (nativeElement != null && element != null)
			{
				nativeElement.MaxDate = Element.MaximumDate;
			}
		}

		void UpdateMinimumDate(System.Windows.Forms.DateTimePicker nativeElement)
		{
			var element = Element;
			if (nativeElement != null && element != null)
			{
				nativeElement.MinDate = Element.MinimumDate;
			}
		}

		void UpdateTextColor(System.Windows.Forms.DateTimePicker nativeElement)
		{
			var element = Element;
			if (nativeElement != null && element != null)
			{
				var color = element.TextColor;
				nativeElement.ForeColor =
					color == Color.Default ?
						System.Drawing.SystemColors.ControlText :
						color.ToWindowsColor();
			}
		}

		void DateTimePicker_OnValueChanged(object sender, EventArgs e)
		{
			var nativeElement = Control;
			if (nativeElement != null)
			{
				((IElementController)Element).SetValueFromRenderer(DatePicker.DateProperty, nativeElement.Value);
			}
		}
	}
}
