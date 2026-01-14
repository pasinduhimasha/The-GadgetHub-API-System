using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace TheGadgetHub_Desktop_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class GadgetHubItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7295/api/Product";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                var items = (new JavaScriptSerializer()).Deserialize<List<GadgetHubItem>>(jsonData);
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = items;
            }
            else
            {
                MessageBox.Show("Failed to load data");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7295/api/Product";
            HttpClient client = new HttpClient();
            GadgetHubItem item = new GadgetHubItem
            {
                Name = txtName.Text,
                Description = txtDes.Text
            };

            string jsonData = (new JavaScriptSerializer()).Serialize(item);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Added Successfully");
                LoadData();
            }
            else
            {
                MessageBox.Show("Failed to add item");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Select an item to update.");
                return;
            }

            string url = $"https://localhost:7295/api/Product/{lblID.Text}";
            HttpClient client = new HttpClient();

            GadgetHubItem item = new GadgetHubItem
            {
                Id = int.Parse(lblID.Text),
                Name = txtName.Text,
                Description = txtDes.Text
            };

            string jsonData = (new JavaScriptSerializer()).Serialize(item);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Updated Successfully");
                LoadData();
            }
            else
            {
                MessageBox.Show($"Failed to update item. {response.StatusCode}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Select an item to delete.");
                return;
            }

            string url = $"https://localhost:7295/api/Product/{lblID.Text}";
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Item Deleted Successfully");
                LoadData();
            }
            else
            {
                MessageBox.Show($"Failed to delete item. {response.StatusCode}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Enter an ID to search.");
                return;
            }

            string url = $"https://localhost:7295/api/Product/{txtID.Text}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                var item = (new JavaScriptSerializer()).Deserialize<GadgetHubItem>(jsonData);

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = new List<GadgetHubItem> { item };
            }
            else
            {
                MessageBox.Show("Item not found.");
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                lblID.Text = dgvProducts.Rows[r].Cells["Id"].Value.ToString();
                txtName.Text = dgvProducts.Rows[r].Cells["Name"].Value.ToString();
                txtDes.Text = dgvProducts.Rows[r].Cells["Description"].Value.ToString();
            }
        }

        private void btn_SeeAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Distributor Menu Item Click Events

        private void techWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechWorld cart = new TechWorld();
            cart.Show();
            this.Hide();
        }

        private void electroComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElectroCom cart = new ElectroCom();
            cart.Show();
            this.Hide();
        }

        private void gadgetCentralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GadgetCentral cart = new GadgetCentral();
            cart.Show();
            this.Hide();
        }

        private void teachWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechWorld cart = new TechWorld();
            cart.Show();
            this.Hide();
        }
    }
}
