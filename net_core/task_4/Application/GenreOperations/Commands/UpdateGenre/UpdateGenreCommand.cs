using task_4.DBOperations;
namespace task_4.Application.GenreOperations.Commands.UpdateGenre {
	public class UpdateGenreCommand {
		public int GenreID { get; set; }
		public UpdateGenreModel Model { get; set; }
		private readonly IBookStoreDbContext _context;
		public UpdateGenreCommand(IBookStoreDbContext context) {
			_context = context;
		}
		public void Handle() {
			var genre = _context.Genres.SingleOrDefault(x => x.ID == GenreID);
			if (genre is null) throw new InvalidOperationException("Kitap Türü bulunamadı!");
			if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.ID != GenreID)) throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");
			genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
			genre.IsActive = Model.IsActive;
			_context.SaveChanges();
		}
	}
	public class UpdateGenreModel {
		public string Name { get; set; }
		public bool IsActive { get; set; } = true;
	}
}