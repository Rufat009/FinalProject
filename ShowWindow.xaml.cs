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
    /// Interaction logic for ShowWindow.xaml
    /// </summary>
    public partial class ShowWindow : Window
    {
        
        private JsonRepository repository = new JsonRepository();
        private List<Library> list = new List<Library>();
        private List<Library> tempLibary = new List<Library>();
        public ShowWindow()
        {
            InitializeComponent();
            tempLibary = repository.LoadBooks();
            list = repository.LoadBooks();
            BooksListView.ItemsSource = list;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            tempLibary.Clear();
            tempLibary = list.Where(x => x.Author.Contains(AuthorName.Text)).ToList();
            BooksListView.ItemsSource = tempLibary;
        }

    }
}
