
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESS_Objects
{
    public class OM_Customer
    {

        public int customerNumber { set; get; }
        [DisplayName("Customer Name")]
        public string CustomerName { set; get; }
        public string Phone { set; get; }



        [DisplayName("Contact First Name")]
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine1 { get; set; }
    }
}
