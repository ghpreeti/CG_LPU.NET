namespace WinDisconArchDemo
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
            this.Lbl_prodID = new System.Windows.Forms.Label();
            this.Lbl_ProdName = new System.Windows.Forms.Label();
            this.Lbl_Price = new System.Windows.Forms.Label();
            this.Lbl_Desc = new System.Windows.Forms.Label();
            this.txt_prodId = new System.Windows.Forms.TextBox();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_prodName = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.btn_addProd = new System.Windows.Forms.Button();
            this.btn_UpdateProd = new System.Windows.Forms.Button();
            this.btn_deleteProd = new System.Windows.Forms.Button();
            this.btn_searchProd = new System.Windows.Forms.Button();
            this.btn_showProd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_prodID
            // 
            this.Lbl_prodID.AutoSize = true;
            this.Lbl_prodID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_prodID.Location = new System.Drawing.Point(70, 67);
            this.Lbl_prodID.Name = "Lbl_prodID";
            this.Lbl_prodID.Size = new System.Drawing.Size(85, 29);
            this.Lbl_prodID.TabIndex = 0;
            this.Lbl_prodID.Text = "ProdId\r\n";
            // 
            // Lbl_ProdName
            // 
            this.Lbl_ProdName.AutoSize = true;
            this.Lbl_ProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ProdName.Location = new System.Drawing.Point(70, 128);
            this.Lbl_ProdName.Name = "Lbl_ProdName";
            this.Lbl_ProdName.Size = new System.Drawing.Size(130, 29);
            this.Lbl_ProdName.TabIndex = 1;
            this.Lbl_ProdName.Text = "ProdName";
            // 
            // Lbl_Price
            // 
            this.Lbl_Price.AutoSize = true;
            this.Lbl_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Price.Location = new System.Drawing.Point(70, 184);
            this.Lbl_Price.Name = "Lbl_Price";
            this.Lbl_Price.Size = new System.Drawing.Size(69, 29);
            this.Lbl_Price.TabIndex = 2;
            this.Lbl_Price.Text = "Price";
            // 
            // Lbl_Desc
            // 
            this.Lbl_Desc.AutoSize = true;
            this.Lbl_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Desc.Location = new System.Drawing.Point(70, 242);
            this.Lbl_Desc.Name = "Lbl_Desc";
            this.Lbl_Desc.Size = new System.Drawing.Size(135, 29);
            this.Lbl_Desc.TabIndex = 3;
            this.Lbl_Desc.Text = "Description";
            // 
            // txt_prodId
            // 
            this.txt_prodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_prodId.Location = new System.Drawing.Point(233, 64);
            this.txt_prodId.Name = "txt_prodId";
            this.txt_prodId.Size = new System.Drawing.Size(150, 35);
            this.txt_prodId.TabIndex = 4;
            // 
            // txt_price
            // 
            this.txt_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.Location = new System.Drawing.Point(233, 184);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(150, 35);
            this.txt_price.TabIndex = 5;
            // 
            // txt_prodName
            // 
            this.txt_prodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_prodName.Location = new System.Drawing.Point(233, 122);
            this.txt_prodName.Name = "txt_prodName";
            this.txt_prodName.Size = new System.Drawing.Size(150, 35);
            this.txt_prodName.TabIndex = 6;
            // 
            // txt_description
            // 
            this.txt_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.Location = new System.Drawing.Point(233, 239);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(150, 119);
            this.txt_description.TabIndex = 7;
            // 
            // btn_addProd
            // 
            this.btn_addProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addProd.Location = new System.Drawing.Point(57, 399);
            this.btn_addProd.Name = "btn_addProd";
            this.btn_addProd.Size = new System.Drawing.Size(125, 45);
            this.btn_addProd.TabIndex = 8;
            this.btn_addProd.Text = "Add";
            this.btn_addProd.UseVisualStyleBackColor = true;
            // 
            // btn_UpdateProd
            // 
            this.btn_UpdateProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateProd.Location = new System.Drawing.Point(233, 399);
            this.btn_UpdateProd.Name = "btn_UpdateProd";
            this.btn_UpdateProd.Size = new System.Drawing.Size(125, 45);
            this.btn_UpdateProd.TabIndex = 9;
            this.btn_UpdateProd.Text = "Update";
            this.btn_UpdateProd.UseVisualStyleBackColor = true;
            // 
            // btn_deleteProd
            // 
            this.btn_deleteProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteProd.Location = new System.Drawing.Point(408, 399);
            this.btn_deleteProd.Name = "btn_deleteProd";
            this.btn_deleteProd.Size = new System.Drawing.Size(125, 45);
            this.btn_deleteProd.TabIndex = 10;
            this.btn_deleteProd.Text = "Delete";
            this.btn_deleteProd.UseVisualStyleBackColor = true;
            // 
            // btn_searchProd
            // 
            this.btn_searchProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_searchProd.Location = new System.Drawing.Point(592, 399);
            this.btn_searchProd.Name = "btn_searchProd";
            this.btn_searchProd.Size = new System.Drawing.Size(125, 45);
            this.btn_searchProd.TabIndex = 11;
            this.btn_searchProd.Text = "Search";
            this.btn_searchProd.UseVisualStyleBackColor = true;
            // 
            // btn_showProd
            // 
            this.btn_showProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_showProd.Location = new System.Drawing.Point(784, 399);
            this.btn_showProd.Name = "btn_showProd";
            this.btn_showProd.Size = new System.Drawing.Size(125, 45);
            this.btn_showProd.TabIndex = 12;
            this.btn_showProd.Text = "Show";
            this.btn_showProd.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(436, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(535, 298);
            this.dataGridView1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(548, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "प्रथम";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(660, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 28);
            this.button2.TabIndex = 15;
            this.button2.Text = "अगला";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(767, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 28);
            this.button3.TabIndex = 16;
            this.button3.Text = "पिछला";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(857, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 28);
            this.button4.TabIndex = 17;
            this.button4.Text = "अंतिम";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 470);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_showProd);
            this.Controls.Add(this.btn_searchProd);
            this.Controls.Add(this.btn_deleteProd);
            this.Controls.Add(this.btn_UpdateProd);
            this.Controls.Add(this.btn_addProd);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.txt_prodName);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.txt_prodId);
            this.Controls.Add(this.Lbl_Desc);
            this.Controls.Add(this.Lbl_Price);
            this.Controls.Add(this.Lbl_ProdName);
            this.Controls.Add(this.Lbl_prodID);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_prodID;
        private System.Windows.Forms.Label Lbl_ProdName;
        private System.Windows.Forms.Label Lbl_Price;
        private System.Windows.Forms.Label Lbl_Desc;
        private System.Windows.Forms.TextBox txt_prodId;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_prodName;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Button btn_addProd;
        private System.Windows.Forms.Button btn_UpdateProd;
        private System.Windows.Forms.Button btn_deleteProd;
        private System.Windows.Forms.Button btn_searchProd;
        private System.Windows.Forms.Button btn_showProd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

