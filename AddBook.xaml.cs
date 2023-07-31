using LibProject.Models;
using LibProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibProject
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private JsonRepository repository = new JsonRepository();
        public AddBook()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Add
        {
            try
            {
                List<Library> books = repository.LoadBooks();

                Library newBook = new Library
                {
                    Id = repository.GetLastBookId(books) + 1,
                    Title = TitleTextBox.Text,
                    Author = AuthorTextBox.Text,
                    PublicationYear = int.Parse(PublicationYearTextBox.Text),
                };
                books.Add(newBook);
                MessageBox.Show(
                   messageBoxText: "Book added",
                   caption: "Book added",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Information);

                repository.SaveBooks(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   messageBoxText: ex.Message,
                   caption: "Publication Year Uncorrect",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Error);
            }
        }
    }
}
