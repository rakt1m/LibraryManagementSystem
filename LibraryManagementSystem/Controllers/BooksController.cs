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
        private readonly IBookManager _iBookManager;
        private readonly IBookCategoryManager _iBookCategoryManager;

        public BooksController(IBookManager iBookManager,IBookCategoryManager iBookCategoryManager)
        {
            _iBookCategoryManager = iBookCategoryManager;
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
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Id");
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
                _iBookManager.Add(book);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Id", book.BookCategoryId);
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
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Id", book.BookCategoryId);
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
            ViewData["BookCategoryId"] = new SelectList(_iBookCategoryManager.GetAll(), "Id", "Id", book.BookCategoryId);
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
