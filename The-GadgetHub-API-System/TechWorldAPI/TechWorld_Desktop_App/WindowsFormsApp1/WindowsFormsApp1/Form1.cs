using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form

        
    {
        int count = 0;
        string statement = "to be or not to be that is the question"
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {
            double cm = double.Parse(txtCm.Text);
            double m = cm / 100;
            txtM.Text = m.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double numOne = double.Parse(txtOne.Text);  
            double numTwo = double.Parse(txtTwo.Text);  

            double Multipication = numOne * numTwo; 
            txtResult.Text = Multipication.ToString();
            count++;
            lblTotalCount.Text = count.ToString();
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            double numOne = double.Parse(txtOne.Text);
            double numTwo = double.Parse(txtTwo.Text);  

            double addition = numOne + numTwo;
            txtResult.Text = addition.ToString();
            count++;
            lblTotalCount.Text = count.ToString();
        }

        private void btnSubstraction_Click(object sender, EventArgs e)
        {
            double numOne = double.Parse(txtOne.Text);
            double numTwo = Double.Parse(txtTwo.Text);

            double subtraction = numOne - numTwo;
            txtResult.Text = subtraction.ToString();
            count++;
            lblTotalCount.Text = count.ToString();


        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            double numOne = Double.Parse(txtOne.Text);  
            double numtwo = Double.Parse(txtTwo.Text);

            double Division = numOne / numtwo;
            txtResult.Text = Division.ToString();
            count++;
            lblTotalCount.Text = count.ToString();
        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            double numOne = Double.Parse(txtOne.Text);
            double numtwo = Double.Parse(txtTwo.Text);

            double Percentage = numOne % numtwo;
            txtResult.Text = Percentage.ToString();
            count++;
            lblTotalCount.Text = count.ToString();
        }

        private void txtOne_MouseEnter(object sender, EventArgs e)
        {
            txtOne.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTwo_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
