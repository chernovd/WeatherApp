using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Data.SqlClient;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        const int DAY_COUNT = 5;
        const string APPID = "c74692e39e64c85d96ce8d940b0c0cc8";
        // database
        private string server;
        private string database;
        private string uid;
        private string password;
        private string connectionString;
        private string location = "Amsterdam,NL";
        private int tempUnit = 0;
        public double totalTemp;

        public Form1()
        {
            InitializeComponent();
            InitTimer();
            //getInfo();
        }


        private void Form1_Load(object sender, EventArgs e)
        {            
            // connect db
            server = "localhost";
            database = "weatherdb";
            uid = "root";
            password = "";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            
            // Refresh data and display infos
            refresh(this.location); 
            lbl_LastTime.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);  
            lbl_Location.Text = this.location;
            lbl_AverTemp.Text = string.Format("{0:f} \u00B0" + "C", get_AverageTemp());
            radio_Celsius.Checked = true;
            saveData();
        }

        public DataTable GetDataTable(String commandSQL)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection dbConnection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(commandSQL, dbConnection))
                {
                    command.CommandType = CommandType.Text;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                    {
                        da.Fill(dt);
                        da.Dispose();
                    }
                    command.Parameters.Clear();
                    command.Dispose();
                }
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
                dbConnection.Dispose();
            }
            return dt;
        }

        // get location and time interval from option box
        public void getInfo()
        {
            Option option = new Option();
            //option.Show();
            if (option.ShowDialog() == DialogResult.OK)
            {
                this.location = option.get_cityName();
                timer1.Interval = option.get_TimeInterval();
                this.tempUnit = option.get_TempUnit();
                MessageBox.Show("Your option has been successfully changed!");
                this.Show();
                this.WindowState = FormWindowState.Normal;
                //this.lbl_Location.Text = this.location;
                refresh(this.location);
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                this.ContextMenuStrip = contextMenu;
            }
        }


        
        // Refresh funtion
        // This function is triggered every time interval and by clicking refresh in context menu
        void refresh(string city)
        {
            try
            {
                // Get current weather
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", city, APPID);
                using (WebClient web = new WebClient())
                {
                    var json = web.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                    WeatherInfo.root weatherInfo = result;

                    lbl_Location.Text = string.Format("{0},{1}", weatherInfo.name, weatherInfo.sys.country);
                    lbl_LastTime.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
                    //lbl_LastTime.Text = string.Format("{0:HH:mm:ss}", getDate(weatherInfo.dt));
                    if (this.tempUnit == 0)
                        lbl_Temp.Text = string.Format("{0:f} \u00B0" + "C", weatherInfo.main.temp);
                    else
                        lbl_Temp.Text = string.Format("{0:f} \u00B0" + "F", weatherInfo.main.temp * 1.8 + 32);
                    lbl_Humidity.Text = string.Format("{0:f} %", weatherInfo.main.humidity);
                    lbl_WindSpeed.Text = string.Format("{0:f} km/h", weatherInfo.wind.speed);
                    lbl_Condition.Text = string.Format("{0}", weatherInfo.weather[0].description);
                    contextMenu.Items[0].Text = "Huidige temperatuur " + lbl_Temp.Text;
                    pictureBox1.ImageLocation = "http://openweathermap.org/img/w/" + weatherInfo.weather[0].icon + ".png";
                }
                // Forecast
                totalTemp = 0;
                url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric&cnt={2}", city, APPID, DAY_COUNT * 8);
                using (WebClient web = new WebClient())
                {
                    var json = web.DownloadString(url);
                    var Object = JsonConvert.DeserializeObject<weatherForecast>(json);

                    weatherForecast forecast = Object;

                    // Show weather infos in dataGridView
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    for (int i = 0; i < DAY_COUNT * 8; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        if (this.tempUnit == 0)
                            row.Cells[0].Value = string.Format("{0:f} \u00B0" + "C", forecast.list[i].main.temp);
                        else
                            row.Cells[0].Value = string.Format("{0:f} \u00B0" + "F", forecast.list[i].main.temp * 1.8 + 32);
                        row.Cells[1].Value = this.location;
                        row.Cells[2].Value = string.Format("{0:MM/dd/yyyy HH:mm}", getDate(forecast.list[i].dt));
                        dataGridView1.Rows.Add(row);
                        totalTemp += forecast.list[i].main.temp;
                    }
                    if (this.tempUnit == 0)
                        lbl_AverTemp.Text = string.Format("{0:f} \u00B0" + "C", get_AverageTemp());
                    else
                        lbl_AverTemp.Text = string.Format("{0:f} \u00B0" + "F", get_AverageTemp() * 1.8 + 32);

                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    var chart = chart1.ChartAreas[0];
                    chart.AxisX.IntervalType = DateTimeIntervalType.Number;

                    chart.AxisX.LabelStyle.Format = "";
                    chart.AxisY.LabelStyle.Format = "";
                    chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                    chart.AxisX.Minimum = 1;
                    chart.AxisX.Maximum = DAY_COUNT * 8;

                    chart.AxisX.Interval = 8;
                    if (this.tempUnit == 0)
                    {
                        chart.AxisY.LabelStyle.Format = "{0}\u00B0C";
                        chart.AxisY.Interval = 5;
                    }
                    else
                    {
                        chart.AxisY.LabelStyle.Format = "{0}\u00B0F";
                        chart.AxisY.Interval = 10;
                    }

                    chart.AxisX.Title = "date";
                    chart.AxisX.TitleForeColor = Color.LightGreen;
                    chart.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                    chart.AxisY.Title = "Temp";
                    chart.AxisY.TitleForeColor = Color.Red;
                    chart.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                    chart1.Series[0].IsVisibleInLegend = false;
                    //Here we'll draw the graph USING DATABASE
                    //we define table that gets data
                    DataTable dt = GetDataTable("select * from fivedaysinfo");
                    //this for loop will go throuh datatable
                    for (int i = 0; i < DAY_COUNT * 8; i++)
                    {//this if is to check that datatable has data :)
                        if (i < dt.Rows.Count)
                        {//we plot graph as x value is date which is third column in datatable and y value is the degree which is first column
                            if (this.tempUnit == 0)
                                chart1.Series[0].Points.AddXY(dt.Rows[i][2].ToString().Remove(5), double.Parse(dt.Rows[i][0].ToString()));
                            //chart1.Series[0].Points.AddXY(string.Format("{0:MM/dd}", getDate(forecast.list[i].dt)), forecast.list[i].main.temp);
                            else
                                chart1.Series[0].Points.AddXY(dt.Rows[i][2].ToString().Remove(5), double.Parse(dt.Rows[i][0].ToString()) * 1.8 + 32);
                            //chart1.Series[0].Points.AddXY(string.Format("{0:MM/dd}", getDate(forecast.list[i].dt)), forecast.list[i].main.temp * 1.8 + 32);
                        }
                    }

                    saveData();
                }
            } catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        // Get date from millisecond
        DateTime getDate(double millisecond)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();
            return day;
        }

        // Get average temperature
        public double get_AverageTemp()
        {
            return this.totalTemp / DAY_COUNT / 8;
        }

        // Initialize timer
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 60 * 1000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh(this.location);                 
        }

        // When double click the notify icon in the notification area, shows the app
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        // Open app when click open menu
        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Show();
        }

        // Refresh app when select refresh toolstrip menu
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh(this.location);
        }

        // Option menu
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getInfo();
            //refresh(this.location);
        }

        // Exit the application
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // Popup aboutbox
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        // When click the close button, minimize the app into the notification area
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
        }

        // Save weather info into MySQL Database
        public void saveData()
        {
            string clearData = "Delete from fivedaysinfo";
            string query = "INSERT INTO fivedaysinfo(Temperature,Place,Date) VALUES (@temp,@place,@time)";
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(clearData, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    using (con)
                    {
                        using (cmd = new MySqlCommand(query, con))
                        {
                            if (row.Cells[0].Value != null)
                            {
                                cmd.Parameters.AddWithValue(
                                    "@temp", row.Cells[0].Value.ToString());
                                cmd.Parameters.AddWithValue(
                                    "@place", this.location);
                                cmd.Parameters.AddWithValue(
                                    "@time", row.Cells[2].Value.ToString());
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = Convert.ToInt32(cmb_TimeInterval.Text) * 1000;
                this.location = txt_CityName.Text;
                
                MessageBox.Show("Your option has been successfully changed!");
                tabControl1.TabPages[0].Show();
                if (radio_Celsius.Checked)
                    this.tempUnit = 0;
                else if (radio_Fahrenheit.Checked)
                    this.tempUnit = 1;
                refresh(this.location);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input! Please input values correctly");
            }
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void currentTemperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
