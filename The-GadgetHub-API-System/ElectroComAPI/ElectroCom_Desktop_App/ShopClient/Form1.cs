using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http; //This is to call Http Client
using System.Web.Script.Serialization;

namespace ElectroCom_Desktop_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7292/api/Product";
            HttpClient client = new HttpClient();
            MyItem item = new MyItem();
            item.Name = txtName.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Stock = int.Parse(txtStock.Text);
            item.Description = txtDes.Text;

            // Add DeliveryDate from txt_DATE textbox
            item.DeliveryDate = txt_DATE.Text;

            //Converting the object to string format
            string info = (new JavaScriptSerializer()).Serialize(item);
            var content = new StringContent(info, UnicodeEncoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Added");
                LoadData();

            }
            else
                MessageBox.Show("Fail to add item");

        }
        private void LoadData()
        {
            string url = "https://localhost:7292/api/Product";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response
                    .Content.ReadAsStringAsync();
                read.Wait();
                var data = read.Result;
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = (new JavaScriptSerializer()).Deserialize<List<MyItem>>(data);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;
            if (c == 0 && r >= 0)
            {
                lblID.Text = dgvProducts.Rows[r].Cells[1].Value.ToString();
                txtName.Text = dgvProducts.Rows[r].Cells[2].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[r].Cells[3].Value.ToString();
                txtStock.Text = dgvProducts.Rows[r].Cells[4].Value.ToString();
                txtDes.Text = dgvProducts.Rows[r].Cells[5].Value.ToString();

                // Load DeliveryDate string into txt_DATE textbox
                txt_DATE.Text = dgvProducts.Rows[r].Cells[6].Value.ToString();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7292/api/Product/" + lblID.Text;
            HttpClient client = new HttpClient();
            MyItem item = new MyItem();
            item.Name = txtName.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Stock = int.Parse(txtStock.Text);
            item.Description = txtDes.Text;

            // Set DeliveryDate from txt_DATE textbox
            item.DeliveryDate = txt_DATE.Text;

            string info = (new JavaScriptSerializer()).Serialize(item);
            var content = new StringContent(info, UnicodeEncoding.UTF8, "application/json");
            var response = client.PutAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Updated");
                LoadData();
            }
            else
                MessageBox.Show("Fail to update item");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string url = "https://localhost:7292/api/Product/" + lblID.Text;
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Deleted");
                LoadData();
            }
            else
                MessageBox.Show("Fail to delete item");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {

                return;
            }

            string url = "https://localhost:7292/api/Product/" + txtID.Text;
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                var data = read.Result;
                var item = (new JavaScriptSerializer()).Deserialize<MyItem>(data);
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = new List<MyItem> { item };
            }
            else
            {
                MessageBox.Show("Item not found");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_SeeAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }

   
}
