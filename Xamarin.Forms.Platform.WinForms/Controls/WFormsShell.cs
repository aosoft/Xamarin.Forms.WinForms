﻿using System;
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

			MenuButton.Click += MenuButton_OnClick;

			FlyoutMenu = new WForms.ContextMenuStrip();
			FlyoutMenu.Items.Add("1111");
			FlyoutMenu.Items.Add("2222");
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

		public WForms.ContextMenuStrip FlyoutMenu { get; }

		private void MenuButton_OnClick(object sender, EventArgs e)
		{
			var pt = MenuButton.Location;
			var sz = MenuButton.Size;
			FlyoutMenu.Show(PointToScreen(new WDrawing.Point(pt.X, pt.Y + sz.Height)));
		}
	}
}
