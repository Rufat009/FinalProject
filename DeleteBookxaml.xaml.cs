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
    /// Interaction logic for DeleteBookxaml.xaml
    /// </summary>
    public partial class DeleteBookxaml : Window
    {

        private JsonRepository repository = new JsonRepository();

        public DeleteBookxaml()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Delete
        {
            try
            {
                List<Library> books = repository.LoadBooks();
                if (int.Parse(deleteBookId.Text) > repository.GetLastBookId(books))
                    throw new IndexOutOfRangeException("There is no such id");
                books.RemoveAt(int.Parse(deleteBookId.Text) - 1);
                repository.SaveBooks(books);

                MessageBox.Show(
                   messageBoxText: "Book Deleted",
                   caption: "Delete Book",
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
                   messageBoxText: "Id data type uncorrect",
                   caption: "Error",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Error);
            }
        }
    }
}
