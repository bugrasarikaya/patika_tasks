﻿using task_4.DBOperations;

namespace task_4.Application.GenreOperations.DeleteGenre {
	public class DeleteGenreCommand {
		public int GenreID { get; set; }
		private readonly BookStoreDbContext _context;
		public DeleteGenreCommand(BookStoreDbContext context) {
			_context = context;
		}
		public  void Handle() {
			var genre = _context.Genres.SingleOrDefault(x => x.ID == GenreID);
			if (genre is null) throw new InvalidOperationException("Kitap Türü Bulunamadı!");
			_context.Remove(genre);
			_context.SaveChanges();
		}
	}
}