using System;
using System.ComponentModel;
using WDrawing = System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WFormsCarouselPage : WForms.UserControl
	{
		WForms.Button _btnBack;
		WForms.Button _btnForward;
		WForms.Panel _content;

		public WFormsCarouselPage()
		{
			_btnBack = new WForms.Button()
			{
				Parent = this
			};

			_btnForward = new WForms.Button()
			{
				Parent = this
			};

			_content = new WForms.Panel()
			{
				Parent = this
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
