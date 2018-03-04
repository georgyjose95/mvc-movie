using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Udemy_VidlyApp.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Dont Forget to enter your name!")][StringLength(255)]
        public string Name { get; set; }
        public  bool IsSuscribed{ get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Display(Name =" Membership Type")]
        public byte MemberShipTypeId { get; set; } 
      
        [Display(Name= "Date of Birth")]
        [ValidateMemberByAge]
        public DateTime? Dob { get; set; }




    }
}