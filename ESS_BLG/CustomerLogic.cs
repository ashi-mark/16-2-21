using ESS_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESS_BLG
{
    internal class CustomerLogic : GenericRepository<ESS_DBEntities, customer>
    {
        public override void Add(customer entity)
        {
            var newid = base.Entities.customers.Max(x => x.customerNumber) + 1;
            entity.customerNumber = newid;
            base.Add(entity);
        }

        internal List<customer> GetRiskyCustomers(decimal value)
        {
            if (value < 1 || value > 100)
            {
                throw new Exception("The value must be between 1 and 100");
            }
            List<customer> riskCustomers = new List<customer>();

            var riskyClients = from item in Entities.customers
                               where item.orders.Count > item.payments.Count
                               select item;
            foreach (var item in riskyClients)
            {
                var ordersCnt = item.orders.Count;
                var pmntCnt = item.payments.Count;
                if (IsRisky(value, ordersCnt, pmntCnt))
                {
                    riskCustomers.Add(item);
                }
            }
            return riskCustomers;
        }

        private bool IsRisky(decimal value, int ordersCnt, int pmntCnt)
        {
            var percent = 100 - (pmntCnt * 100 / ordersCnt);
            return percent > value;
        }


    }
}
