using System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	internal sealed class DefaultRenderer : ViewRenderer<View, Control>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.Control());
				}
			}
		}
	}
}