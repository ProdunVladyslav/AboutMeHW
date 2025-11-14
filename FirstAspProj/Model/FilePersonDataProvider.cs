//using FirstAspProj.Model;
//using Microsoft.AspNetCore.Hosting;
//using RazorEx.Models;
//using System.IO;
//using System.Text.Json;

//public class FilePersonDataProvider : IPersonDataProvider
//{
//    private readonly string _filePath;

//    public FilePersonDataProvider(IWebHostEnvironment env)
//    {
//        _filePath = Path.Combine(env.ContentRootPath, "Model", "persondata.json");
//    }

//    public Person GetPerson()
//    {
//        var json = File.ReadAllText(_filePath);
//        return JsonSerializer.Deserialize<Person>(json);
//    }
//}