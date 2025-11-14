using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using FirstAspProj.Model;

public class EditSkillModel : PageModel
{
    private readonly IPersonDataProvider _provider;

    public EditSkillModel(IPersonDataProvider provider)
    {
        _provider = provider;
    }

    [BindProperty]
    public Skill Skill { get; set; } = new();

    [BindProperty]
    public int PersonId { get; set; }

    public IActionResult OnGet(int personId, int id)
    {
        PersonId = personId;

        var personSkills = _provider.GetSkillsForPerson(personId);
        var skill = personSkills.FirstOrDefault(x => x.Id == id);

        if (skill == null)
            return RedirectToPage("/PersonSkills", new { id = personId });

        Skill = new Skill
        {
            Id = skill.Id,
            Title = skill.Title,
            Proficiency = skill.Proficiency
        };

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        var ok = _provider.UpdateSkill(Skill);
        if (!ok)
        {
            ModelState.AddModelError("", "Failed to update skill.");
            return Page();
        }

        return RedirectToPage("/PersonSkills", new { id = PersonId });
    }
}
