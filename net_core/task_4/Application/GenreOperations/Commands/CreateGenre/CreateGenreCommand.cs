﻿using task_4.DBOperations;
using task_4.Entities;
namespace task_4.Application.GenreOperations.Commands.CreateGenre {
	public class CreateGenreCommand {
		public CreateGenreModel Model { get; set; }
		private readonly IBookStoreDbContext _context;
		public CreateGenreCommand(IBookStoreDbContext context) {
			_context = context;
		}
		public void Handle() {
			var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
			if (genre is not null) throw new InvalidOperationException("Kitap Türü Zaten Mevcut.");
			genre = new Genre();
			genre.Name = Model.Name;
			_context.Genres.Add(genre);
			_context.SaveChanges();
		}
	}
	public class CreateGenreModel {
		public string Name { get; set; }
	}
}