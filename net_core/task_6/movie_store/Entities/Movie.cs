﻿using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Movie {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
		public int Year { get; set; }
		public Director? Director { get; set; }
		public ICollection<Actor> Actors { get; set; } = new List<Actor>();
		public ICollection<Genre> Genres { get; set; } = new List<Genre>();
		public double Price { get; set; }
	}
}