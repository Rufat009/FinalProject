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
      
        
    }


    private void ShowButton_Click(object sender, RoutedEventArgs e)
    {
        new ShowWindow().ShowDialog();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        new AddBook().ShowDialog();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        
        new EditBook().ShowDialog();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
       new DeleteBookxaml().ShowDialog();
    }

    

    private void ExitButton_Click(object sender, RoutedEventArgs e) => this.Close();



}