using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RusfootballMobile.Views.Custom
{
    public class EnhancedButton : Button
    {
        #region Padding    

        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(EnhancedButton), default(Thickness), BindingMode.OneWay);

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        #endregion Padding
    }
}
