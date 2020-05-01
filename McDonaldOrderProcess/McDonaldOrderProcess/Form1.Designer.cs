namespace McDonaldOrderProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BTN_Order = new System.Windows.Forms.Button();
            this.LBL_OrderNo = new System.Windows.Forms.Label();
            this.BTN_ZingerBurger = new System.Windows.Forms.Button();
            this.BTN_Wings = new System.Windows.Forms.Button();
            this.BTN_BeefBurger = new System.Windows.Forms.Button();
            this.BTN_Broast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Order
            // 
            this.BTN_Order.BackColor = System.Drawing.Color.Maroon;
            this.BTN_Order.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Order.BackgroundImage")));
            this.BTN_Order.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.BTN_Order.FlatAppearance.BorderSize = 2;
            this.BTN_Order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Order.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Order.ForeColor = System.Drawing.Color.Gold;
            this.BTN_Order.Location = new System.Drawing.Point(53, 325);
            this.BTN_Order.Name = "BTN_Order";
            this.BTN_Order.Size = new System.Drawing.Size(635, 46);
            this.BTN_Order.TabIndex = 0;
            this.BTN_Order.Text = "Order";
            this.BTN_Order.UseVisualStyleBackColor = false;
            this.BTN_Order.Click += new System.EventHandler(this.button1_Click);
            // 
            // LBL_OrderNo
            // 
            this.LBL_OrderNo.AutoSize = true;
            this.LBL_OrderNo.BackColor = System.Drawing.Color.Transparent;
            this.LBL_OrderNo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_OrderNo.ForeColor = System.Drawing.Color.Gold;
            this.LBL_OrderNo.Location = new System.Drawing.Point(316, 30);
            this.LBL_OrderNo.Name = "LBL_OrderNo";
            this.LBL_OrderNo.Size = new System.Drawing.Size(110, 29);
            this.LBL_OrderNo.TabIndex = 5;
            this.LBL_OrderNo.Text = "OrderNO.";
            // 
            // BTN_ZingerBurger
            // 
            this.BTN_ZingerBurger.BackColor = System.Drawing.Color.Gold;
            this.BTN_ZingerBurger.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_ZingerBurger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.BTN_ZingerBurger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ZingerBurger.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ZingerBurger.ForeColor = System.Drawing.Color.Maroon;
            this.BTN_ZingerBurger.Location = new System.Drawing.Point(53, 95);
            this.BTN_ZingerBurger.Name = "BTN_ZingerBurger";
            this.BTN_ZingerBurger.Size = new System.Drawing.Size(168, 52);
            this.BTN_ZingerBurger.TabIndex = 1;
            this.BTN_ZingerBurger.Text = "Zinger Burger";
            this.BTN_ZingerBurger.UseVisualStyleBackColor = false;
            this.BTN_ZingerBurger.Click += new System.EventHandler(this.BTN_ZingerBurger_Click);
            // 
            // BTN_Wings
            // 
            this.BTN_Wings.BackColor = System.Drawing.Color.Gold;
            this.BTN_Wings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_Wings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.BTN_Wings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Wings.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Wings.ForeColor = System.Drawing.Color.Maroon;
            this.BTN_Wings.Location = new System.Drawing.Point(53, 211);
            this.BTN_Wings.Name = "BTN_Wings";
            this.BTN_Wings.Size = new System.Drawing.Size(168, 56);
            this.BTN_Wings.TabIndex = 2;
            this.BTN_Wings.Text = "Chicken Wings";
            this.BTN_Wings.UseVisualStyleBackColor = false;
            this.BTN_Wings.Click += new System.EventHandler(this.BTN_Wings_Click);
            // 
            // BTN_BeefBurger
            // 
            this.BTN_BeefBurger.BackColor = System.Drawing.Color.Gold;
            this.BTN_BeefBurger.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_BeefBurger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.BTN_BeefBurger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_BeefBurger.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_BeefBurger.ForeColor = System.Drawing.Color.Maroon;
            this.BTN_BeefBurger.Location = new System.Drawing.Point(520, 211);
            this.BTN_BeefBurger.Name = "BTN_BeefBurger";
            this.BTN_BeefBurger.Size = new System.Drawing.Size(168, 56);
            this.BTN_BeefBurger.TabIndex = 3;
            this.BTN_BeefBurger.Text = "Beef Burger";
            this.BTN_BeefBurger.UseVisualStyleBackColor = false;
            this.BTN_BeefBurger.Click += new System.EventHandler(this.BTN_BeefBurger_Click);
            // 
            // BTN_Broast
            // 
            this.BTN_Broast.BackColor = System.Drawing.Color.Gold;
            this.BTN_Broast.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_Broast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.BTN_Broast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Broast.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Broast.ForeColor = System.Drawing.Color.Maroon;
            this.BTN_Broast.Location = new System.Drawing.Point(520, 95);
            this.BTN_Broast.Name = "BTN_Broast";
            this.BTN_Broast.Size = new System.Drawing.Size(168, 52);
            this.BTN_Broast.TabIndex = 4;
            this.BTN_Broast.Text = "Broast";
            this.BTN_Broast.UseVisualStyleBackColor = false;
            this.BTN_Broast.Click += new System.EventHandler(this.BTN_Broast_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(750, 393);
            this.Controls.Add(this.LBL_OrderNo);
            this.Controls.Add(this.BTN_Broast);
            this.Controls.Add(this.BTN_BeefBurger);
            this.Controls.Add(this.BTN_Wings);
            this.Controls.Add(this.BTN_ZingerBurger);
            this.Controls.Add(this.BTN_Order);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Order;
        private System.Windows.Forms.Label LBL_OrderNo;
        private System.Windows.Forms.Button BTN_ZingerBurger;
        private System.Windows.Forms.Button BTN_Wings;
        private System.Windows.Forms.Button BTN_BeefBurger;
        private System.Windows.Forms.Button BTN_Broast;
    }
}

