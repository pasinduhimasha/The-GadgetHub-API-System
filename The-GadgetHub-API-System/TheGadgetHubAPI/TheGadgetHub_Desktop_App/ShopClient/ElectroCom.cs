using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace TheGadgetHub_Desktop_App
{
    public partial class ElectroCom : Form
    {
        public ElectroCom()
        {
            InitializeComponent();
            this.Load += ElectroCom_Load;
        }

        private void ElectroCom_Load(object sender, EventArgs e)
        {
            LoadData(); // Load items on form load
        }

        private void LoadData()
        {
            string url = "https://localhost:7292/api/Product"; // <-- Use your actual API URL

            try
            {
                HttpClient client = new HttpClient();
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    var data = read.Result;

                    var itemList = new JavaScriptSerializer().Deserialize<List<DistributorItem>>(data);
                    dgvProducts.DataSource = null;
                    dgvProducts.DataSource = itemList;
                }
                else
                {
                    MessageBox.Show("Failed to load product data from API.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle grid clicks here if needed
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            Form1 cart = new Form1(); // Or whatever your cart form is
            cart.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 cart = new Form1();
            cart.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
