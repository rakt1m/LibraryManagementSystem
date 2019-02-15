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
    public class MembersController : Controller
    {
        private readonly IMemberManager _iMemberManager;

        public MembersController(IMemberManager iMemberManager)
        {
            _iMemberManager = iMemberManager;
        }

        // GET: Members
        public IActionResult Index()
        {
            var member = _iMemberManager.GetAll().ToList();
            return View(member);
        }

        // GET: Members/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _iMemberManager.GetById(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Member member)
        {
            if (ModelState.IsValid)
            {
                member.CreatedAt=DateTime.Now;
                _iMemberManager.Add(member);
                
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _iMemberManager.GetById(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                { member.UpdatedAt=DateTime.Now;
                    _iMemberManager.Update(member);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _iMemberManager.GetById(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var member = _iMemberManager.GetById(id);
            _iMemberManager.Remove(member);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _iMemberManager.GetAll().Any(e => e.Id == id);
        }
    }
}
