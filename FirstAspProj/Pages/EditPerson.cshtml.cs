using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using FirstAspProj.Model;

namespace FirstAspProj.Pages
{
    public class EditPersonModel : PageModel
    {
        private readonly IPersonDataProvider _personData;

        [BindProperty]
        public Person Person { get; set; } = new();

        public EditPersonModel(IPersonDataProvider personData)
        {
            _personData = personData;
        }

        public IActionResult OnGet(int id)
        {
            var person = _personData.GetPersonById(id);
            if (person == null)
            {
                Console.WriteLine($" Person with ID {id} not found.");
                return NotFound();
            }

            Console.WriteLine($" Loaded person: {person.FirstName} {person.LastName} (ID: {person.Id})");
            Person = person;
            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updated = _personData.UpdatePerson(Person);
            if (!updated)
            {
                return NotFound($"Person with ID {Person.Id} not found.");
            }

            return RedirectToPage("/people"); // redirect to your list page
        }
    }
}
