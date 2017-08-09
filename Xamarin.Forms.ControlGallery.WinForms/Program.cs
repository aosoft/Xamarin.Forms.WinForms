using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xamarin.Forms.ControlGallery.WinForms
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

			var f = new Platform.WinForms.WinFormsPlatformRenderer();
			Xamarin.Forms.Platform.WinForms.Forms.Init(f);

			f.LoadApplication(new App());
			System.Windows.Forms.Application.Run(f);
		}
	}
}
