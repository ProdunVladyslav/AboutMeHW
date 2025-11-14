using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using FirstAspProj.Model;

namespace FirstAspProj.Pages
{
    public class UpsertPersonModel : PageModel
    {
        private readonly IPersonDataProvider _personData;

        [BindProperty]
        public Person Person { get; set; } = new();

        public UpsertPersonModel(IPersonDataProvider personData)
        {
            _personData = personData;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                Person = new Person(); // new entry
            }
            else
            {
                var person = _personData.GetPersonById(id.Value);
                if (person == null)
                    return NotFound();

                Person = person;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Person.Id == 0)
            {
                // Add new person
                _personData.UpsertPerson(Person);
            }
            else
            {
                // Update existing
                var updated = _personData.UpdatePerson(Person);
                if (!updated)
                    return NotFound($"Person with ID {Person.Id} not found.");
            }

            return RedirectToPage("/People");
        }
    }
}
