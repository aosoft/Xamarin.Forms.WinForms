using System;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
    public class StepperRenderer : ViewRenderer<Stepper, System.Windows.Forms.NumericUpDown>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(new System.Windows.Forms.NumericUpDown());
                }

                UpdateMinimum();
                UpdateMaximum();
                UpdateValue();
                UpdateIncrement();

                Control.ValueChanged += OnValueChanged;
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Stepper.ValueProperty.PropertyName)
                UpdateValue();
            else if (e.PropertyName == Stepper.MinimumProperty.PropertyName)
                UpdateMinimum();
            else if (e.PropertyName == Stepper.MaximumProperty.PropertyName)
                UpdateMaximum();
            else if (e.PropertyName == Stepper.IncrementProperty.PropertyName)
                UpdateIncrement();

            base.OnElementPropertyChanged(sender, e);
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            ((IElementController)Element).SetValueFromRenderer(Stepper.ValueProperty, Control.Value);
        }

        private void UpdateValue()
        {
            var value = (decimal)Element.Value;

            if (Control.Value != value)
                Control.Value = value;
        }

        private void UpdateMinimum()
        {
            var minimum = (decimal)Element.Minimum;

            Control.Minimum = minimum;
        }

        private void UpdateMaximum()
        {
            var maximum = (decimal)Element.Maximum;

            Control.Maximum = maximum;
        }

        private void UpdateIncrement()
        {
            var increment = (decimal)Element.Increment;

            Control.Increment = increment;
        }
    }
}