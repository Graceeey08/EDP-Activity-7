namespace Blissfull_Convenience
{
    partial class order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(order));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminbtn = new System.Windows.Forms.Button();
            this.productbtn = new System.Windows.Forms.Button();
            this.ordersbtn = new System.Windows.Forms.Button();
            this.customerbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.orderitembtn = new System.Windows.Forms.Button();
            this.employeebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(759, 315);
            this.dataGridView1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.adminbtn);
            this.panel1.Controls.Add(this.productbtn);
            this.panel1.Controls.Add(this.ordersbtn);
            this.panel1.Controls.Add(this.customerbtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.orderitembtn);
            this.panel1.Controls.Add(this.employeebtn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 49);
            this.panel1.TabIndex = 4;
            // 
            // adminbtn
            // 
            this.adminbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.adminbtn.Location = new System.Drawing.Point(723, 15);
            this.adminbtn.Name = "adminbtn";
            this.adminbtn.Size = new System.Drawing.Size(54, 25);
            this.adminbtn.TabIndex = 18;
            this.adminbtn.Text = "Admin";
            this.adminbtn.UseVisualStyleBackColor = true;
            this.adminbtn.Click += new System.EventHandler(this.adminbtn_Click);
            // 
            // productbtn
            // 
            this.productbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.productbtn.Location = new System.Drawing.Point(631, 15);
            this.productbtn.Name = "productbtn";
            this.productbtn.Size = new System.Drawing.Size(86, 25);
            this.productbtn.TabIndex = 17;
            this.productbtn.Text = "Product";
            this.productbtn.UseVisualStyleBackColor = true;
            this.productbtn.Click += new System.EventHandler(this.productbtn_Click);
            // 
            // ordersbtn
            // 
            this.ordersbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ordersbtn.Location = new System.Drawing.Point(539, 15);
            this.ordersbtn.Name = "ordersbtn";
            this.ordersbtn.Size = new System.Drawing.Size(86, 25);
            this.ordersbtn.TabIndex = 16;
            this.ordersbtn.Text = "Orders";
            this.ordersbtn.UseVisualStyleBackColor = true;
            this.ordersbtn.Click += new System.EventHandler(this.ordersbtn_Click);
            // 
            // customerbtn
            // 
            this.customerbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customerbtn.Location = new System.Drawing.Point(263, 15);
            this.customerbtn.Name = "customerbtn";
            this.customerbtn.Size = new System.Drawing.Size(86, 25);
            this.customerbtn.TabIndex = 13;
            this.customerbtn.Text = "Customers";
            this.customerbtn.UseVisualStyleBackColor = true;
            this.customerbtn.Click += new System.EventHandler(this.customerbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Management";
            // 
            // orderitembtn
            // 
            this.orderitembtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.orderitembtn.Location = new System.Drawing.Point(447, 15);
            this.orderitembtn.Name = "orderitembtn";
            this.orderitembtn.Size = new System.Drawing.Size(86, 25);
            this.orderitembtn.TabIndex = 15;
            this.orderitembtn.Text = "Order Items";
            this.orderitembtn.UseVisualStyleBackColor = true;
            this.orderitembtn.Click += new System.EventHandler(this.orderitembtn_Click);
            // 
            // employeebtn
            // 
            this.employeebtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.employeebtn.Location = new System.Drawing.Point(355, 15);
            this.employeebtn.Name = "employeebtn";
            this.employeebtn.Size = new System.Drawing.Size(86, 25);
            this.employeebtn.TabIndex = 14;
            this.employeebtn.Text = "Employees";
            this.employeebtn.UseVisualStyleBackColor = true;
            this.employeebtn.Click += new System.EventHandler(this.employeebtn_Click);
            // 
            // order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Blissfull_Convenience.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "order";
            this.Text = "Blissfull Convenience";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button adminbtn;
        private System.Windows.Forms.Button productbtn;
        private System.Windows.Forms.Button ordersbtn;
        private System.Windows.Forms.Button customerbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button orderitembtn;
        private System.Windows.Forms.Button employeebtn;
    }
}