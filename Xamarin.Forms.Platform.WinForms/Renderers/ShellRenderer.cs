using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class ShellRenderer : PageRenderer<Shell, WFormsShell>
	{
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
			//var groups = new List<Group>();
			var flyoutGroups = ((IShellController)Element).GenerateFlyoutGrouping();

			Control.FlyoutMenu.Items.Clear();

			int index = 0;
			for (int i = 0; i < flyoutGroups.Count; i++)
			{
				var flyoutGroup = flyoutGroups[i];
				//var items = new List<Item>();
				for (int j = 0; j < flyoutGroup.Count; j++)
				{
					string title = null;
					string icon = null;
					if (flyoutGroup[j] is BaseShellItem shellItem)
					{
						title = shellItem.Title;

						if (shellItem.FlyoutIcon is FileImageSource flyoutIcon)
						{
							icon = flyoutIcon.File;
						}

						//	暫定
						var item = Control.FlyoutMenu.Items.Add(title);
						item.Font = new System.Drawing.Font("", 16);
					}
					else if (flyoutGroup[j] is MenuItem menuItem)
					{
						title = menuItem.Text;
						if (menuItem.IconImageSource is FileImageSource source)
						{
							icon = source.File;
						}
					}

					//items.Add(new Item(title, icon));

					//_flyoutMenu.Add(index, flyoutGroup[j]);
					index++;
				}

				//var group = new Group(items);
				//groups.Add(group);

			}
		}

		private void SwitchPage(ShellItem newItem)
		{
		}

		private void Shell_OnShellStructureChanged(object sender, EventArgs e)
		{
			BuildMenu();
		}

		private void ShellItem_OnClick(object sender, EventArgs e)
		{
		}
	}
}
