using System;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
	public class SwitchRenderer : ViewRenderer<Switch, System.Windows.Forms.CheckBox>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.CheckBox());
					Control.CheckedChanged += OnCheckedChanged;
				}

				UpdateToggle();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Switch.IsToggledProperty.PropertyName)
			{
				UpdateToggle();
			}
			base.OnElementPropertyChanged(sender, e);
		}

		void OnCheckedChanged(object sender, EventArgs e)
		{
			((IElementController)Element).SetValueFromRenderer(Switch.IsToggledProperty, Control.Checked);
		}


		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateToggle()
		{
			if (Control != null && Element != null)
			{
				Control.Checked = Element.IsToggled;
			}
		}

		#endregion
	}
}
