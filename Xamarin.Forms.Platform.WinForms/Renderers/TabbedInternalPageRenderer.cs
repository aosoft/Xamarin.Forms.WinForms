using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class TabbedInternalPageRenderer : PageRenderer<Page, WForms.TabPage>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.TabPage());
				}
				UpdateTitle();
			}
			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Page.TitleProperty.PropertyName)
				UpdateTitle();
		}

		void UpdateTitle()
		{
			UpdatePropertyHelper((element, Control) =>
			{
				Control.Text = element.Title;
			});
		}
	}
}
