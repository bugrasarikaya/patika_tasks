﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_4.DBOperations;
namespace task_4.Application.BookOperations.Queries.GetBookDetail {
    public class GetBookDetailQuery {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookID { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle() {
            var book = _dbContext.Books.Include(x =>x.Genre).Where(book => book.Id == BookID).SingleOrDefault();
            if (book is null) throw new InvalidOperationException("Kitap Bulunamadı!");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            return vm;
        }
    }
    public class BookDetailViewModel {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}