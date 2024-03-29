﻿using System.ComponentModel.DataAnnotations.Schema;
namespace task_4.Entities {
	public class Author {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime DateofBirth { get; set; }
	}
}