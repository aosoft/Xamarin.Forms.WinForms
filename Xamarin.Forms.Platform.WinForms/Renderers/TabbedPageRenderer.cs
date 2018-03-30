using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;
using Xamarin.Forms.Internals;
using System.Collections.Specialized;

namespace Xamarin.Forms.Platform.WinForms
{
	public class TabbedPageRenderer : MultiPageRenderer<TabbedPage, Page, WForms.TabControl>
	{
		WForms.TabControlEventHandler _onNativeSelected = null;

		public TabbedPageRenderer()
		{
			var h = Platform.BlockReenter<WForms.TabControlEventArgs>((s, e) => OnNativeSelected(s, e));
			_onNativeSelected = (s, e) => h(s, e);
		}

		protected override void OnNativeElementChanged(NativeElementChangedEventArgs<WForms.TabControl> e)
		{
			base.OnNativeElementChanged(e);
			if (e.OldControl != null)
			{
				e.OldControl.Selected -= _onNativeSelected;
			}

			if (e.NewControl != null)
			{
				e.NewControl.Selected += _onNativeSelected;
			}
		}


		protected override void OnPagesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			base.OnPagesChanged(sender, e);

			e.Apply(AddTab, RemoveTab, ResetTab);
		}

		void AddTab(object o, int index, bool create)
		{
			UpdatePropertyHelper((element, control) =>
			{
				TabbedInternalPageRenderer tabitem = null;
				if (create)
				{
					tabitem = new TabbedInternalPageRenderer();
				}

				Children.Insert(index, tabitem);
			});

		}

		void RemoveTab(object o, int index)
		{
		}

		void ResetTab()
		{
			Children.Clear();
		}

		void OnNativeSelected(object sender, WForms.TabControlEventArgs e)
		{
			UpdatePropertyHelper((element, control) =>
			{
				element.CurrentPage = Children.Find(e.TabPage)?.Element as Page;
			});
		}
	}
}
