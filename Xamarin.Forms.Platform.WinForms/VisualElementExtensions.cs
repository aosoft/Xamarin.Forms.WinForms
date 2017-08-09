using System;
using System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public static class VisualElementExtensions
	{
		public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement self)
		{
			if (self == null)
				throw new ArgumentNullException("self");

			IVisualElementRenderer renderer = WinFormsPlatform.GetRenderer(self);
			if (renderer == null)
			{
				renderer = WinFormsPlatform.CreateRenderer(self);
				WinFormsPlatform.SetRenderer(self, renderer);
			}

			return renderer;
		}

		internal static void Cleanup(this VisualElement self)
		{
			if (self == null)
				throw new ArgumentNullException("self");

			IVisualElementRenderer renderer = WinFormsPlatform.GetRenderer(self);

			foreach (Element element in self.Descendants())
			{
				var visual = element as VisualElement;
				if (visual == null)
					continue;

				IVisualElementRenderer childRenderer = WinFormsPlatform.GetRenderer(visual);
				if (childRenderer != null)
				{
					childRenderer.Dispose();
					WinFormsPlatform.SetRenderer(visual, null);
				}
			}

			if (renderer != null)
			{
				renderer.Dispose();
				WinFormsPlatform.SetRenderer(self, null);
			}
		}
	}
}