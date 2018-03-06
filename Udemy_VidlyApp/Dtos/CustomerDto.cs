using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Udemy_VidlyApp.Models;

namespace Udemy_VidlyApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dont Forget to enter your name!")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSuscribed { get; set; }
     
        public byte MemberShipTypeId { get; set; }

     
       // [ValidateMemberByAge]
        public DateTime? Dob { get; set; }



    }
}