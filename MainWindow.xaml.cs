using LibProject.Models;
using LibProject.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibProject;


public partial class MainWindow : Window
{
    

    private JsonRepository repository = new JsonRepository();
    const string path = "books.json";
    public MainWindow()
    {
        InitializeComponent();
        BooksListView.ItemsSource = repository.LoadBooks();
        
    }

    private void SetDefault()
    {
        ShowMenu.Visibility = Visibility.Hidden;
        AddMenu.Visibility = Visibility.Hidden;
        EditMenu.Visibility = Visibility.Hidden;
        DeleteMenu.Visibility = Visibility.Hidden;
    }

    private void ShowButton_Click(object sender, RoutedEventArgs e)
    {
        SetDefault();
        ShowMenu.Visibility = Visibility.Visible;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        SetDefault();
        AddMenu.Visibility = Visibility.Visible;
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        SetDefault();
        EditMenu.Visibility = Visibility.Visible;
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        SetDefault();
        DeleteMenu.Visibility = Visibility.Visible;
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
            BooksListView.ItemsSource = repository.LoadBooks();
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
            BooksListView.ItemsSource = repository.LoadBooks();
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

    private void Button_Click(object sender, RoutedEventArgs e) // Delete
    {
        try
        {
            List<Library> books = repository.LoadBooks();
            if (int.Parse(deleteBookId.Text) > repository.GetLastBookId(books))
                throw new IndexOutOfRangeException("There is no such id");
            books.RemoveAt(int.Parse(deleteBookId.Text) - 1);
            repository.SaveBooks(books);
            BooksListView.ItemsSource = repository.LoadBooks();
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

    private void ExitButton_Click(object sender, RoutedEventArgs e) => this.Close();


    protected override void OnClosing(CancelEventArgs e)
    {
        new Window2().Show();
        base.OnClosing(e);
    }

    private void ExitFromShowBook_Click(object sender, RoutedEventArgs e)
    {
        SetDefault();
    }

}