using FirstAspProj.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using System.Collections.Generic;

public class PersonModel : PageModel
{
    private IPersonDataProvider _personDataProvider;

    public PersonModel(IPersonDataProvider personDataProvider)
    {
        _personDataProvider = personDataProvider;
    }

    public Person Person { get; set; }
    public List<Skill> Skills { get; set; }

    public void OnGet(int id)
    {
        Person = _personDataProvider.GetPersonById(id);
        Skills = _personDataProvider.GetSkillsForPerson(id);
    }
}
