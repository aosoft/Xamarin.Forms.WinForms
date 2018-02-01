using SkiaSharp;
using System;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WinFormsTestApp
{
	public partial class Page1 : ContentPage
	{
		public Page1()
		{
			InitializeComponent();
			//openglView.OnDisplay = OpenGLView_OnDisplay;
		}

		void Button_Clicked(object sender, EventArgs e)
		{
			System.Windows.Forms.MessageBox.Show("Clicked!");
		}

		private void OpenGLView_OnDisplay(Rectangle rect)
		{
			GL.ClearColor(0.5f, 1.0f, 0.0f, 1.0f);
			GL.Clear((ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));
		}

		private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
		{
			var w = (float)e.Info.Width / 2;
			var h = (float)e.Info.Height / 2;
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
