
namespace Xamarin.Forms.Platform.WinForms
{
	public class LayoutRenderer : ViewRenderer<Layout, System.Windows.Forms.Panel>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Layout> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.Panel());
				}
			}
		}

		#endregion
	}
}