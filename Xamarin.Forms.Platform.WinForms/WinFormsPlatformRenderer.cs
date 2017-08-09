using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WinFormsPlatformRenderer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContainerControl _container;

		public WinFormsPlatformRenderer()
		{
			//_container = new System.Windows.Forms.ContainerControl();
			//this.Controls.Add(_container);
			Platform = new WinFormsPlatform(this);
		}

		protected WinFormsPlatform Platform
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
