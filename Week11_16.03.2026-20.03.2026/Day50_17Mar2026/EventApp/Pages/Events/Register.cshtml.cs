using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventApp.Models;

namespace EventApp.Pages.Events
{
    public class RegisterModel : PageModel
    {
        // In-memory list
        public static List<EventRegistration> registrations = new();

        [BindProperty]
        public EventRegistration Registration { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Registration.Id = registrations.Count + 1;
            registrations.Add(Registration);

            return RedirectToPage("Index");
        }
    }
}