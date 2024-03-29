﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_4.DBOperations;
namespace task_4.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x => x.Genre).OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            return vm;
        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}