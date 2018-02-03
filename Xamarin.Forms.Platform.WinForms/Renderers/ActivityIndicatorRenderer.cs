using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class ActivityIndicatorRenderer : ViewRenderer<ActivityIndicator, WForms.ProgressBar>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.ProgressBar());
				}

				UpdateIsIndeterminate(Control);
				UpdateColor(Control);
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == ActivityIndicator.IsRunningProperty.PropertyName)
				UpdateIsIndeterminate(Control);
			else if (e.PropertyName == ActivityIndicator.ColorProperty.PropertyName)
				UpdateColor(Control);
		}

		void UpdateColor(WForms.ProgressBar nativeElement)
		{
			if (nativeElement == null)
				return;

			nativeElement.ForeColor = Element?.Color.ToWindowsColor() ?? System.Drawing.SystemColors.Control;
		}

		void UpdateIsIndeterminate(WForms.ProgressBar nativeElement)
		{
			if (nativeElement == null)
				return;

			if (Element?.IsRunning ?? false)
			{
				nativeElement.Style = WForms.ProgressBarStyle.Marquee;
			}
			else
			{
				nativeElement.Style = WForms.ProgressBarStyle.Continuous;
				nativeElement.Value = 0;
			}
		}
	}
}
