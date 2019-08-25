using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDrawing = System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class ShellRenderer : PageRenderer<Shell, WFormsShell>
	{
		private Dictionary<ShellItem, WFormsShellItem> _nativeShellItems = new Dictionary<ShellItem, WFormsShellItem>();

		public override IVisualElementRenderer CreateChildRenderer(VisualElement element)
		{
			if (element is Page)
			{
				return new ShellInternalPageRenderer();
			}
			return base.CreateChildRenderer(element);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Shell> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new WFormsShell());
				}

				InitializeFlyout();
			}

			base.OnElementChanged(e);
		}

		protected override void OnNativeElementChanged(NativeElementChangedEventArgs<WFormsShell> e)
		{
			base.OnNativeElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Shell.CurrentItemProperty.PropertyName)
			{
			}

			base.OnElementPropertyChanged(sender, e);
		}

		private void InitializeFlyout()
		{
			((IShellController)Element).StructureChanged += Shell_OnShellStructureChanged;

			//	Initialize Flyout Header

			BuildMenu();
			SwitchPage(Element.CurrentItem);
		}

		private void BuildMenu()
		{
			_nativeShellItems.Clear();
			var flyoutGroups = ((IShellController)Element).GenerateFlyoutGrouping();

			Control.FlyoutMenu.Items.Clear();

			for (int i = 0; i < flyoutGroups.Count; i++)
			{
				var flyoutGroup = flyoutGroups[i];
				for (int j = 0; j < flyoutGroup.Count; j++)
				{
					WForms.ToolStripItem wformsMenuItem = null;
					if (flyoutGroup[j] is ShellItem shellItem)
					{
						var title = shellItem.Title;

						if (shellItem.FlyoutIcon is FileImageSource flyoutIcon)
						{
							var icon = flyoutIcon.File;
						}

						wformsMenuItem = Control.FlyoutMenu.Items.Add(title);
						wformsMenuItem.Click += (s, e) =>
						{
							SwitchPage(shellItem);
						};
					}
					else if (flyoutGroup[j] is MenuItem menuItem)
					{
						var title = menuItem.Text;
						if (menuItem.IconImageSource is FileImageSource source)
						{
							var icon = source.File;
						}

						wformsMenuItem = Control.FlyoutMenu.Items.Add(title);
						wformsMenuItem.Click += (s, e) =>
						{
						};
					}

					if (wformsMenuItem != null)
					{
						wformsMenuItem.Font = new System.Drawing.Font("", 16);
					}
				}
			}
		}

		private void SwitchPage(ShellItem newItem)
		{
			WFormsShellItem control = null;

			if (!_nativeShellItems.TryGetValue(newItem, out control))
			{
				control = new WFormsShellItem(Control, newItem);
				_nativeShellItems.Add(newItem, control);
			}

			Control.Content.Controls.Clear();
			WFormsShell.SetStretchAnchor(control, Control.Content);
			Control.Content.Controls.Add(control);

			control.OnSelected();
		}

		private void Shell_OnShellStructureChanged(object sender, EventArgs e)
		{
			BuildMenu();
		}
	}
}
