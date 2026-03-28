using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventApp.Models;

namespace EventApp.Pages.Events
{
    public class IndexModel : PageModel
    {
        public List<EventRegistration> Registrations { get; set; }

        public void OnGet()
        {
            Registrations = RegisterModel.registrations;
        }

        public IActionResult OnPostDelete(int id)
        {
            var item = RegisterModel.registrations.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                RegisterModel.registrations.Remove(item);
            }

            return RedirectToPage();
        }
    }
}