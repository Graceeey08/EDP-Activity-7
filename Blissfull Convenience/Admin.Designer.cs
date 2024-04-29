namespace Blissfull_Convenience
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.updatebtn = new System.Windows.Forms.Button();
            this.Addnewbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.adminbtn = new System.Windows.Forms.Button();
            this.productbtn = new System.Windows.Forms.Button();
            this.ordersbtn = new System.Windows.Forms.Button();
            this.customerbtn = new System.Windows.Forms.Button();
            this.orderitembtn = new System.Windows.Forms.Button();
            this.employeebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Adminid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Confirmpass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.updatebtn.ForeColor = System.Drawing.Color.White;
            this.updatebtn.Location = new System.Drawing.Point(682, 167);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.updatebtn.Size = new System.Drawing.Size(98, 32);
            this.updatebtn.TabIndex = 27;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // Addnewbtn
            // 
            this.Addnewbtn.BackColor = System.Drawing.Color.ForestGreen;
            this.Addnewbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Addnewbtn.ForeColor = System.Drawing.Color.White;
            this.Addnewbtn.Location = new System.Drawing.Point(523, 167);
            this.Addnewbtn.Name = "Addnewbtn";
            this.Addnewbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Addnewbtn.Size = new System.Drawing.Size(142, 32);
            this.Addnewbtn.TabIndex = 26;
            this.Addnewbtn.Text = "Add New Admin";
            this.Addnewbtn.UseVisualStyleBackColor = false;
            this.Addnewbtn.Click += new System.EventHandler(this.Addnewbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(759, 239);
            this.dataGridView1.TabIndex = 25;
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
            this.panel1.TabIndex = 24;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Admin ID";
            // 
            // Adminid
            // 
            this.Adminid.Location = new System.Drawing.Point(22, 97);
            this.Adminid.Name = "Adminid";
            this.Adminid.Size = new System.Drawing.Size(63, 20);
            this.Adminid.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(238, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(102, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Username";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(241, 97);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(111, 20);
            this.password.TabIndex = 48;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(105, 97);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(111, 20);
            this.username.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(376, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Confirm Password";
            // 
            // Confirmpass
            // 
            this.Confirmpass.Location = new System.Drawing.Point(379, 97);
            this.Confirmpass.Name = "Confirmpass";
            this.Confirmpass.Size = new System.Drawing.Size(111, 20);
            this.Confirmpass.TabIndex = 53;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Blissfull_Convenience.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Confirmpass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Adminid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.Addnewbtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Blissful Convenience";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button Addnewbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button adminbtn;
        private System.Windows.Forms.Button productbtn;
        private System.Windows.Forms.Button ordersbtn;
        private System.Windows.Forms.Button customerbtn;
        private System.Windows.Forms.Button orderitembtn;
        private System.Windows.Forms.Button employeebtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Adminid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Confirmpass;
    }
}