using FirstAspProj.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using System.Collections.Generic;

public class AboutMeModel : PageModel
{
    private IPersonDataProvider _personDataProvider;

    public AboutMeModel(IPersonDataProvider personDataProvider) { 
        _personDataProvider = personDataProvider;
        Person = _personDataProvider.GetPersonById(1);
        Skills = _personDataProvider.GetSkillsForPerson(1);
    }

    public Person Person {  get; set; }
    public List<Skill> Skills { get; set; }

    public void OnGet()
    {
    }
}
