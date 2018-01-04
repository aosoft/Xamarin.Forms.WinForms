using System;
using Xamarin.Forms;

namespace SkiaSharp.Views.Forms
{
	internal interface ISKCanvasViewController : IViewController
	{
		// the native listens to this event
		event EventHandler SurfaceInvalidated;
		event EventHandler<GetPropertyValueEventArgs<SKSize>> GetCanvasSize;

		// the native view tells the user to repaint
		void OnPaintSurface(SKPaintSurfaceEventArgs e);

		// the native view responds to a touch
		void OnTouch(SKTouchEventArgs e);
	}
}
