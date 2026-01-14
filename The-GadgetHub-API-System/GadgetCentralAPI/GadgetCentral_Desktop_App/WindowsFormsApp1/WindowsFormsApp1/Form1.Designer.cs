namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCm = new System.Windows.Forms.TextBox();
            this.txtM = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numOne = new System.Windows.Forms.Label();
            this.numTwo = new System.Windows.Forms.Label();
            this.txtOne = new System.Windows.Forms.TextBox();
            this.txtTwo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnAddition = new System.Windows.Forms.Button();
            this.btnSubstraction = new System.Windows.Forms.Button();
            this.btnMultipication = new System.Windows.Forms.Button();
            this.btnDivision = new System.Windows.Forms.Button();
            this.btnPercentage = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCm
            // 
            this.txtCm.Location = new System.Drawing.Point(272, 87);
            this.txtCm.Name = "txtCm";
            this.txtCm.Size = new System.Drawing.Size(139, 20);
            this.txtCm.TabIndex = 0;
            // 
            // txtM
            // 
            this.txtM.Location = new System.Drawing.Point(272, 136);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(139, 20);
            this.txtM.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter distance in CM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Distance in M";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // numOne
            // 
            this.numOne.AutoSize = true;
            this.numOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOne.Location = new System.Drawing.Point(93, 231);
            this.numOne.Name = "numOne";
            this.numOne.Size = new System.Drawing.Size(85, 13);
            this.numOne.TabIndex = 5;
            this.numOne.Text = "Number One :";
            this.numOne.Click += new System.EventHandler(this.label3_Click);
            // 
            // numTwo
            // 
            this.numTwo.AutoSize = true;
            this.numTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTwo.Location = new System.Drawing.Point(92, 265);
            this.numTwo.Name = "numTwo";
            this.numTwo.Size = new System.Drawing.Size(86, 13);
            this.numTwo.TabIndex = 6;
            this.numTwo.Text = "Number Two :";
            // 
            // txtOne
            // 
            this.txtOne.Location = new System.Drawing.Point(272, 230);
            this.txtOne.Name = "txtOne";
            this.txtOne.Size = new System.Drawing.Size(139, 20);
            this.txtOne.TabIndex = 7;
            this.txtOne.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtOne.MouseEnter += new System.EventHandler(this.txtOne_MouseEnter);
            // 
            // txtTwo
            // 
            this.txtTwo.AccessibleName = "txtTwo";
            this.txtTwo.Location = new System.Drawing.Point(272, 265);
            this.txtTwo.Name = "txtTwo";
            this.txtTwo.Size = new System.Drawing.Size(139, 20);
            this.txtTwo.TabIndex = 8;
            this.txtTwo.TextChanged += new System.EventHandler(this.txtTwo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Result :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Number of calculations done :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(272, 352);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(139, 20);
            this.txtResult.TabIndex = 11;
            this.txtResult.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAddition
            // 
            this.btnAddition.Location = new System.Drawing.Point(272, 291);
            this.btnAddition.Name = "btnAddition";
            this.btnAddition.Size = new System.Drawing.Size(30, 37);
            this.btnAddition.TabIndex = 12;
            this.btnAddition.Text = "+";
            this.btnAddition.UseVisualStyleBackColor = true;
            this.btnAddition.Click += new System.EventHandler(this.btnAddition_Click);
            // 
            // btnSubstraction
            // 
            this.btnSubstraction.Location = new System.Drawing.Point(308, 291);
            this.btnSubstraction.Name = "btnSubstraction";
            this.btnSubstraction.Size = new System.Drawing.Size(30, 37);
            this.btnSubstraction.TabIndex = 13;
            this.btnSubstraction.Text = "-";
            this.btnSubstraction.UseVisualStyleBackColor = true;
            this.btnSubstraction.Click += new System.EventHandler(this.btnSubstraction_Click);
            // 
            // btnMultipication
            // 
            this.btnMultipication.Location = new System.Drawing.Point(344, 291);
            this.btnMultipication.Name = "btnMultipication";
            this.btnMultipication.Size = new System.Drawing.Size(30, 37);
            this.btnMultipication.TabIndex = 14;
            this.btnMultipication.Text = "*";
            this.btnMultipication.UseVisualStyleBackColor = true;
            this.btnMultipication.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnDivision
            // 
            this.btnDivision.Location = new System.Drawing.Point(381, 291);
            this.btnDivision.Name = "btnDivision";
            this.btnDivision.Size = new System.Drawing.Size(30, 37);
            this.btnDivision.TabIndex = 15;
            this.btnDivision.Text = "/";
            this.btnDivision.UseVisualStyleBackColor = true;
            this.btnDivision.Click += new System.EventHandler(this.btnDivision_Click);
            // 
            // btnPercentage
            // 
            this.btnPercentage.Location = new System.Drawing.Point(417, 291);
            this.btnPercentage.Name = "btnPercentage";
            this.btnPercentage.Size = new System.Drawing.Size(30, 37);
            this.btnPercentage.TabIndex = 16;
            this.btnPercentage.Text = "%";
            this.btnPercentage.UseVisualStyleBackColor = true;
            this.btnPercentage.Click += new System.EventHandler(this.btnPercentage_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(278, 397);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(13, 13);
            this.lblTotalCount.TabIndex = 17;
            this.lblTotalCount.Text = "0";
            this.lblTotalCount.Click += new System.EventHandler(this.label7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnPercentage);
            this.Controls.Add(this.btnDivision);
            this.Controls.Add(this.btnMultipication);
            this.Controls.Add(this.btnSubstraction);
            this.Controls.Add(this.btnAddition);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTwo);
            this.Controls.Add(this.txtOne);
            this.Controls.Add(this.numTwo);
            this.Controls.Add(this.numOne);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtM);
            this.Controls.Add(this.txtCm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCm;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numOne;
        private System.Windows.Forms.Label numTwo;
        private System.Windows.Forms.TextBox txtOne;
        private System.Windows.Forms.TextBox txtTwo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnAddition;
        private System.Windows.Forms.Button btnSubstraction;
        private System.Windows.Forms.Button btnMultipication;
        private System.Windows.Forms.Button btnDivision;
        private System.Windows.Forms.Button btnPercentage;
        private System.Windows.Forms.Label lblTotalCount;
    }
}

