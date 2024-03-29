﻿using System.ComponentModel.DataAnnotations.Schema;
namespace task_4.Entities {
	public class Book {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Title { get; set; }
		public int AuthorID { get; set; }
		public Author Author { get; set; }
		public int GenreID { get; set; }
		public Genre Genre { get; set; }
		public int PageCount { get; set; }
		public DateTime PublishDate { get; set; }
	}
}