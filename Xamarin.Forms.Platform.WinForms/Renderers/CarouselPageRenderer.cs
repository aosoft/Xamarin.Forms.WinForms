using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;
using Xamarin.Forms.Internals;
using System.Collections.Specialized;


namespace Xamarin.Forms.Platform.WinForms
{
	public class CarouselPageRenderer : MultiPageRenderer<CarouselPage, ContentPage, WFormsCarouselPage>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<CarouselPage> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WFormsCarouselPage());
				}

			}

			base.OnElementChanged(e);
		}

		protected override void OnNativeElementChanged(NativeElementChangedEventArgs<WFormsCarouselPage> e)
		{
			base.OnNativeElementChanged(e);
			if (e.OldControl != null)
			{
			}

			if (e.NewControl != null)
			{
			}
		}
	}
}
