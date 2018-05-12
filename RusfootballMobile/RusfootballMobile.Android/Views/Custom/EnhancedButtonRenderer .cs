using System.ComponentModel;
using RusfootballMobile.Droid.Views.Custom;
using RusfootballMobile.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EnhancedButton), typeof(EnhancedButtonRenderer))]
namespace RusfootballMobile.Droid.Views.Custom
{
    public class EnhancedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            UpdatePadding();
        }

        private void UpdatePadding()
        {
            var element = Element as EnhancedButton;
            if (element != null)
            {
                Control.SetMinHeight(-1);
                Control.SetMinimumHeight(-1);
                Control.SetMinWidth(-1);
                Control.SetMinimumWidth(-1);
                Control.SetPadding(
                    (int)element.Padding.Left,
                    (int)element.Padding.Top,
                    (int)element.Padding.Right,
                    (int)element.Padding.Bottom);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(EnhancedButton.Padding))
            {
                UpdatePadding();
            }
        }
    }
}