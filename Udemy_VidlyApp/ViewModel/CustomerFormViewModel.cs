using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy_VidlyApp.Models;

namespace Udemy_VidlyApp.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer{ get; set; }

    }
}