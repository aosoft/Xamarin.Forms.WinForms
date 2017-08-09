using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.ControlGallery.WinForms
{
	public partial class Page1 : ContentPage
	{
		public Page1()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			Extensions.LoadFromXaml<Page1>(this, typeof(Page1));
		}
	}
}
