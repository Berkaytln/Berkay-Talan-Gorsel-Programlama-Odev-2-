using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace MauiApp2
{
    public partial class RenkSecimi : ContentPage
    {
        public RenkSecimi()
        {
            InitializeComponent();
        }

        private void OnColorSliderValueChanged(object sender, ValueChangedEventArgs e)
        {   
            int red = (int)SliderRed.Value;
            int green = (int)SliderGreen.Value;
            int blue = (int)SliderBlue.Value;

           
            Color newColor = Color.FromRgb(red, green, blue);
            ColorPreview.Color = newColor;

            
            ColorCodeLabel.Text = $"Renk Kodu: #{red:X2}{green:X2}{blue:X2}"; }


        
        private async void OnCopyColorCodeClicked(object sender, EventArgs e)
        {
          string colorCode = ColorCodeLabel.Text.Replace("Renk Kodu: ", "");
        await Clipboard.Default.SetTextAsync(colorCode);
            await DisplayAlert("Bilgi", "Renk kodu kopyaland�: " + colorCode, "Tamam");
        }
    }
}
