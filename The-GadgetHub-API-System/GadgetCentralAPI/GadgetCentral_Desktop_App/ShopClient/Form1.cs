using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GadgetCentral_Desktop_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7294/api/Product";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = new JavaScriptSerializer().Deserialize<List<MyItem>>(json);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7294/api/Product";
            HttpClient client = new HttpClient();

            MyItem item = new MyItem
            {
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Stock = int.Parse(txtStock.Text),
                Description = txtDes.Text,
                DeliveryDate = txt_DATE.Text // <-- Added DeliveryDate
            };

            string json = new JavaScriptSerializer().Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Added");
                LoadData();
            }
            else
            {
                MessageBox.Show("Failed to add item");
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                lblID.Text = dgvProducts.Rows[r].Cells[1].Value.ToString();
                txtID.Text = dgvProducts.Rows[r].Cells[1].Value.ToString();
                txtName.Text = dgvProducts.Rows[r].Cells[2].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[r].Cells[3].Value.ToString();
                txtStock.Text = dgvProducts.Rows[r].Cells[4].Value.ToString();
                txtDes.Text = dgvProducts.Rows[r].Cells[5].Value.ToString();
                txt_DATE.Text = dgvProducts.Rows[r].Cells[6].Value.ToString(); // <-- Load DeliveryDate
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please enter Product ID to update");
                return;
            }

            string url = $"https://localhost:7294/api/Product/{txtID.Text}";
            HttpClient client = new HttpClient();

            MyItem item = new MyItem
            {
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Stock = int.Parse(txtStock.Text),
                Description = txtDes.Text,
                DeliveryDate = txt_DATE.Text // <-- Added DeliveryDate
            };

            string json = new JavaScriptSerializer().Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Updated");
                LoadData();
            }
            else
            {
                MessageBox.Show("Failed to update item");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please enter Product ID to delete");
                return;
            }

            string url = $"https://localhost:7294/api/Product/{txtID.Text}";
            HttpClient client = new HttpClient();

            var response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Deleted");
                LoadData();
            }
            else
            {
                MessageBox.Show("Failed to delete item");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                return;
            }

            string url = $"https://localhost:7294/api/Product/{txtID.Text}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var item = new JavaScriptSerializer().Deserialize<MyItem>(json);
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = new List<MyItem> { item };
            }
            else
            {
                MessageBox.Show("Item not found");
            }
        }

        private void btn_SeeAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }

   
}
