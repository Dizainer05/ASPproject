using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class AddFacultativModel : PageModel
    {
        public List<Facultative> facultatives { get; set; }

        public void OnGet()
        {
            using (var context = new Datab())
            {
                facultatives = context.Facultative.ToList();
            }
        }


        [BindProperty]
        public string NameFacult { get; set; }
        [BindProperty]
        public string Hours { get; set; }
        [BindProperty]
        public string Type { get; set; }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
                using (var context = new Datab())
                {
                    Facultative empl = new Facultative(NameFacult,Convert.ToInt32(Hours),Type);
                    context.Facultative.Add(empl);
                    context.SaveChanges();
                }

                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
