using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.BLL.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.DbContext.AppDbContext;
using LibraryManagementSystem.Models.EntityModels;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookCategoryManager _iBookCategoryManager;
        private readonly IAuthorManager _iAuthorManager;
        private readonly ILanguageManager _iLanguageManager;
        private readonly IPublisherManager _iPublisherManager;
        private readonly IBookManager _iBookManager;



        public BooksController(IBookCategoryManager iBookCategoryManager, IAuthorManager iAuthorManager,
            ILanguageManager iLanguageManager,
            IPublisherManager iPublisherManager, IBookManager iBookManager)
        {
            _iLanguageManager = iLanguageManager;

            _iBookCategoryManager = iBookCategoryManager;
            _iAuthorManager = iAuthorManager;
            _iPublisherManager = iPublisherManager;
            _iBookManager = iBookManager;
        }

        // GET: Books
        public IActionResult Index()
        {
            var book = _iBookManager.GetAll().ToList();
            return View(book);
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _iBookManager.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_iAuthorManager.GetAll(), "Id", "Name");
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Name");
            ViewData["LanguageId"] = new SelectList(_iLanguageManager.GetAll(), "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_iPublisherManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Book book)
        {
            if (ModelState.IsValid)
            {
                book.CreatedAt = DateTime.Now;
                _iBookManager.Add(book);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_iAuthorManager.GetAll(), "Id", "Name", book.AuthorId);
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Name", book.BookCategoryId);
            ViewData["LanguageId"] = new SelectList(_iLanguageManager.GetAll(), "Id", "Name", book.LanguageId);
            ViewData["PublisherId"] = new SelectList(_iPublisherManager.GetAll(), "Id", "Name", book.PublisherId);

           
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _iBookManager.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_iAuthorManager.GetAll(), "Id", "Name", book.AuthorId);
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Name", book.BookCategoryId);
            ViewData["LanguageId"] = new SelectList(_iLanguageManager.GetAll(), "Id", "Name", book.LanguageId);
            ViewData["PublisherId"] = new SelectList(_iPublisherManager.GetAll(), "Id", "Name", book.PublisherId);

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    book.UpdatedAt=DateTime.Now;
                    _iBookManager.Update(book);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_iAuthorManager.GetAll(), "Id", "Name", book.AuthorId);
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Name", book.BookCategoryId);
            ViewData["LanguageId"] = new SelectList(_iLanguageManager.GetAll(), "Id", "Name", book.LanguageId);
            ViewData["PublisherId"] = new SelectList(_iPublisherManager.GetAll(), "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _iBookManager.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _iBookManager.GetById(id);
            _iBookManager.Remove(book);
            
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _iBookManager.GetAll().Any(e => e.Id == id);
        }
    }
}
