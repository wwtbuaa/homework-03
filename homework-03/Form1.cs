using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace homework_03
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        int max(int x, int y)
        {
            if (x > y) return x;
            else return y;
        }
        
        static int ans, begin_x, begin_y, end_x, end_y;
        static int m, n;
        static int[,] a = new int[100, 100];
        static int[,] b = new int[100, 100];
        static int i, j, k, temp, p;
        char[] str_char;

        TabControl tabControl1 = new TabControl();
        DataGridView DataGridView1 = new DataGridView();
        TabPage tabPage1 = new TabPage();

        void readdata()
        {
            string cmdin = Environment.CommandLine;
            string[] cmdinArray = cmdin.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string path = cmdinArray[1];
            StreamReader sr = File.OpenText(path);
            string s = "";

            m = (int)Convert.ToInt32(sr.ReadLine());
            n = (int)Convert.ToInt32(sr.ReadLine());
            int flag;
            for (i = 1; i <= m; i++)
                for (j = 1; j <= n; j++) a[i, j] = 0;
            for (i = 1; i <= m; i++)
            {
                s = sr.ReadLine();
                string[] sArray = s.Split(' ');
                for (j = 0; j < n; j++)
                {
                    flag = 0;
                    str_char = sArray[j].ToCharArray();
                    for (k = 0; k < str_char.Length; k++)
                    {
                        if (str_char[k] != '-')
                        {
                            p = Convert.ToInt32(str_char[k]) - 48;
                            a[i, j + 1] = a[i, j + 1] * 10 + p;
                        }
                        else flag = 1;
                    }
                    if (flag == 1) a[i, j + 1] = a[i, j + 1] * (-1);
                }
                for (j = 1; j <= n; j++)
                {
                    a[i + m, j] = a[i, j];
                    a[i, j + n] = a[i, j];
                    a[i + m, j + n] = a[i, j];
                }
            }
        }

        void calc(int h,int v)
        {
            
            temp = 0;
            
	        ans = a[1,1];
	        for (i = 1; i <= m;i++)
	            for (j = 1; j <= n;j++) ans = max(ans,a[i,j]);
            for (i = 1; i <= m; i++)
                for (j = 1; j <= n; j++) b[i, j] = 0;
	        int top;
	        if (h == 0 && v == 1)
	        {
		        for (j = 1;j <= n;j++)
		        {
			        temp = 0;
			        for (i = 1;i <= m * 2;i++)
			        {
				        temp = temp + a[i,j];
				        b[i,j] = temp;
			        }
		        }
		        for (i = 1;i <= m;i++)
		        for (j = i;j <= m * 2;j++)
		        {
			        if ((j - i) < m)
			        {
				        temp = 0;top = 1;
				        for (k = 1;k <= n;k++)
				        {
					        temp = temp + b[j,k] - b[i - 1,k];
					        if (temp > ans)
					        {
						        ans = temp;
						        begin_x = i;end_x = j;
						        begin_y = top;end_y = k;
					        }
					        else if (temp < 0)
					        {
						        temp = 0;
						        top = k + 1;
					        }
				        }
			        }
		        }
	        }
	        else if (h == 1 && v == 0)
	        {
		        for (i = 1;i <= m;i++)
		        {
			        temp = 0;
			        for (j = 1;j <= n * 2;j++)
			        {
        				temp = temp + a[i,j];
		        		b[i,j] = temp;
			        }
		        }
        		for (i = 1;i <= n;i++)
        		for (j = i;j <= n * 2;j++)
        		{
        			if ((j - i) < n)
        			{
        				temp = 0;top = 1;
        				for (k = 1;k <= m;k++)
        				{
        					temp = temp + b[k,j] - b[k,i - 1];
        					if (temp > ans)
        					{
        						ans = temp;
        						begin_y = i;end_y = j;
        						begin_x = top;end_x = k;
        					}
        					else if (temp < 0)
        					{
        						temp = 0;
        						top = k + 1;
        					}
        				}
        			}
        		}
        	}
        	else if (h == 0 && v == 0)
        	{
        		for (j = 1;j <= n;j++)
        		{
        			temp = 0;
        			for (i = 1;i <= m;i++)
        			{
        				temp = temp + a[i,j];
        				b[i,j] = temp;
        			}
        		}
        		for (i = 1;i <= m;i++)
        		for (j = i;j <= m;j++)
        		{
        			if ((j - i) < m)
        			{
        				temp = 0;top = 1;
        				for (k = 1;k <= n;k++)
        				{
        					temp = temp + b[j,k] - b[i - 1,k];
        					if (temp > ans)
        					{
        						ans = temp;
        						begin_x = i;end_x = j;
        						begin_y = top;end_y = k;
        					}
        					else if (temp < 0)
        					{
        						temp = 0;
        						top = k + 1;
        					}
        				}
        			}
        		}
        	}
        	else
        	{
        		int length;
        		for (j = 1;j <= n * 2;j++)
        		{
        			temp = 0;
        			for (i = 1;i <= m * 2;i++)
        			{
        				temp = temp + a[i,j];
        				b[i,j] = temp;
        			}
        		}
        		for (i = 1;i <= m;i++)
        		for (j = i;j <= m * 2;j++)
        		{
        			if ((j - i) < m)
        			{
        				temp = 0;length = 0;top = 1;
        				for (k = 1;k <= n * 2;k++)
        				{
        					if (length < n)
        					{
        						temp = temp + b[j,k] - b[i - 1,k];
        						length++;
	        				}
	        				else
        					{
        						temp = temp + b[j,k] - b[i - 1,k];
        						temp = temp - b[j,k - 1] + b[i - 1,k - 1];
        						top++;
        					}
        					if (temp > ans)
        					{
        						ans = temp;
        						begin_x = i;end_x = j;
        						begin_y = top;end_y = k;
        					}
        					else if (temp < 0)
        					{
        						temp = 0;
        						length = 0;
        						top = k + 1;
        					}
        				}
        			}
        		}
        	} 
        }

        private void DataGridView1_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.DataGridView1.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        
        private void SetupDataGridView()
        {
            
            this.Controls.Add(tabControl1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Size = new Size(520, 300);

            
            tabControl1.Controls.Add(tabPage1);
            tabPage1.Location = new Point(15, 15);
            tabPage1.Size = new Size(500, 280);

            
            tabPage1.Controls.Add(DataGridView1);
            DataGridView1.ColumnCount = n;

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(DataGridView1.Font, FontStyle.Bold);

            DataGridView1.Name = "DataGridView1";
            DataGridView1.Location = new Point(8, 8);
            DataGridView1.Size = new Size(500, 250);
            DataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridView1.GridColor = Color.Black;
            DataGridView1.RowHeadersVisible = false;
            DataGridView1.ColumnHeadersVisible = false;



            DataGridView1.MultiSelect = false;
            DataGridView1.Dock = DockStyle.Fill;

            DataGridView1.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                DataGridView1_CellFormatting);
        }
        void produce()
        {
            string[] row = new string[n+5];

            for (i = 1; i <= m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    row[j] = a[i,j+1].ToString(); 
                }
                DataGridView1.Rows.Add(row);
            }
        }
        void drawcolor(int x1,int y1,int x2,int y2)
        {
            for (i = begin_x;i <= end_x;i++)
                for (j = begin_y; j <= end_y; j++)
                {
                    DataGridView1.Rows[(i-1)%m].Cells[(j-1)%n].Style.BackColor = Color.Yellow;
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int h,v;
            if (checkBox2.Checked == true) h = 1;
            else h = 0;
            if (checkBox3.Checked == true) v = 1;
            else v = 0;
            calc(h, v);
            label2.Text = ans.ToString();
            drawcolor(begin_x, begin_y, end_x, end_y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            label2.Text = "No Answer";
            for (i = 1;i <= m;i++)
                for (j = 1;j <= n;j++)
                    DataGridView1.Rows[(i - 1) % m].Cells[(j - 1) % n].Style.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readdata();
            SetupDataGridView();
            produce();
        }
    }
}
