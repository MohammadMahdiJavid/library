using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookFinder
{
    public class Library 
    {    
        public string LibraryPath = @"C:\git\AP98992\TA\AW11\BookFinder.UI\wwwroot\Files";
        public List<Book> Books = new List<Book>();
        public Library()
        {
            this.Books = this.InitializeBooks;
        }
        public Library (string path) 
        :this()
        {
            this.LibraryPath = path;            
        }
        private List<Book> InitializeBooks 
        {
            get 
            {
                List<Book> result = new List<Book> ();
                foreach (string bookPath in Directory.GetFiles ($"{this.LibraryPath}\\books")) 
                {
                    string bookContext = File.ReadAllText(bookPath);
                    string positiveWordsContext = File.ReadAllText($"{this.LibraryPath}\\words\\positive-words.txt");
                    string negativeWordsContext = File.ReadAllText($"{this.LibraryPath}\\words\\negative-words.txt");

                    string bookName = Path.GetFileNameWithoutExtension (bookPath);
                    string bookDescription = bookContext.Substring (0, 50);
                    string imagePath = $"/Files/images/{bookName}.jpg";

                    result.Add (new Book (bookName, bookDescription, imagePath, bookContext, positiveWordsContext, negativeWordsContext));
                }
                return result;
            }
        }        
    }
}