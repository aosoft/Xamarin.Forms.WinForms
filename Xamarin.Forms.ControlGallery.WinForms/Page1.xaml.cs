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
			var w = (float)e.RenderTarget.Size.Width / 2;
			var h = (float)e.RenderTarget.Size.Height / 2;
			var r = w < h ? w : h;

			var angle = 3.14159 * sliderAngle.Value / 180.0;
			var len = new SKPoint((float)Math.Cos(angle) * r, (float)Math.Sin(angle) * r);

			e.Surface.Canvas.Clear(SKColors.White);
			using (var p = new SKPaint())
			using (var shader = SKShader.CreateLinearGradient(
				new SKPoint(w + len.X, h + len.Y),
				new SKPoint(w - len.X, h - len.Y),
				new[] { SKColors.Red, SKColors.Lime },
				new[] { 0.0f, 1.0f },
				SKShaderTileMode.Clamp))
			{
				p.Shader = shader;
				e.Surface.Canvas.DrawCircle(w, h, r,  p);
			}
		}

		private void sliderAngle_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			skiaView.InvalidateSurface();
		}
	}
}
