using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Option : Form
    {
        private int timeInterval = 1;
        private string cityName;
        private int tempUnit = 0;
        public Option()
        {
            InitializeComponent();
            radio_Celsius.Checked = true;
        }

        public int get_TimeInterval()
        {
            return this.timeInterval * 1000;
        }

        public string get_cityName()
        {
            return this.cityName;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.timeInterval = Convert.ToInt32(cmb_TimeInterval.Text);
            this.cityName = txt_CityName.Text;
            if (radio_Celsius.Checked)
                this.tempUnit = 0;
            else if (radio_Fahrenheit.Checked)
                this.tempUnit = 1;
            this.Hide();
        }

        public int get_TempUnit()
        {
            return this.tempUnit;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
