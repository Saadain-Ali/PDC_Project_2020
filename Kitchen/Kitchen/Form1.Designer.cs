namespace Kitchen
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
            this.txt_orders = new System.Windows.Forms.TextBox();
            this.lbl_orders = new System.Windows.Forms.Label();
            this.txt_completed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_completed = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_orders
            // 
            this.txt_orders.BackColor = System.Drawing.Color.White;
            this.txt_orders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_orders.ForeColor = System.Drawing.Color.Gold;
            this.txt_orders.Location = new System.Drawing.Point(206, 46);
            this.txt_orders.Margin = new System.Windows.Forms.Padding(2);
            this.txt_orders.Multiline = true;
            this.txt_orders.Name = "txt_orders";
            this.txt_orders.ReadOnly = true;
            this.txt_orders.Size = new System.Drawing.Size(221, 306);
            this.txt_orders.TabIndex = 0;
            // 
            // lbl_orders
            // 
            this.lbl_orders.AutoSize = true;
            this.lbl_orders.BackColor = System.Drawing.Color.Transparent;
            this.lbl_orders.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orders.ForeColor = System.Drawing.Color.Gold;
            this.lbl_orders.Location = new System.Drawing.Point(268, 15);
            this.lbl_orders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_orders.Name = "lbl_orders";
            this.lbl_orders.Size = new System.Drawing.Size(82, 29);
            this.lbl_orders.TabIndex = 1;
            this.lbl_orders.Text = "Orders";
            // 
            // txt_completed
            // 
            this.txt_completed.BackColor = System.Drawing.Color.DarkGray;
            this.txt_completed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_completed.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_completed.ForeColor = System.Drawing.Color.Gold;
            this.txt_completed.Location = new System.Drawing.Point(22, 132);
            this.txt_completed.Margin = new System.Windows.Forms.Padding(2);
            this.txt_completed.Name = "txt_completed";
            this.txt_completed.Size = new System.Drawing.Size(170, 25);
            this.txt_completed.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(5, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Completed Order";
            // 
            // btn_completed
            // 
            this.btn_completed.BackColor = System.Drawing.Color.Gold;
            this.btn_completed.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btn_completed.FlatAppearance.BorderSize = 2;
            this.btn_completed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_completed.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_completed.ForeColor = System.Drawing.Color.Maroon;
            this.btn_completed.Location = new System.Drawing.Point(26, 176);
            this.btn_completed.Margin = new System.Windows.Forms.Padding(2);
            this.btn_completed.Name = "btn_completed";
            this.btn_completed.Size = new System.Drawing.Size(154, 54);
            this.btn_completed.TabIndex = 4;
            this.btn_completed.Text = "Submit";
            this.btn_completed.UseVisualStyleBackColor = false;
            this.btn_completed.Click += new System.EventHandler(this.btn_completed_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(53, 320);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "connect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kitchen.Properties.Resources.background_yellow_paint;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(463, 377);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_completed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_completed);
            this.Controls.Add(this.lbl_orders);
            this.Controls.Add(this.txt_orders);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Kitchen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_orders;
        private System.Windows.Forms.Label lbl_orders;
        private System.Windows.Forms.TextBox txt_completed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_completed;
        private System.Windows.Forms.Button button1;
    }
}

