using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using WDrawing = System.Drawing;
using WForms = System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WFormsShell : WForms.UserControl
	{
		public WFormsShell()
		{
			var size = ClientSize;
			Content = new WForms.Panel()
			{
				Parent = this,
				BackColor = WDrawing.Color.AliceBlue,
				Left = 0,
				Top = 48,
				Width = size.Width,
				Height = size.Height - 48,
				Anchor =
					WForms.AnchorStyles.Left |
					WForms.AnchorStyles.Right |
					WForms.AnchorStyles.Top |
					WForms.AnchorStyles.Bottom
			};

			MenuButton = new WForms.Button()
			{
				Parent = this,
				Text = "=",
				Left = 0,
				Top = 0,
				Width = 96,
				Height = 48,
				Anchor =
					WForms.AnchorStyles.Left |
					WForms.AnchorStyles.Top
			};

			Title = new WForms.Label()
			{
				Parent = this,
				Left = 100,
				Top = 0,
				Width = size.Width - 100,
				Height = 48,
				TextAlign = WDrawing.ContentAlignment.MiddleLeft,
				Font = new WDrawing.Font("", 16),
				Anchor =
					WForms.AnchorStyles.Left |
					WForms.AnchorStyles.Right |
					WForms.AnchorStyles.Top
			};

			MenuButton.Click += MenuButton_OnClick;

			FlyoutMenu = new WForms.ContextMenuStrip();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				MenuButton?.Dispose();
				Content?.Dispose();
			}
			base.Dispose(disposing);
		}

		public WForms.Panel Content { get; }

		public WForms.Button MenuButton { get; }

		public WForms.Label Title { get; }

		public WForms.ContextMenuStrip FlyoutMenu { get; }

		private void MenuButton_OnClick(object sender, EventArgs e)
		{
			var pt = MenuButton.Location;
			var sz = MenuButton.Size;
			FlyoutMenu.Show(PointToScreen(new WDrawing.Point(pt.X, pt.Y + sz.Height)));
		}

		internal static void SetStretchAnchor(WForms.Control target, WForms.Control parent)
		{
			target.Location = new WDrawing.Point();
			target.Size = parent.ClientSize;
			target.Anchor =
				WForms.AnchorStyles.Left |
				WForms.AnchorStyles.Top |
				WForms.AnchorStyles.Right |
				WForms.AnchorStyles.Bottom;
		}
	}
}
