﻿using Microsoft.EntityFrameworkCore;
namespace task_1.DBOperations {
	public class BookStoreDbContext : DbContext {
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
	public DbSet<Book> Books { get; set; }
	}
}