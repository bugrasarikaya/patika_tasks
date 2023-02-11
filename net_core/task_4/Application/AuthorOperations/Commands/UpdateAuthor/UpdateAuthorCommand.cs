using task_4.DBOperations;
namespace task_4.Application.AuthorOperations.Commands.UpdateAuthor {
    public class UpdateAuthorCommand {
        public int AuthorID { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateAuthorCommand(BookStoreDbContext dbContext) {
            _context = dbContext;
        }
        public void Handle() {
            var Author = _context.Authors.SingleOrDefault(x => x.ID == AuthorID);
            if (Author is null) throw new InvalidOperationException("Güncellencek Yazar Bulunamadı!");
            Author.Name = Model.Name != default ? Model.Name : Author.Name;
            Author.Surname = Model.Surname != default ? Model.Surname : Author.Surname;
			Author.DateofBirth = Model.DateofBirth != default ? Model.DateofBirth : Author.DateofBirth;
			_context.SaveChanges();
        }
    }
    public class UpdateAuthorModel {
        public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime DateofBirth { get; set; }
    }
}