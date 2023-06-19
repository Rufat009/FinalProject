using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibProject;

public class JsonRepository
{
    const string path = "books.json";
    public List<Library> LoadBooks()
    {
        List<Library> books = new List<Library>();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            books = JsonConvert.DeserializeObject<List<Library>>(json);
        }

        return books;
    }
    public int GetLastBookId(List<Library> books)
    {
        if (books.Count > 0)
            return books[books.Count - 1].Id;
        return 0;
    }
    public void SaveBooks(List<Library> books)
    {
        string json = JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(path, json);
    }
}
