using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parttime.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="First Name")]
        [StringLength(50,ErrorMessage ="First Name cannot be longer than 50 Characters.",MinimumLength =1)]
        [Column("FirstName")]
        public string FirstMidname { get; set; }
        [Required]
        [StringLength(50,MinimumLength =1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name ="Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public string Secret { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstMidname + "," + LastName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments{ get; set; }
    }
}