using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace MauiApp2
{
    public partial class Yapilacaklar : ContentPage
    {
        
        private ObservableCollection<string> notes;



        
        private readonly string notesFilePath = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        public Yapilacaklar()
        {
            InitializeComponent();
            notes = new ObservableCollection<string>();
            NotesCollectionView.ItemsSource = notes;

            
            LoadNotes();
        }


        
        private void OnAddNoteClicked(object sender, EventArgs e)
        {
            string newNote = NoteEntry.Text;
            if (!string.IsNullOrWhiteSpace(newNote))
            {
                notes.Add(newNote); 
                NoteEntry.Text = string.Empty; 
                SaveNotes(); 
            }
            else
            {
                DisplayAlert("Hata", "Lütfen bir not girin.", "Tamam");
            }
        }


       
        private async void SaveNotes()
        {
            var notesData = string.Join("\n", notes);
            await File.WriteAllTextAsync(notesFilePath, notesData);
        }






       
        private async void LoadNotes()
        {
            if (File.Exists(notesFilePath))
            {
                var notesData = await File.ReadAllTextAsync(notesFilePath);
                var loadedNotes = notesData.Split('\n');
                foreach (var note in loadedNotes)
                { if (!string.IsNullOrWhiteSpace(note))
                  {notes.Add(note); }
                }
            }
        }
       
        private void OnDeleteNoteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var noteToDelete = button?.CommandParameter as string;
            if (!string.IsNullOrEmpty(noteToDelete))
            {  notes.Remove(noteToDelete); 
               SaveNotes(); 
            }
        }
    }
}
