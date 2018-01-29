using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTestApp
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			OpenTK.Toolkit.Init();

			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

			var f = new Xamarin.Forms.Platform.WinForms.PlatformRenderer();
			Xamarin.Forms.Platform.WinForms.Forms.Init(f);

			f.Width = 800;
			f.Height = 600;
			f.LoadApplication(new App());
			System.Windows.Forms.Application.Run(f);
		}
	}
}
