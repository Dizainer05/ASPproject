using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{

    public class Pr
    {
        public int Id { get; set; }
        public string Student { get; set; }
        public string Facultativ { get; set; }
        public string FacHours { get; set; }
        public string WorkHours { get; set; }
        public string Name {get; set; }
        public string Otectvo { get; set; }
        public DateTime Data { get;set ;}
        public string Type { get;set; }
        public static int i = 0;
        public Pr() { }
        public Pr(string student,string name,string otectvo, string facultativ,string fachours, string workhours,string type,DateTime date)// string student
        {
            Id = ++i;
            Student = student;
            Name = name;
            Otectvo = otectvo;
            Facultativ = facultativ;
            FacHours = fachours;
            WorkHours = workhours;
            Type=type;
            Data = date;
        }
    }
    public class IndexModel : PageModel
    {
        public List <Pr> pr { get; set; }  
        private readonly ILogger<IndexModel> _logger;

        public List<Students> students { get; set; }
        public List<Facultative> facultatives { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var context = new Datab();
            pr = new List<Pr>();
            students = new List<Students>();
            facultatives = new List<Facultative>();

            pr = (from n in context.FacultativeRecord
                  join f in context.Facultative on n.FacultativeId equals f.FacultativeId
                  join s in context.Students on n.StudentId equals s.StudentId
                  select new Pr(s.LastName,s.FirstName,s.MiddleName,f.Title, Convert.ToString(f.Hours), Convert.ToString(n.WorkedHours),f.Type,n.DateTime)).ToList();

            var studs = context.Students.ToList();

            foreach (var stud in studs)
            {

                if (!stud.InFacultativ)
                {
                    students.Add(stud);
                }
            }

            var facults = context.Facultative.ToList();
            foreach (var facult in facults)
            {
                facultatives.Add(facult);
            }


        }

        public void OnGet()
        {

        }


        public IActionResult OnPost(string action, int selectedStudent, int selectedFacultativ, int WorkHours)
        {
            if(action== "addStudent")
            {
               return RedirectToPage("./AddStudent");
            }  
            else if(action== "addFacultativ")
            {
                return RedirectToPage("./AddFacultativ");
            }
           else if(action== "addNote")
            {
               using (var context = new Datab())
                {
                    var note = new FacultativeRecord(selectedStudent,selectedFacultativ,DateTime.Now, WorkHours);

                    var stud = context.Students.FirstOrDefault(e => e.StudentId == selectedStudent);

                    if (stud != null)
                    {
                        stud.InFacultativ = true;
                    }
                    context.FacultativeRecord.Add(note);
                    context.SaveChanges();
                }
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
    }
}