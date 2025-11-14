using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using FirstAspProj.Model;

public class PersonSkillsModel : PageModel
{
    private readonly IPersonDataProvider _provider;

    public PersonSkillsModel(IPersonDataProvider provider)
    {
        _provider = provider;
    }

    public Person Person { get; set; } = new();
    public List<Skill> Skills { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var afterDeleteMessage = Request.Cookies["After-Delete-Message"];

        if (!string.IsNullOrEmpty(afterDeleteMessage))
        {
            ViewData["AfterDeleteMessage"] = afterDeleteMessage;
            Response.Cookies.Delete("After-Delete-Message");
        }

        Person = _provider.GetPersonById(id);
        Skills = _provider.GetSkillsForPerson(id);

        return Page();
    }

    public IActionResult OnPostDelete(int skillId, int personId)
    {
        var deleted = _provider.DeleteSkill(skillId, personId);

        if (deleted)
        {
            Response.Cookies.Append("After-Delete-Message", "Skill deleted successfully");
        }

        return RedirectToPage(new { id = personId });
    }
}