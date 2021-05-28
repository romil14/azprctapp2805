﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreModels;
using EFCore.Data;

namespace az_webAppDb_ass280521.Controllers
{
    public class ExpenseCategoriesController : Controller
    {
        private readonly ExpenseDbContext _context;

        public ExpenseCategoriesController(ExpenseDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseCategories.ToListAsync());
        }

        // GET: ExpenseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = await _context.ExpenseCategories
                .FirstOrDefaultAsync(m => m.ExpenseCategoryId == id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseCategoryId,ExpenseCategoryName")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }
            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseCategoryId,ExpenseCategoryName")] ExpenseCategory expenseCategory)
        {
            if (id != expenseCategory.ExpenseCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseCategoryExists(expenseCategory.ExpenseCategoryId))
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
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = await _context.ExpenseCategories
                .FirstOrDefaultAsync(m => m.ExpenseCategoryId == id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
            _context.ExpenseCategories.Remove(expenseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseCategoryExists(int id)
        {
            return _context.ExpenseCategories.Any(e => e.ExpenseCategoryId == id);
        }
    }
}
