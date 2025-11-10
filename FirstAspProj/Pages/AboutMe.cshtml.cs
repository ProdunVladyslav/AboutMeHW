using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEx.Models;
using System.Collections.Generic;

public class AboutMeModel : PageModel
{
    public Person Person { get; set; }

    public void OnGet()
    {
        Person = new Person
        {
            Id = 1,
            FirstName = "Vlad",
            LastName = "Produn",
            Profession = "Student",
            BirthDate = new DateOnly(2009, 18, 18),
            Skills = new List<Skills>
            {
                new Skills { Id = 1,  Title = "Redis",                Proficiency = 75 },
                new Skills { Id = 2,  Title = "SQL",                  Proficiency = 85 },
                new Skills { Id = 3,  Title = "Entity Framework Core",Proficiency = 80 },
                new Skills { Id = 4,  Title = "ASP.NET Core",         Proficiency = 88 },
                new Skills { Id = 5,  Title = "ADO.NET",              Proficiency = 70 },
                new Skills { Id = 6,  Title = "Vue.js",               Proficiency = 65 },
                new Skills { Id = 7,  Title = "React",                Proficiency = 78 },
                new Skills { Id = 8,  Title = "JavaScript",           Proficiency = 90 },
                new Skills { Id = 9,  Title = "TypeScript",           Proficiency = 82 },
                new Skills { Id = 10, Title = "Docker",               Proficiency = 76 }
            }
        };
    }
}
