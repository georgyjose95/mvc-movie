using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Udemy_VidlyApp.Models
{
    public class ValidateMemberByAge: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            
            if(customer.MemberShipTypeId == MemberShipType.Unknown || customer.MemberShipTypeId == MemberShipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.Dob == null)
            {
                return new ValidationResult("Birthdate must be specified!");
            }
            var age = DateTime.Today.Year - customer.Dob.Value.Year;

            return (age>=18)? ValidationResult.Success: new ValidationResult("Customer age must be greater than 18 ");
        }

    }
}