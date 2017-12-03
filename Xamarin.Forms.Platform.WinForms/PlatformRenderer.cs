using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.WinForms
{
	public class PlatformRenderer : System.Windows.Forms.Form
	{
		public PlatformRenderer()
		{
			Platform = new Platform(this);
		}

		protected Platform Platform
		{
			get;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

		public void LoadApplication(Application application)
		{
			if (application == null)
				throw new ArgumentNullException("application");

			Application.SetCurrentApplication(application);
			Platform.SetPage(Application.Current.MainPage);
			application.PropertyChanged += OnApplicationPropertyChanged;

			Application.Current.SendStart();
		}

		void OnApplicationPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "MainPage")
				Platform.SetPage(Application.Current.MainPage);
		}

	}
}
