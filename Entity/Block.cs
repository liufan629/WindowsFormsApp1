using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entity
{
    public class Bean
    {
        //用于画食物的顶端坐标
        private Point _origin;

        public Point Origin { get => _origin; set => _origin = value; }


        //显示食物
        public void ShowBean(Graphics g)
        {
            //定义红色的画笔
            SolidBrush brush = new SolidBrush(Color.Red);
            //画实心矩形表示食物
            g.FillRectangle(brush, Origin.X, Origin.Y, 15, 15);
        }

        public void UnShowBean(Graphics g)
        {
            //定义系统背景颜色的画笔
            SolidBrush brush = new SolidBrush(Color.Silver);
            //画实心矩形颜色为系统背景颜色，相当于食物被吃掉了
            g.FillRectangle(brush, Origin.X, Origin.Y, 15, 15);
        }
    }

    class Block
    {
        private bool isHeader;//头
        private bool isTail;//尾巴
        private int blockNumer;//身体编号
        private Point blockOrigin;//蛇块左上角的位置

        public bool IsHeader { get => isHeader; set => isHeader = value; }
        public bool IsTail { get => isTail; set => isTail = value; }
        public int BlockNumber { get => blockNumer; set => blockNumer = value; }
        public Point BlockOrigin { get => blockOrigin; set => blockOrigin = value; }
        //根据指定位置画蛇块
        public void ShowBlock(Graphics g)
        {
            SolidBrush brush;
            if (isHeader)
            {
                //蛇头
                //定义系统背景颜色的画笔
                brush = new SolidBrush(Color.Blue);
                //画实心矩形颜色为系统背景颜色，相当于食物被吃掉了
                
            }
            else
            {
                brush = new SolidBrush(Color.Green) ;
            }
            // g.DrawImage(bitMap, Origin.X, Origin.Y, 15, 15);
            g.FillPie(brush,blockOrigin.X,blockOrigin.Y,15,15,0,360);
        }

        //消除蛇块
        public void UnShowBlock(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Silver);
            g.FillRectangle(brush, blockOrigin.X, blockOrigin.Y, 15, 15);
        }

    }
}
