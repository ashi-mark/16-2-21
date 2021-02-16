using ESS_BLG;
using ESS_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESS_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadCustomers(bl.GetCustomers());
        }
        BLayer bl = new BLayer();
        OM_Customer currentCustomer;
        private void LoadCustomers(List<OM_Customer> list)
        {

            // var list = d.GetCustomers();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = list;
            label1.Text = list.Count.ToString();

        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                currentCustomer = dataGridView1.SelectedRows[0].DataBoundItem as OM_Customer;
                textBoxAddressLine1.Text = currentCustomer.AddressLine1;
                textBoxCity.Text = currentCustomer.City;
                textBoxContactFirstName.Text = currentCustomer.ContactFirstName;
                textBoxContactLastName.Text = currentCustomer.ContactLastName;
                textBoxCountry.Text = currentCustomer.Country;
                textBoxCustomerName.Text = currentCustomer.CustomerName;
                textBoxPhone.Text = currentCustomer.Phone;

            }
        }

        private void BtnAdd_click(object sender, EventArgs e)
        {
            var om = new OM_Customer
            {
                AddressLine1 = textBoxAddressLine1.Text,
                City = textBoxCity.Text,
                ContactFirstName = textBoxContactFirstName.Text,
                ContactLastName = textBoxContactLastName.Text,
                Country = textBoxCountry.Text,
                CustomerName = textBoxCustomerName.Text,
                Phone = textBoxPhone.Text

            };
          
            bl.AddNewCustomer(om);
            LoadCustomers(bl.GetCustomers());


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var om = new OM_Customer
            {
                AddressLine1 = textBoxAddressLine1.Text,
                City = textBoxCity.Text,
                ContactFirstName = textBoxContactFirstName.Text,
                ContactLastName = textBoxContactLastName.Text,
                Country = textBoxCountry.Text,
                CustomerName = textBoxCustomerName.Text,
                Phone = textBoxPhone.Text,
                customerNumber = currentCustomer.customerNumber//TODO
            };
          
            bl.EditCustomer(om);
            LoadCustomers(bl.GetCustomers());

        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoadCustomers(bl.GetCustomers());

        }

        private void buttonriskyclient_Click(object sender, EventArgs e)
        {
         
            LoadCustomers(bl.GetRiskyCustomers(nudRiskyVal.Value));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var txbxes = panel1.Controls.OfType<TextBox>();
            foreach (var item in txbxes)
            {
                item.Text = "";
            }
        }
    }
}
