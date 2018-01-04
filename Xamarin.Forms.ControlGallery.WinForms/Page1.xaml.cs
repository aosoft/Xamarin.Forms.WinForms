using SkiaSharp;
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

		void Button_Clicked(object sender, EventArgs e)
		{
			System.Windows.Forms.MessageBox.Show("Clicked!");
		}

		private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
		{
			var p = new SKPaint();
			p.Color = SKColors.Aqua;
			e.Surface.Canvas.DrawCircle(100, 100, 20, p);
		}
	}
}
