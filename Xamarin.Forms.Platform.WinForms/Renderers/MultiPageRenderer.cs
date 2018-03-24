using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class MultiPageRenderer<TElement, TContainer, TNativeElement> : PageRenderer<TElement, TNativeElement>
		where TElement : MultiPage<TContainer>
		where TNativeElement : WForms.Control
		where TContainer : Page
	{
		protected override void OnNativeElementChanged(NativeElementChangedEventArgs<TNativeElement> e)
		{
			base.OnNativeElementChanged(e);
		}
	}
}
