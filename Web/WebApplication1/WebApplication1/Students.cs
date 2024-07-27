using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1
{
    [Table("Students")]
    public class Students
    {
        [Key]
        public int StudentId { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("MiddleName")]
        public string MiddleName { get; set; }

        [Column("Group")]
        public string Group { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("InFacultativ")]
        public bool InFacultativ { get; set; }

        public Students(string firstname, string lastname, string middlename, string group, string phonenumber, bool infacultativ)
        {
            FirstName = firstname;
            LastName = lastname;
            MiddleName = middlename;
            Group = group;
            PhoneNumber = phonenumber;
            InFacultativ = infacultativ;
        }
        public Students() { }
    }

}
