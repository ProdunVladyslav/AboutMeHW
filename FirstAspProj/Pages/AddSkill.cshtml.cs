using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using FirstAspProj.Model;

public class AddSkillModel : PageModel
{
    private readonly IPersonDataProvider _provider;

    public AddSkillModel(IPersonDataProvider provider)
    {
        _provider = provider;
    }

    [BindProperty]
    public Skill Skill { get; set; } = new();

    [BindProperty]
    public int PersonId { get; set; }

    public IActionResult OnGet(int personId)
    {
        PersonId = personId;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        var ok = _provider.UpsertSkill(Skill, PersonId);
        if (!ok)
        {
            ModelState.AddModelError("", "Failed to add skill.");
            return Page();
        }

        return RedirectToPage("/PersonSkills", new { id = PersonId });
    }
}
