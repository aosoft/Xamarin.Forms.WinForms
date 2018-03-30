using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;
using Xamarin.Forms.Internals;
using System.Collections.Specialized;

namespace Xamarin.Forms.Platform.WinForms
{
	public class MultiPageRenderer<TElement, TContainer, TNativeElement> : PageRenderer<TElement, TNativeElement>
		where TElement : MultiPage<TContainer>
		where TNativeElement : WForms.Control
		where TContainer : Page
	{
		protected override void OnElementChanged(ElementChangedEventArgs<TElement> e)
		{
			if (e.OldElement != null)
			{
				((INotifyCollectionChanged)e.OldElement.Children).CollectionChanged -= OnPagesChanged;
			}
			if (e.NewElement != null)
			{
				((INotifyCollectionChanged)e.NewElement.Children).CollectionChanged += OnPagesChanged;
			}
			base.OnElementChanged(e);
		}

		protected override void OnNativeElementChanged(NativeElementChangedEventArgs<TNativeElement> e)
		{
			base.OnNativeElementChanged(e);
		}

		protected virtual void OnPagesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

	}
}
