using System;
using System.ComponentModel;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class SearchBarControl : WForms.UserControl
	{
		WForms.TextBox _textbox;
		WForms.Button _btnSearch;

		public SearchBarControl()
		{
			_textbox = new WForms.TextBox()
			{
				Anchor = WForms.AnchorStyles.None,
				Parent = this,
				AutoSize = false,
				Multiline = false,
				ScrollBars = WForms.ScrollBars.None
			};

			_btnSearch = new WForms.Button()
			{
				Anchor = WForms.AnchorStyles.None,
				Parent = this,
			};
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_textbox?.Dispose();
				_textbox = null;
				_btnSearch?.Dispose();
				_btnSearch = null;
			}
			base.Dispose(disposing);
		}


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			UpdateSize();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			UpdateSize();
		}

		void UpdateSize()
		{
			int bw = Math.Min(Width, Height);
			int bh = Height;

			if (_textbox != null)
			{
				_textbox.Left = 0;
				_textbox.Top = 0;
				_textbox.Width = Width - bw;
				_textbox.Height = bh;
			}

			if (_btnSearch != null)
			{
				_btnSearch.Left = Width - bw;
				_btnSearch.Top = 0;
				_btnSearch.Width = bw;
				_btnSearch.Height = bh;
			}
		}
	}
}
