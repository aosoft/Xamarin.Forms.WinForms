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

				// Update control property 
				UpdateDate(Control);
				UpdateMinimumDate(Control);
				UpdateMaximumDate(Control);
				UpdateTextColor(Control);
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

		void UpdateDate(WForms.DateTimePicker nativeElement)
		{
			var element = Element;
			if (nativeElement != null && element != null)
			{
				nativeElement.Value = Element.Date;
			}
		}

		void UpdateMaximumDate(WForms.DateTimePicker nativeElement)
		{
			var element = Element;
			if (nativeElement != null && element != null)
			{
				nativeElement.MaxDate = Element.MaximumDate;
			}
		}

		void UpdateMinimumDate(WForms.DateTimePicker nativeElement)
		{
			var element = Element;
			if (nativeElement != null && element != null)
			{
				nativeElement.MinDate = Element.MinimumDate;
			}
		}

		void UpdateTextColor(WForms.DateTimePicker nativeElement)
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
