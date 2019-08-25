using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using WDrawing = System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WFormsShellContent : WForms.TabPage
	{
		private WFormsShell _owner;
		private ShellContent _content;
		private IVisualElementRenderer _renderer;

		public WFormsShellContent(WFormsShell owner, ShellContent content)
		{
			_owner = owner;
			_content = content;
			_renderer = null;
			var visualElement = content.Content as VisualElement;
			if (visualElement != null)
			{
				_renderer = Platform.CreateRenderer(visualElement, null);
				Text = content.Title;
				WFormsShell.SetStretchAnchor(_renderer.NativeElement, this);
				Controls.Add(_renderer.NativeElement);

				_renderer.Element.Layout(new Rectangle(0, 0, Width, Height));
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			_renderer?.Element?.Layout(new Rectangle(0, 0, Width, Height));
		}

		internal void OnSelected()
		{
			if (_content.Content is ContentPage contentPage)
			{
				_owner.Title.Text = contentPage.Title;
			}
			else
			{
				_owner.Title.Text = null;
			}
		}
	}
}
