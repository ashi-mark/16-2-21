
using ESS_DAL;
using ESS_Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESS_BLG
{
    public class BLayer
    {
       
        public List<OM_Customer> GetCustomers()
        {
            using (var ctx = new ESS_DBEntities())
            {
                CustomerLogic clog = new CustomerLogic();
                var qlog = from item in clog.GetAll()
                           select item;
                var list = qlog.ToList().Select(x => x.GetOMCustomer()).ToList();
                return list;

            }
        }

        public void AddNewCustomer(OM_Customer oM_Customer)
        {
            CustomerLogic clog = new CustomerLogic();
            var newCustomer = new customer(oM_Customer);
            clog.Add(newCustomer);
            clog.Save();

        }

        public void EditCustomer(OM_Customer oM_Customer)
        {
            CustomerLogic clog = new CustomerLogic();
            var existingCustomer = clog.FindBy(x => x.customerNumber == oM_Customer.customerNumber).SingleOrDefault();
            existingCustomer.SetData(oM_Customer);
            clog.Edit(existingCustomer);
            clog.Save();

        }

        public List<OM_Customer> GetRiskyCustomers(decimal riskValue)
        {
            CustomerLogic clog = new CustomerLogic();

            var rCstmr = clog.GetRiskyCustomers(riskValue);
            return rCstmr.Select(x => x.GetOMCustomer()).ToList();


        }
    }
}