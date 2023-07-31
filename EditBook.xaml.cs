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
    /// Interaction logic for EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {

        private JsonRepository repository = new JsonRepository();

        public EditBook()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Edit
        {

            try
            {
                List<Library> books = repository.LoadBooks();

                if (int.Parse(editBookId.Text) > repository.GetLastBookId(books))
                    throw new IndexOutOfRangeException("There is no such id");

                foreach (var book in books)
                {
                    if (book.Id == int.Parse(editBookId.Text))
                    {
                        book.Title = newTitleTextBox.Text;
                        book.Author = newAuthorTextBox.Text;
                        book.PublicationYear = int.Parse(newPublicationYearTextbox.Text);
                    }
                }

                repository.SaveBooks(books);
                MessageBox.Show(
                   messageBoxText: "Edit Success",
                   caption: "Edit Book",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Information);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(
                    messageBoxText: ex.Message,
                    caption: "Error",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   messageBoxText: "Id Or Publication Year Uncorrect",
                   caption: "Error",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Error);

            }
        }
    }
}
