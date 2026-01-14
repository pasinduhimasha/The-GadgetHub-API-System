using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace TheGadgetHub_Desktop_App
{
    public partial class GadgetCentral : Form
    {
        public GadgetCentral()
        {
            InitializeComponent();
            this.Load += GadgetCentral_Load;
        }

        private void GadgetCentral_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7294/api/Product"; 

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
                    MessageBox.Show("Failed to load data from API.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 cart = new Form1(); // Navigate to cart form
            cart.Show();
            this.Hide();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
