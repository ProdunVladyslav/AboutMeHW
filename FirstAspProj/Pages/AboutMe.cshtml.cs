using FirstAspProj.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using System.Collections.Generic;

public class AboutMeModel : PageModel
{
    private IPersonDataProvider _personDataProvider;

    public AboutMeModel(IPersonDataProvider personDataProvider) { 
        _personDataProvider = personDataProvider;
        Person = _personDataProvider.GetPerson();
    }

    public Person Person {  get; set; }

    public void OnGet()
    {
    }
}
