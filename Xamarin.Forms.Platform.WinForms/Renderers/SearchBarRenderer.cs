using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class SearchBarRenderer : ViewRenderer<SearchBar, SearchBarControl>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new SearchBarControl());
					//Control.Click += OnClick;
				}

				//UpdateText();
				//UpdateTextColor();
				//UpdateFont();
			}

			base.OnElementChanged(e);
		}
	}
}
