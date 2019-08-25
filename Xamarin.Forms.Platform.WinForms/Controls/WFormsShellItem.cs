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
		public WFormsShellItem(ShellItem shellItem)
		{
			ShellSections.Alignment = WForms.TabAlignment.Bottom;
			WFormsShell.SetStretchAnchor(ShellSections, this);
			foreach (var item in shellItem.Items)
			{
				var child = new WFormsShellContentCollection(item.Items);
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
		}


		public WForms.TabControl ShellSections { get; } = new WForms.TabControl();
	}
}
