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
    public class IssuesController : Controller
    {
        private readonly IMemberManager _iMemberManager;
        private readonly IBookManager _iBookManager;
        private readonly IIssueManager _iIssueManager;

        public IssuesController(IBookManager iBookManager, IMemberManager iMemberManager,IIssueManager iIssueManager)
        {
            _iBookManager = iBookManager;
            _iMemberManager = iMemberManager;
            _iIssueManager = iIssueManager;
        }

        // GET: Issues
        public IActionResult Index()
        {
            var issue = _iIssueManager.GetAll().ToList();
            return View(issue);
        }

        // GET: Issues/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = _iIssueManager.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_iBookManager.GetAll(), "Id", "Name");
            ViewData["MemberId"] = new SelectList(_iMemberManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Issue issue)
        {
            if (ModelState.IsValid)
            { issue.CreatedAt=DateTime.Now;
                _iIssueManager.Add(issue);
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_iBookManager.GetAll(), "Id", "Name", issue.BookId);
            ViewData["MemberId"] = new SelectList(_iMemberManager.GetAll(), "Id", "Name", issue.MemberId);

           
            return View(issue);
        }

        // GET: Issues/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = _iIssueManager.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_iBookManager.GetAll(), "Id", "Name", issue.BookId);
            ViewData["MemberId"] = new SelectList(_iMemberManager.GetAll(), "Id", "Name", issue.MemberId);

            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Issue issue)
        {
            if (id != issue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                { issue.UpdatedAt=DateTime.Now;
                    _iIssueManager.Update(issue);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
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
            ViewData["BookId"] = new SelectList(_iBookManager.GetAll(), "Id", "Name", issue.BookId);
            ViewData["MemberId"] = new SelectList(_iMemberManager.GetAll(), "Id", "Name", issue.MemberId);

            return View(issue);
        }

        // GET: Issues/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = _iIssueManager.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var issue = _iIssueManager.GetById(id);
            _iIssueManager.Remove(issue);
          
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
            return _iIssueManager.GetAll().Any(e => e.Id == id);
        }
    }
}
