using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;//this is connect to API with HTTP
using System.Web.Script.Serialization; //convert objects to Json and Json to objecties.


namespace ShopClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string url = "https://localhost:7155/api/Product";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                var items = read.Result;
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = (new JavaScriptSerializer()).Deserialize<List<Item>>(items);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7155/api/Product";
            HttpClient client = new HttpClient();
            Item item = new Item();
            item.Name = txtName.Text;
            item.Price =decimal.Parse(txtPrice.Text);
            item.Stock = int.Parse(txtStock.Text);
            item.Description = txtDescription.Text;

            string data=(new JavaScriptSerializer()).Serialize(item);
            var request=new StringContent (data, UnicodeEncoding.UTF8,"application/json");
            var response = client.PostAsync(url,request).Result;
            if( response.IsSuccessStatusCode )
            {
                MessageBox.Show("Product added");
                LoadData();
            }
            else
                MessageBox.Show("Fail to add Product");

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           int colum = e.ColumnIndex;
            int row = e.RowIndex;
            if(colum == 0 && row >0 )
                    {
                lblID.Text = dgvProduct.Rows[row].Cells[1].Value.ToString();
                txtName.Text = dgvProduct.Rows[row].Cells[2].Value.ToString();
                txtDescription.Text = dgvProduct.Rows[row].Cells[3].Value.ToString();
                txtStock.Text= dgvProduct.Rows[row].Cells[4].Value.ToString();
                txtPrice.Text= dgvProduct.Rows[row].Cells[5].Value.ToString();

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = lblID.Text;
            string url = "https://localhost:7155/api/Product" + id;
            HttpClient client = new HttpClient();
            Item item = new Item();
            item.Name = txtName.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Stock = int.Parse(txtStock.Text);
            item.Description = txtDescription.Text;

            string data = (new JavaScriptSerializer()).Serialize(item);
            var request = new StringContent(data,
              UnicodeEncoding.UTF8, "application/json");
            var response = client.PutAsync(url, request).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Product Updated");
                LoadData();
            }
            else
                MessageBox.Show("Fail to Update product");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =MessageBox.Show("Are you sure want to delete?","Confirm Delete",       MessageBoxButtons.YesNo, 
               MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string id = lblID.Text;
                string url = "https://localhost:7155/api/Product/" + id;
                HttpClient client = new HttpClient();

                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Product Deleted");
                    LoadData();
                }
                else
                    MessageBox.Show("Fail to peroduct deleted");


            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string url = "https://localhost:7155/api/Product/" + id;
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                var item = read.Result;
                dgvProduct.DataSource = null;
                Item item1 = (new JavaScriptSerializer()).Deserialize<Item>(item);
                List<Item> items = new List<Item>();
                items.Add(item1);
                dgvProduct.DataSource = items;
            }

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
