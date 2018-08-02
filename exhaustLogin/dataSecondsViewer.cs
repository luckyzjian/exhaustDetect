using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ini;
using CSVcontrol;
using System.IO;

namespace exhaustDetect
{
    public partial class dataSecondsViewer : Form
    {
        public dataSecondsViewer()
        {
            InitializeComponent();
        }

        private void dataSecondsViewer_Load(object sender, EventArgs e)
        {

        }
        public void display_dataseconds(DataTable dirname, string clid)
        {
            string pathname = @"D:\dataseconds\" + dirname + "\\" + clid + ".csv";
            /*if (File.Exists(pathname))
            {
                csvReader csvreader = new csvReader();
                DataTable datagrid = csvreader.readCsv(pathname);
                datagrid.Rows.RemoveAt(0);
                setDataGridView(datagrid);
                //dataGridView1.DataSource = datagrid;
            }
            else
            {
                MessageBox.Show("没有找到过程数据文件,请检查该车是否在该线检测");
            }*/
            //dirname.Rows.RemoveAt(0);
            setDataGridView(dirname);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            List<int> seletedindex = new List<int>();
            for (int i = 1; i < dataGridView1.Columns.Count;i++ )
            {
                if(dataGridView1.Columns[i].Selected)
                    seletedindex.Add(i);
            }
            int rowscount = dataGridView1.Rows.Count;
            for (int i = 0; i < seletedindex.Count; i++)
            {
                string headername = dataGridView1.Columns[seletedindex[i]].HeaderText;
                chart1.Series.Add(headername);
                chart1.Series[headername].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart1.ChartAreas["ChartArea1"].AxisX.Interval = 100000;
                //chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
                //chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
                //chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 5000;
                //chart1.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;
                chart1.ChartAreas["ChartArea1"].AxisY.Title+="["+headername+"] ";
                for(int j=0;j<rowscount-1;j++)
                {
                    chart1.Series[headername].Points.Add(float.Parse(dataGridView1.Rows[j].Cells[seletedindex[i]].Value.ToString()));
                }
            }
            chart1.Visible = true;
        }
        public void setDataGridView(DataTable dt)
        {
            dataGridView1.DataSource = dt;
            int count = dataGridView1.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
        }
    }
}
