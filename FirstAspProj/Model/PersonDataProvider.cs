using FirstAspProj.Model;
using RazorEx.Models;

namespace FirstAspProj.Model;

public class PersonDataProvider : IPersonDataProvider
{
    private readonly List<Person> people = new()
    {
        new Person
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Profession = "Software Developer",
            BirthDate = new DateOnly(1990, 1, 1),
            SkillIds = new List<int>
            {
                1, 2, 3
            }
        },

        new Person
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            Profession = "Web Designer",
            BirthDate = new DateOnly(1985, 5, 15),
            SkillIds = new List<int>
            { 
                4, 5, 6
            }
        }
    };

    public List<Person> GetPeople() => people;

    private readonly List<Skill> skills = new()
    {
        new Skill { Id = 1, Title = "C#", Proficiency = 90 },
        new Skill { Id = 2, Title = "ASP.NET Core", Proficiency = 85 },
        new Skill { Id = 3, Title = "Razor Pages", Proficiency = 80 },
        new Skill { Id = 4, Title = "HTML", Proficiency = 95 },
        new Skill { Id = 5, Title = "CSS", Proficiency = 90 },
        new Skill { Id = 6, Title = "JavaScript", Proficiency = 85 }
    };

    public Person GetPersonById(int id) =>
        people.FirstOrDefault(p => p.Id == id) ?? throw new KeyNotFoundException($"Person with ID {id} not found.");

    public bool UpsertPerson(Person person)
    {
        if (person == null)
            return false;

        var existing = people.FirstOrDefault(p => p.Id == person.Id);
        if (existing == null)
        {
            person.Id = people.Any() ? people.Max(p => p.Id) + 1 : 1;
            people.Add(person);
        }
        else
        {
            existing.FirstName = person.FirstName;
            existing.LastName = person.LastName;
            existing.Profession = person.Profession;
            existing.BirthDate = person.BirthDate;
            existing.SkillIds = person.SkillIds;
        }

        return true;
    }

    public bool UpsertSkill(Skill skill, int personId)
    {
        if (skill == null) return false;

        var person = people.FirstOrDefault(x => x.Id == personId);
        if (person == null) return false;

        // Update existing skill
        if (person.SkillIds.Contains(skill.Id))
        {
            return UpdateSkill(skill);
        }

        // Create new skill globally
        int newSkillId = skills.Any()
            ? skills.Max(x => x.Id) + 1
            : 1;

        skill.Id = newSkillId;
        skills.Add(skill);

        // Store only ID in the person's list
        person.SkillIds.Add(newSkillId);

        return true;
    }

    public bool UpdateSkill(Skill skill)
    {
        if (skill == null) return false;

        var existingSkill = skills.FirstOrDefault(x => x.Id == skill.Id);
        if (existingSkill == null) return false;

        existingSkill.Title = skill.Title;
        existingSkill.Proficiency = skill.Proficiency;

        return true;
    }

    public bool UpdatePerson(Person person)
    {
        var existing = people.FirstOrDefault(p => p.Id == person.Id);
        if (existing == null)
            return false;

        existing.FirstName = person.FirstName;
        existing.LastName = person.LastName;
        existing.Profession = person.Profession;
        existing.BirthDate = person.BirthDate;
        existing.SkillIds = person.SkillIds;
        return true;
    }

    public bool DeletePerson(int id)
    {
        var person = people.FirstOrDefault(p => p.Id == id);
        if (person == null)
            return false;

        people.Remove(person);
        return true;
    }

    public bool DeleteSkill(int skillId, int personId)
    {
        var person = people.FirstOrDefault(x => x.Id == personId);
        if (person == null) return false;

        if (!person.SkillIds.Remove(skillId))
            return false;

        // Optionally remove from global list only if unused
        bool usedElsewhere = people.Any(p => p.SkillIds.Contains(skillId));

        if (!usedElsewhere)
        {
            var globalSkill = skills.FirstOrDefault(x => x.Id == skillId);
            if (globalSkill != null)
                skills.Remove(globalSkill);
        }

        return true;
    }

    public List<Skill> GetSkillsForPerson(int personId)
    {
        var person = people.FirstOrDefault(x => x.Id == personId);
        if (person == null) return new List<Skill>();

        return skills
            .Where(s => person.SkillIds.Contains(s.Id))
            .ToList();
    }
}
