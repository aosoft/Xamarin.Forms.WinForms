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
		public WFormsShellContentCollection(IEnumerable<ShellContent> list)
		{
			this.Alignment = WForms.TabAlignment.Top;
			foreach (var item in list)
			{
				var visualElement = item.Content as VisualElement;
				if (visualElement != null)
				{
					var child = Platform.CreateRenderer(visualElement, null);
					var tabPage = new WForms.TabPage();
					tabPage.Text = item.Title;

					child.NativeElement.Location = new WDrawing.Point();
					child.NativeElement.Size = tabPage.ClientSize;
					child.NativeElement.Anchor =
						WForms.AnchorStyles.Left |
						WForms.AnchorStyles.Top |
						WForms.AnchorStyles.Right |
						WForms.AnchorStyles.Bottom;
					tabPage.Controls.Add(child.NativeElement);

					this.TabPages.Add(tabPage);
				}
			}
		}
	}
}
