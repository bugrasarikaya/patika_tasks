﻿using System.ComponentModel.DataAnnotations.Schema;
namespace task_4.Entities {
	public class Genre {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; } = true;
	}
}