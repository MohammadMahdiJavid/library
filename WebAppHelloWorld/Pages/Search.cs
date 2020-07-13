using System.ComponentModel.DataAnnotations;
using System;

namespace BookFinder
{
    public class Search
    {
        [Required (ErrorMessage = "Book Name should not be empty", AllowEmptyStrings=false)]
        public string BookName {get; set;}
    }
}