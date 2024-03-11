using HomeLibrary.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeLibrary.MVC.Controllers;

public class BooksListsController : Controller
{
    private readonly BooksListContext _context;

    public BooksListsController(BooksListContext context)
    {
        _context = context;
    }

    // GET: BooksLists
    public async Task<IActionResult> Index()
    {
        return View(await _context.BooksList.ToListAsync());
    }

    // GET: BooksLists/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booksList = await _context.BooksList
            .FirstOrDefaultAsync(m => m.Id == id);
        if (booksList == null)
        {
            return NotFound();
        }

        return View(booksList);
    }

    // GET: BooksLists/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BooksLists/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Author,PublicationYear,Edition,TableOfContents")] BooksList booksList)
    {
        if (ModelState.IsValid)
        {
            _context.Add(booksList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(booksList);
    }

    // GET: BooksLists/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booksList = await _context.BooksList.FindAsync(id);
        if (booksList == null)
        {
            return NotFound();
        }
        return View(booksList);
    }

    // POST: BooksLists/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,PublicationYear,Edition,TableOfContents")] BooksList booksList)
    {
        if (id != booksList.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(booksList);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksListExists(booksList.Id))
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
        return View(booksList);
    }

    // GET: BooksLists/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booksList = await _context.BooksList
            .FirstOrDefaultAsync(m => m.Id == id);
        if (booksList == null)
        {
            return NotFound();
        }

        return View(booksList);
    }

    // POST: BooksLists/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var booksList = await _context.BooksList.FindAsync(id);
        if (booksList != null)
        {
            _context.BooksList.Remove(booksList);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BooksListExists(int id)
    {
        return _context.BooksList.Any(e => e.Id == id);
    }
}