using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Udemy_VidlyApp.Models;
using Udemy_VidlyApp.Dtos;
using Udemy_VidlyApp.App_Start;
using AutoMapper;


namespace Udemy_VidlyApp.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET
        public IEnumerable<CustomerDto> GetCustomer(Customer customer)
        {
            return _context.Customer.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
              //  return HttpResponseException(HttpStatusCode.NotFound())


            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
             //   return HttpResponseException(HttpStatusCode.BadRequest());
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerinDb = _context.Customer.SingleOrDefault(c => c.Id == id);
            if(customerinDb== null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerinDb);
            //customerinDb.Name = customer.Name;
            //customerinDb.Dob = customer.Dob;
            //customerinDb.IsSuscribed = customer.IsSuscribed;
            //customerinDb.MemberShipTypeId = customer.MemberShipTypeId;

            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            var customerinDb = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customerinDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customer.Remove(customerinDb);

        }
    }
}
