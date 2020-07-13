namespace BookFinder
{
    public class Book
    {
        public string Name;
        public string Description;
        public string ImagePath;
        public string PositiveWordsContext;
        public string NegativeWordsContext;
        public string BookContext;
        public Book(string name, string description, string imagePath, string words, string positiveWords, string negativeWords)
        {
            this.Name = name;
            this.Description = description;
            this.ImagePath = imagePath;
            this.BookContext = words;
            this.PositiveWordsContext = positiveWords;
            this.NegativeWordsContext = negativeWords;
        }
        public int positive = 0;
        public int negative = 0;
        public int count = 0;
    }
}