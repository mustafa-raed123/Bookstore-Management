using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookstore_Management.Models.Data;
using Bookstore_Management.Models.Data.Entities;
using System.Net;


namespace Bookstore_Management.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }

          public async Task<IActionResult> Index()
        {
            return View(await _context.book.ToListAsync());
        }
        public IActionResult Create()
        {
            var book = new Book();
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book addBook)
        {
            if (ModelState.IsValid) {
              var book = new Book() {
               Author = addBook.Author,
               Genre = addBook.Genre,
               Price = addBook.Price,
               Title = addBook.Title
              
              };
            
                _context.book.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
              
                var existingBook = await _context.book.FindAsync(book.BookId);

                if (existingBook != null)
                {
                    existingBook.Author = book.Author;
                    existingBook.Price = book.Price;
                    existingBook.Title = book.Title;
                    existingBook.Genre = book.Genre;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Book not found");
                }
            }
            return NotFound();

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int BookId)
        {
            var book = await _context.book.FindAsync(BookId);
            Console.WriteLine(BookId);
            if (book != null)
            {
                return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int bookId)  
        {
            var book = await _context.book.FindAsync(bookId);
            if (book != null)
            {
                _context.book.Remove(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();  
        }

        public async Task<IActionResult> Details(int bookId) {
            var book = await _context.book.FindAsync(bookId);
            
         return View(book);       
        }


    }
}
