using System;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class DatePickerRenderer : ViewRenderer<DatePicker, WForms.DateTimePicker>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.DateTimePicker());
				}

				UpdateDate();
				UpdateMinimumDate();
				UpdateMaximumDate();
				UpdateTextColor();
			}

			base.OnElementChanged(e);
		}

		protected override void OnNativeElementChanged(NativeElementChangedEventArgs<WForms.DateTimePicker> e)
		{
			base.OnNativeElementChanged(e);
			if (e.OldControl != null)
			{
				e.OldControl.ValueChanged -= DateTimePicker_OnValueChanged;
			}

			if (e.NewControl != null)
			{
				e.NewControl.ValueChanged += DateTimePicker_OnValueChanged;
			}
		}

		void UpdateDate()
		{
			UpdatePropertyHelper((element, control) => control.Value = element.Date);
		}

		void UpdateMaximumDate()
		{
			UpdatePropertyHelper((element, control) => control.MaxDate = element.MaximumDate);
		}

		void UpdateMinimumDate()
		{
			UpdatePropertyHelper((element, control) => control.MinDate = element.MinimumDate);
		}

		void UpdateTextColor()
		{
			UpdatePropertyHelper((element, control) => control.ForeColor = element.TextColor.ToWindowsColor());
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
