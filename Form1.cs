using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //定义地图
            map = new Map(new Point(50, 50));
            BackColor = Color.Silver;
        }
        private readonly Map map;
        private int gradeNum = 100;
        private int pink;
        private void frmMain_Load(object sender, EventArgs e)
        {
            SetStyle(
              ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    //this.BackgroundImage = Image.FromFile(pink+".jpg");
        //    开始ToolStripMenuItem.Text = "重新开始";
        //    lblScore.Text = map.score.ToString();
        //    if (map.score >= 500)
        //    {
        //        timer1.Enabled = false;
        //        MessageBox.Show("恭喜，成功！！！");
        //    }
        //    Bitmap bmp = new Bitmap(Width, Height);
        //    //Image face = Image.FromFile("1.jpg");
        //    BackgroundImage = bmp;
        //    Graphics g = Graphics.FromImage(bmp);
        //    map.ShowMap(g);
        //    if (map.CheckSnake() || map.Snake.IsTouchMyself())
        //    {
        //        timer1.Enabled = false;
        //        MessageBox.Show("很遗憾，失败了！！！");
        //    }

        //}
        //键盘响应事件
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            int k, d = 0;
            k = e.KeyValue;
            if (k == 37) //左
                d = 3;
            else if (k == 40) //下
                d = 2;
            else if (k == 38) //上
                d = 0;
            else if (k == 39) //右
                d = 1;
            map.Snake.TurnDirection(d);
        }


        private void ToolStripMenuItem_Click重新开始(object sender, EventArgs e)
        {
            if (lblGrade.Text == "")
            {
                MessageBox.Show("请先选择级别");
                return;
            }
            if (ToolStripMenuItem2.Text == "开始")
            {
                ToolStripMenuItem.Text = "重新开始";
                timer1.Enabled = true;
            }
            else if (ToolStripMenuItem.Text == "重新开始")
            {
                ToolStripMenuItem.Text = "开始";
                ToolStripMenuItem.Text = "暂停";
                timer1.Enabled = true;
                map.Reset(CreateGraphics());
                map.score = 0;
            }

            //}

            //private void ToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    if (ToolStripMenuItem.Text == "继续")
            //    {
            //        ToolStripMenuItem.Text = "暂停";
            //        timer1.Enabled = true;
            //    }
            //    else if (ToolStripMenuItem.Text == "暂停")
            //    {
            //        ToolStripMenuItem.Text = "继续";
            //        timer1.Enabled = false;
            //    }
            //}

            //private void ToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    gradeNum = 200;
            //    lblGrade.Text = "菜鸟";
            //    timer1.Interval = gradeNum;
            //}

            //private void ToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    gradeNum = 150;
            //    lblGrade.Text = "平民";
            //    timer1.Interval = gradeNum;
            //}

            //private void ToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    gradeNum = 100;
            //    lblGrade.Text = "高手";
            //    timer1.Interval = gradeNum;
            //}

            //private void ToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    gradeNum = 50;
            //    lblGrade.Text = "大神";
            //    timer1.Interval = gradeNum;
            //}

        }

     
    }
