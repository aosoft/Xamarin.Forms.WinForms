
namespace Xamarin.Forms.Platform.WinForms
{
	internal static class ConvertExtensions
	{
		/*
		public static Brush ToBrush(this Color color)
		{
			return new SolidColorBrush(color.ToWindowsColor());
		}
		*/

		public static System.Drawing.Color ToWindowsColor(this Color color)
		{
			return 
				color == Color.Default ?
					System.Drawing.SystemColors.Control :
					System.Drawing.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
		}

		public static System.Drawing.FontStyle ToWindowsFontStyle(this FontAttributes self)
		{
			switch (self)
			{
				case FontAttributes.Bold:
					{
						return System.Drawing.FontStyle.Bold;
					}

				case FontAttributes.Italic:
					{
						return System.Drawing.FontStyle.Italic;
					}
			}
			return System.Drawing.FontStyle.Regular;
		}

		public static Rectangle ToXamarinRectangle(this System.Drawing.Rectangle self)
		{
			return new Rectangle(self.Left, self.Top, self.Width, self.Height);
		}
	}
}