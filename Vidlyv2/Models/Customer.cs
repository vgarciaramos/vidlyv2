using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Vidlyv2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubscribedToNewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}
