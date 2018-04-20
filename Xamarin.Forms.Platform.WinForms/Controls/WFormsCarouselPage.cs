using System;
using System.ComponentModel;
using WDrawing = System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WFormsCarouselPage : WForms.UserControl, INativeElement
	{
		WForms.Button _btnBack;
		WForms.Button _btnForward;
		WForms.Panel _content;

		public WFormsCarouselPage()
		{
			var size = ClientSize;
			int fw = (Font?.Height).GetValueOrDefault(1) * 2 + 4;

			_content = new WForms.Panel()
			{
				Parent = this,
				Left = fw,
				Top = 0,
				Width = size.Width - fw * 2,
				Height = size.Height,
				Anchor =
					WForms.AnchorStyles.Left |
					WForms.AnchorStyles.Right |
					WForms.AnchorStyles.Top |
					WForms.AnchorStyles.Bottom
			};

			_btnBack = new WForms.Button()
			{
				Parent = this,
				Left = 0,
				Top = 0,
				Width = fw,
				Height = size.Height,
				Text = "<",
				Anchor =
					WForms.AnchorStyles.Left |
					WForms.AnchorStyles.Top |
					WForms.AnchorStyles.Bottom
			};

			_btnForward = new WForms.Button()
			{
				Parent = this,
				Left = size.Width - fw,
				Top = 0,
				Width = fw,
				Height = size.Height,
				Text = ">",
				Anchor =
					WForms.AnchorStyles.Right |
					WForms.AnchorStyles.Top |
					WForms.AnchorStyles.Bottom
			};
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_btnBack?.Dispose();
				_btnBack = null;
				_btnForward?.Dispose();
				_btnForward = null;
				_content?.Dispose();
				_content = null;
			}
			base.Dispose(disposing);
		}


		public WForms.Control ParentForChildren => _content;

		public ControlCollection Children => _content?.Controls;

		public WForms.Panel Content => _content;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			UpdateLayout();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			UpdateLayout();
		}

		void UpdateLayout()
		{
		}
	}
}
