using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using WDrawing = System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WFormsShellItem : WForms.UserControl
	{
		public WFormsShellItem(WFormsShell owner, ShellItem shellItem)
		{
			ShellSections.Alignment = WForms.TabAlignment.Bottom;
			WFormsShell.SetStretchAnchor(ShellSections, this);
			ShellSections.Selected += TabControl_OnSelected;

			foreach (var item in shellItem.Items)
			{
				var child = new WFormsShellContentCollection(owner, item.Items);
				var tabPage = new WForms.TabPage();
				if (item is Tab tab)
				{
					tabPage.Text = tab.Title;
				}
				WFormsShell.SetStretchAnchor(child, tabPage);
				tabPage.Controls.Add(child);

				ShellSections.TabPages.Add(tabPage);
			}

			Controls.Add(ShellSections);

			OnSelected();
		}


		public WForms.TabControl ShellSections { get; } = new WForms.TabControl();

		internal void OnSelected()
		{
			var tab = ShellSections.SelectedTab ?? (ShellSections.TabPages.Count > 0 ? ShellSections.TabPages[0] : null);

			(tab?.Controls?[0] as WFormsShellContentCollection)?.OnSelected();
		}

		private void TabControl_OnSelected(object sender, WForms.TabControlEventArgs e)
		{
			OnSelected();
		}
	}
}
