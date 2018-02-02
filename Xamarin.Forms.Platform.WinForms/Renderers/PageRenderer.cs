using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class PageRenderer : VisualElementRenderer<Page, WForms.Panel>
	{
		public PageRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WForms.Panel());
				}
			}
			base.OnElementChanged(e);
		}
	}
}
