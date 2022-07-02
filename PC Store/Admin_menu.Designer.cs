namespace PC_Store
{
    partial class Admin_menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.users = new System.Windows.Forms.Button();
            this.Products = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin menu";
            // 
            // users
            // 
            this.users.BackColor = System.Drawing.Color.GreenYellow;
            this.users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.users.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users.Location = new System.Drawing.Point(51, 105);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(129, 63);
            this.users.TabIndex = 1;
            this.users.Text = "Users";
            this.users.UseVisualStyleBackColor = false;
            this.users.Click += new System.EventHandler(this.users_Click);
            // 
            // Products
            // 
            this.Products.BackColor = System.Drawing.Color.GreenYellow;
            this.Products.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Products.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Products.Location = new System.Drawing.Point(344, 105);
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(129, 63);
            this.Products.TabIndex = 2;
            this.Products.Text = "Products";
            this.Products.UseVisualStyleBackColor = false;
            this.Products.Click += new System.EventHandler(this.Products_Click);
            // 
            // back_button
            // 
            this.back_button.BackColor = System.Drawing.Color.GreenYellow;
            this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_button.Location = new System.Drawing.Point(208, 319);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(115, 63);
            this.back_button.TabIndex = 3;
            this.back_button.Text = "back";
            this.back_button.UseVisualStyleBackColor = false;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // Admin_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(538, 450);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.Products);
            this.Controls.Add(this.users);
            this.Controls.Add(this.label1);
            this.Name = "Admin_menu";
            this.Text = "Admin_menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button users;
        private System.Windows.Forms.Button Products;
        private System.Windows.Forms.Button back_button;
    }
}