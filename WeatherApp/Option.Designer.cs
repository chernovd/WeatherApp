namespace WeatherApp
{
    partial class Option
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
            this.cmb_TimeInterval = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_CityName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_Celsius = new System.Windows.Forms.RadioButton();
            this.radio_Fahrenheit = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_TimeInterval
            // 
            this.cmb_TimeInterval.FormattingEnabled = true;
            this.cmb_TimeInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.cmb_TimeInterval.Location = new System.Drawing.Point(172, 31);
            this.cmb_TimeInterval.Name = "cmb_TimeInterval";
            this.cmb_TimeInterval.Size = new System.Drawing.Size(121, 21);
            this.cmb_TimeInterval.TabIndex = 12;
            this.cmb_TimeInterval.Text = "60";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(54, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "City Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(54, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Time Interval";
            // 
            // btn_OK
            // 
            this.btn_OK.AllowDrop = true;
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(100, 174);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 13;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(197, 174);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 14;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_CityName
            // 
            this.txt_CityName.Location = new System.Drawing.Point(172, 77);
            this.txt_CityName.Name = "txt_CityName";
            this.txt_CityName.Size = new System.Drawing.Size(121, 20);
            this.txt_CityName.TabIndex = 15;
            this.txt_CityName.Text = "Amsterdam,NL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_Fahrenheit);
            this.groupBox1.Controls.Add(this.radio_Celsius);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(58, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 65);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temp Unit";
            // 
            // radio_Celsius
            // 
            this.radio_Celsius.AutoSize = true;
            this.radio_Celsius.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Celsius.ForeColor = System.Drawing.Color.Maroon;
            this.radio_Celsius.Location = new System.Drawing.Point(29, 33);
            this.radio_Celsius.Name = "radio_Celsius";
            this.radio_Celsius.Size = new System.Drawing.Size(65, 17);
            this.radio_Celsius.TabIndex = 0;
            this.radio_Celsius.TabStop = true;
            this.radio_Celsius.Text = "Celsius";
            this.radio_Celsius.UseVisualStyleBackColor = true;
            // 
            // radio_Fahrenheit
            // 
            this.radio_Fahrenheit.AutoSize = true;
            this.radio_Fahrenheit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Fahrenheit.ForeColor = System.Drawing.Color.Maroon;
            this.radio_Fahrenheit.Location = new System.Drawing.Point(126, 33);
            this.radio_Fahrenheit.Name = "radio_Fahrenheit";
            this.radio_Fahrenheit.Size = new System.Drawing.Size(85, 17);
            this.radio_Fahrenheit.TabIndex = 1;
            this.radio_Fahrenheit.TabStop = true;
            this.radio_Fahrenheit.Text = "Fahrenheit";
            this.radio_Fahrenheit.UseVisualStyleBackColor = true;
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 209);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_CityName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.cmb_TimeInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Option";
            this.Text = "Option";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_TimeInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_CityName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_Fahrenheit;
        private System.Windows.Forms.RadioButton radio_Celsius;
    }
}