using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FirstAspProj.Model;
using RazorEx.Models;

public class PeopleModel : PageModel
{
    private readonly IPersonDataProvider _personData;

    public List<Person> People { get; set; } = new();

    public PeopleModel(IPersonDataProvider personData)
    {
        _personData = personData;
    }

    public void OnGet()
    {
        People = _personData.GetPeople();
    }

    public IActionResult OnPostDelete(int id)
    {
        var deleted = _personData.DeletePerson(id);
        if (!deleted)
            return NotFound($"Person with ID {id} not found.");

        return RedirectToPage("/people");
    }
}
