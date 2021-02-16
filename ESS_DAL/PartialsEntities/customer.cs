using ESS_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESS_DAL
{
    public partial class customer
    {
        
        public OM_Customer GetOMCustomer()
        {
            return new OM_Customer
            {
                customerNumber = this.customerNumber,
                CustomerName = this.customerName,
                Phone = this.phone,
                ContactLastName = this.contactLastName,
                ContactFirstName = this.contactFirstName,
                City = this.city,
                Country = this.country,
                AddressLine1 = this.addressLine1

            };

        }
        public customer(OM_Customer m_Customer)
        {
            SetData(m_Customer);
        }

        public void SetData(OM_Customer m_Customer)
        {
            this.customerName = m_Customer.CustomerName;
            this.phone = m_Customer.Phone;
            this.contactFirstName = m_Customer.ContactFirstName;
            this.contactLastName = m_Customer.ContactLastName;
            this.city = m_Customer.City;
            this.country = m_Customer.Country;
            this.addressLine1 = m_Customer.AddressLine1;
        }
    }
}
