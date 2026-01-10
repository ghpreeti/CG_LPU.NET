namespace WinSerializationDemo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBinSerialize = new System.Windows.Forms.Button();
            this.btnXMLDeserialize = new System.Windows.Forms.Button();
            this.btnBinUnserialize = new System.Windows.Forms.Button();
            this.btnSOAPSerialization = new System.Windows.Forms.Button();
            this.btnXmlSerialize = new System.Windows.Forms.Button();
            this.btnSOAPUnserializer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID\r\n";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpID.Location = new System.Drawing.Point(418, 92);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(100, 35);
            this.txtEmpID.TabIndex = 1;
            this.txtEmpID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(418, 144);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 35);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name\r\n";
            // 
            // txtSalary
            // 
            this.txtSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalary.Location = new System.Drawing.Point(418, 205);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(100, 35);
            this.txtSalary.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(230, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Salary";
            // 
            // btnBinSerialize
            // 
            this.btnBinSerialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinSerialize.Location = new System.Drawing.Point(166, 298);
            this.btnBinSerialize.Name = "btnBinSerialize";
            this.btnBinSerialize.Size = new System.Drawing.Size(185, 38);
            this.btnBinSerialize.TabIndex = 6;
            this.btnBinSerialize.Text = "Bin Serialize\r\n";
            this.btnBinSerialize.UseVisualStyleBackColor = true;
            this.btnBinSerialize.Click += new System.EventHandler(this.btnBinSerialize_Click);
            // 
            // btnXMLDeserialize
            // 
            this.btnXMLDeserialize.AutoSize = true;
            this.btnXMLDeserialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXMLDeserialize.Location = new System.Drawing.Point(376, 371);
            this.btnXMLDeserialize.Name = "btnXMLDeserialize";
            this.btnXMLDeserialize.Size = new System.Drawing.Size(238, 39);
            this.btnXMLDeserialize.TabIndex = 7;
            this.btnXMLDeserialize.Text = "XML Deserialization";
            this.btnXMLDeserialize.UseVisualStyleBackColor = true;
            this.btnXMLDeserialize.Click += new System.EventHandler(this.btnXMLDeserialize_Click);
            // 
            // btnBinUnserialize
            // 
            this.btnBinUnserialize.AutoSize = true;
            this.btnBinUnserialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinUnserialize.Location = new System.Drawing.Point(166, 370);
            this.btnBinUnserialize.Name = "btnBinUnserialize";
            this.btnBinUnserialize.Size = new System.Drawing.Size(185, 39);
            this.btnBinUnserialize.TabIndex = 8;
            this.btnBinUnserialize.Text = "Bin Deserialize\r\n";
            this.btnBinUnserialize.UseVisualStyleBackColor = true;
            this.btnBinUnserialize.Click += new System.EventHandler(this.btnBinUnserialize_Click);
            // 
            // btnSOAPSerialization
            // 
            this.btnSOAPSerialization.AutoSize = true;
            this.btnSOAPSerialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSOAPSerialization.Location = new System.Drawing.Point(673, 298);
            this.btnSOAPSerialization.Name = "btnSOAPSerialization";
            this.btnSOAPSerialization.Size = new System.Drawing.Size(254, 39);
            this.btnSOAPSerialization.TabIndex = 9;
            this.btnSOAPSerialization.Text = "SOAP Serialization";
            this.btnSOAPSerialization.UseVisualStyleBackColor = true;
            this.btnSOAPSerialization.Click += new System.EventHandler(this.btnSOAPSerialize_Click);
            // 
            // btnXmlSerialize
            // 
            this.btnXmlSerialize.AutoSize = true;
            this.btnXmlSerialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXmlSerialize.Location = new System.Drawing.Point(376, 298);
            this.btnXmlSerialize.Name = "btnXmlSerialize";
            this.btnXmlSerialize.Size = new System.Drawing.Size(238, 39);
            this.btnXmlSerialize.TabIndex = 10;
            this.btnXmlSerialize.Text = "XML Serialization";
            this.btnXmlSerialize.UseVisualStyleBackColor = true;
            this.btnXmlSerialize.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnSOAPUnserializer
            // 
            this.btnSOAPUnserializer.AutoSize = true;
            this.btnSOAPUnserializer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSOAPUnserializer.Location = new System.Drawing.Point(673, 372);
            this.btnSOAPUnserializer.Name = "btnSOAPUnserializer";
            this.btnSOAPUnserializer.Size = new System.Drawing.Size(254, 39);
            this.btnSOAPUnserializer.TabIndex = 11;
            this.btnSOAPUnserializer.Text = "SOAP Deserialization";
            this.btnSOAPUnserializer.UseVisualStyleBackColor = true;
            this.btnSOAPUnserializer.Click += new System.EventHandler(this.btnSOAPUnserialize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1302, 465);
            this.Controls.Add(this.btnSOAPUnserializer);
            this.Controls.Add(this.btnXmlSerialize);
            this.Controls.Add(this.btnSOAPSerialization);
            this.Controls.Add(this.btnBinUnserialize);
            this.Controls.Add(this.btnXMLDeserialize);
            this.Controls.Add(this.btnBinSerialize);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBinSerialize;
        private System.Windows.Forms.Button btnXMLDeserialize;
        private System.Windows.Forms.Button btnBinUnserialize;
        private System.Windows.Forms.Button btnSOAPSerialization;
        private System.Windows.Forms.Button btnXmlSerialize;
        private System.Windows.Forms.Button btnSOAPUnserializer;
    }
}

