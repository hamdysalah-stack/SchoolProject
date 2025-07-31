using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {

        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        public string? insName { get; set; }
        public string? Address { get; set; }

        public string? Position { get; set; }

        public int? SubervisorId { get; set; }
        public decimal? Salary { get; set; }



        // Foreign key to Department
        [ForeignKey(nameof(DID))]
        public int? DID { get; set; }
        // Navigation property to Department

        [InverseProperty("Instructors")]
        public virtual Department? Department { get; set; }

        [InverseProperty("Supervisor")]
        public virtual Department? DepartmentManager { get; set; }




        // Navigation properties for self-referencing relationship
        [ForeignKey(nameof(SubervisorId))]
        [InverseProperty("Instructors")]
        public Instructor? Supervisor { get; set; }
        [InverseProperty("Supervisor")]

        public virtual ICollection<Instructor> Instructors { get; set; }


        [InverseProperty("instructor")]

        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
