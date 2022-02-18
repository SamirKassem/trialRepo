using System;

namespace trial.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public bool isRead { get; set; }

        public DateTime? dateRead { get; set; }

        public DateTime DateAdded { get; set; }

        public int? Rating { get; set; }

        public string Genre { get; set; }

        public string coverUrl { get; set; }

    }
}
