using System;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace MauiApp2
{
    public partial class VucutKitleIndeksi : ContentPage
    {
        public VucutKitleIndeksi()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            
            if (double.TryParse(weightEntry.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double weight) &&
                double.TryParse(heightEntry.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double height) &&
                height > 0)
            {
               
                double bmi = weight / (height * height);

                
                resultLabel.Text = $"BMI: {bmi:F2}";
                categoryLabel.Text = $"Kategori: {DetermineBMICategory(bmi)}";
            }
            else
            {
                resultLabel.Text = "Ge�erli bir kilo ve boy giriniz!";
                categoryLabel.Text = "";
            }
        }

        private string DetermineBMICategory(double bmi)
        {
            if (bmi < 16) return "�leri d�zeyde zay�f";
            else if (bmi < 17) return "Orta d�zeyde zay�f";
            else if (bmi < 18.5) return "Hafif d�zeyde zay�f";
            else if (bmi < 25) return "Normal kilolu";
            else if (bmi < 30) return "Hafif �i�man / Fazla kilolu";
            else if (bmi < 35) return "1. Derece obez";
            else if (bmi < 40) return "2. Derece obez";
            else return "3. Derece obez / Morbid obez";
        }
    }
}
