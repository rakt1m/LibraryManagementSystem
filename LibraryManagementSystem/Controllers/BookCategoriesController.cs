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
    public class BookCategoriesController : Controller
    {
        private readonly IBookCategoryManager _iBookCategoryManager;

        public BookCategoriesController(IBookCategoryManager iBookCategoryManager)
        {
            _iBookCategoryManager = iBookCategoryManager;

        }

        // GET: BookCategories
        public IActionResult Index()
        {
            return View(_iBookCategoryManager.GetAll());
        }

        // GET: BookCategories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = _iBookCategoryManager.GetById(id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // GET: BookCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _iBookCategoryManager.Add(bookCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategory);
        }

        // GET: BookCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = _iBookCategoryManager.GetById(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        // POST: BookCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookCategory bookCategory)
        {
            if (id != bookCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _iBookCategoryManager.Update(bookCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoryExists(bookCategory.Id))
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
            return View(bookCategory);
        }

        // GET: BookCategories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategory = _iBookCategoryManager.GetById(id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // POST: BookCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bookCategory = _iBookCategoryManager.GetById(id);
            _iBookCategoryManager.Remove(bookCategory);
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoryExists(int id)
        {
            return _iBookCategoryManager.GetAll().Any(e => e.Id == id);
        }
    }
}
