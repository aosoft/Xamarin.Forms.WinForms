using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
	}
}
