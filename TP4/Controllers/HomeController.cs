using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4.Data;
using TP4.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace TP4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
        Debug.WriteLine("UniversityContext is instantiated {0} times", UniversityContext.count);
        List<Student> s = universityContext.Student.ToList();
        
        foreach (Student student in s)
        {
            Debug.WriteLine("----------------------------------------");
            Debug.WriteLine("Student ID : {0}", student.id);
            Debug.WriteLine("Student First Name : {0}", student.first_name);
            Debug.WriteLine("Student Last Name : {0}", student.last_name);
            Debug.WriteLine("Student Phone Number : {0}", student.phone_number);
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}