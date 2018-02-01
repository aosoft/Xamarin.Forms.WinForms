using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.WinForms
{
	public class DatePickerRenderer : ViewRenderer<Button, System.Windows.Forms.DateTimePicker>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.DateTimePicker());
				}

			}

			base.OnElementChanged(e);
		}
	}
}
