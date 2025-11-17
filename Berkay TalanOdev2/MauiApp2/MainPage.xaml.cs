namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        private async void OnImageUploadClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Resminizi Seçin",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    profileImage.Source = ImageSource.FromStream(() => stream);  
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", "Resim yüklenirken bir hata oluştu.", "Tamam");
            }
        }
    }
}
