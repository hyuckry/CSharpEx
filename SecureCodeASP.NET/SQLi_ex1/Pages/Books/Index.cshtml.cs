using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLi_ex1.Data;
using SQLi_ex1.Models;

namespace SQLi_ex1.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly SQLi_ex1.Data.SQLi_ex1Context _context;

        public IndexModel(SQLi_ex1.Data.SQLi_ex1Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
