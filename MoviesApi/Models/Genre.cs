﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(length:100)]
        public string Name { get; set; }
    }
}
