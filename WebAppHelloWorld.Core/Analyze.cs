using System.Linq;
using System.Collections.Generic;

namespace BookFinder
{
    public class Analyzer
    {
        public Dictionary<string, DataItem[]> Datas = new Dictionary<string, DataItem[]>();
        public Analyzer()
        {
            foreach (Book book in new Library().Books)
                Analyze(book);            
        }
        public Analyzer(List<Book> books)
        {
            foreach (Book book in books)
                Analyze(book);
        }
        public void Analyze(Book book)
        {
            string[] words = book.BookContext.Split();
            List<List<string>> booksWords = new List<List<string>>();
            List<DataItem> di = new List<DataItem>();            
            int count = 0;

            for (int i=0; i<words.Length/10000; i++)
                booksWords.Add(words.Skip(i*10000).Take(10000).ToList());

            foreach (List<string> part in booksWords)
            {
                count += part.Count;
                di.Add( new DataItem(count, 
                        part.Where(word => book.PositiveWordsContext.Contains(word)).Count(),
                        part.Where(word => book.NegativeWordsContext.Contains(word)).Count()));
            }

            this.Datas.Add(book.Name, di.ToArray());            
        }
    }
    public class DataItem
    {
        public int Words { get; set; }
        public int NegativeWords { get; set; }
        public int PositiveWords {get; set;}
        public int RiseOrFall 
        {
            get => this.PositiveWords - this.NegativeWords;
        }
        public DataItem(int words, int NegativeWords, int PositiveWords)
        {
            this.Words = words;
            this.NegativeWords = NegativeWords;
            this.PositiveWords = PositiveWords;
        }

    }
}