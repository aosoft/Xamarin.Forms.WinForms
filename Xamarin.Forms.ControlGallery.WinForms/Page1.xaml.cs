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

		private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintGLSurfaceEventArgs e)
		{
			e.Surface.Canvas.Clear(SKColors.White);
			using (var p = new SKPaint())
			using (var shader = SKShader.CreateLinearGradient(
				new SKPoint(0.0f, 0.0f),
				new SKPoint(100.0f, 100.0f),
				new [] { SKColors.Red, SKColors.Green },
				null,
				SKShaderTileMode.Clamp))
			{
				p.Shader = shader;
				e.Surface.Canvas.DrawRect(new SKRect(0.0f, 0.0f, 100.0f, 100.0f), p);
			}
		}
	}
}
