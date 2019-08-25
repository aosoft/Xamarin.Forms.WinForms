using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using WDrawing = System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WFormsShellContentCollection : WForms.TabControl
	{
		public WFormsShellContentCollection(WFormsShell owner, IEnumerable<ShellContent> list)
		{
			this.Alignment = WForms.TabAlignment.Top;
			Selected += TabControl_OnSelected;
			foreach (var item in list)
			{
				var visualElement = item.Content as VisualElement;
				if (visualElement != null)
				{
					var tabPage = new WFormsShellContent(owner, item);
					this.TabPages.Add(tabPage);
				}
			}
			OnSelected();
		}

		internal void OnSelected()
		{
			var tab = SelectedTab ?? (TabPages.Count > 0 ? TabPages[0] : null);

			(tab as WFormsShellContent)?.OnSelected();
		}

		private void TabControl_OnSelected(object sender, WForms.TabControlEventArgs e)
		{
			OnSelected();
		}
	}
}
