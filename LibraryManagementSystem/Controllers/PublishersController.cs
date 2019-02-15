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
    public class PublishersController : Controller
    {
        private readonly IPublisherManager _iPublisherManager;

        public PublishersController(IPublisherManager iPublisherManager)
        {
            _iPublisherManager = iPublisherManager;
        }

        // GET: Publishers
        public IActionResult Index()
        {
            var publisher = _iPublisherManager.GetAll();
            return View(publisher);
        }

        // GET: Publishers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _iPublisherManager.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Publisher publisher)
        {
            if (ModelState.IsValid)
            { publisher.CreatedAt=DateTime.Now;
                _iPublisherManager.Add(publisher);
               
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _iPublisherManager.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {publisher.UpdatedAt=DateTime.Now;
                    _iPublisherManager.Update(publisher);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.Id))
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
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _iPublisherManager.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisher = _iPublisherManager.GetById(id);
            _iPublisherManager.Remove(publisher);
         
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id)
        {
            return _iPublisherManager.GetAll().Any(e => e.Id == id);
        }
    }
}
