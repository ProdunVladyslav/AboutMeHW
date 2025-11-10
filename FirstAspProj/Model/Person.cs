namespace RazorEx.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public List<Skills> Skills { get; set; } = [];
    }
}
