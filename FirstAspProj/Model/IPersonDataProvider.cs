using RazorEx.Models;

namespace FirstAspProj.Model
{
    public interface IPersonDataProvider
    {
        public List<Person> GetPeople();
        public Person GetPersonById(int id);

        public bool UpsertPerson(Person person);

        public bool UpdatePerson(Person person);

        public bool UpsertSkill(Skill skill, int personId);

        public bool UpdateSkill(Skill skill);

        public bool DeleteSkill(int skillId, int personId);

        public List<Skill> GetSkillsForPerson(int personId);

        public bool DeletePerson(int id);
    }
}
