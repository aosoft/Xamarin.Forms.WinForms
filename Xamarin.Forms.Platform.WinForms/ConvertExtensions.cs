
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
			return System.Drawing.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
		}
	}
}