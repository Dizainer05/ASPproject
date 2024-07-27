using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1
{
    [Table("FacultativeRecord")]
    public class FacultativeRecord
    {
        [Key]
        public int RecordId { get; set; }


        [Column("StudentId")]
        public int StudentId { get; set; }

        [Column("FacultativeId")]
        public int FacultativeId { get; set; }

        [Column("DateTime")]
        public DateTime DateTime { get; set; }

        [Column("WorkedHours")]
        public int WorkedHours { get; set; }

        public FacultativeRecord(int studentid, int facultativid, DateTime date, int workhours)
        {
            StudentId = studentid;
            FacultativeId = facultativid;
            DateTime = date;
            WorkedHours = workhours;
        }
        public FacultativeRecord() { }
    }

}
