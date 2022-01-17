using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entity
{
    public class Map
    {
        private Point mapLeft;
        private static int unit = 15;
        //定义地图长，为28个蛇块的长度
        private readonly int length = 30 * unit;
        //定义地图宽，为20个蛇块的宽度
        private readonly int width = 25 * unit;
        //定义分数
        public int score = 0;
        //定义蛇
        private readonly Snake snake;
        public bool victory = false;


        Bean food;

        internal Snake Snake => snake;

        public Map(Point start)
        {
            //把地图左上角的点的值赋值给全局变量
            mapLeft = start;
            //实例化蛇
            snake = new Snake(start, 5);
            //实例化食物
            food = new Bean();
            food.Origin = new Point(start.X + 30, start.Y + 30);
        }
        //显示新食物
        public void ShowNewFood(Graphics g)
        {
            //消除原先食物
            food.UnShowBean(g);
            //产生随机位置的食物
            food = FoodRandom();
            //显示食物
            food.ShowBean(g);
        }
        //随机产生一个新食物
        private Bean FoodRandom()
        {
            Random d = new Random();
            int x = d.Next(0, length / unit);
            int y = d.Next(0, width / unit);
            Point origin = new Point(mapLeft.X + x * 15, mapLeft.Y + y * 15);
            Bean food = new Bean();
            food.Origin = origin;
            return food;
        }
        //画地图
        public void ShowMap(Graphics g)
        {
            //创建一支红笔
            Pen pen = new Pen(Color.Blue);
            //画出地图的框
            g.DrawRectangle(pen, mapLeft.X, mapLeft.Y, length, width);
            //显示食物
            food.ShowBean(g);
            if (CheckBean())
            {
                //吃到了食物
                //显示新食物
                ShowNewFood(g);
                //蛇变长
                Snake.SnakeGrowth();
                //分数增加
                score += 10;
                //if (score >= 100)
                //{
                //    victory = true;
                //}
                //显示蛇
                Snake.ShowSnake(g);
            }
            else
            {
                Snake.Go(g);
                Snake.ShowSnake(g);
            }
        }
        //判断是否吃到了食物
        public bool CheckBean()
        {

            return food.Origin.Equals(Snake.SnakeHeadPoint);
        }

        //检查蛇是否撞墙
        public bool CheckSnake()
        {
            return !(Snake.SnakeHeadPoint.X > mapLeft.X - 5 && Snake.SnakeHeadPoint.X < (mapLeft.X + length - 5) && Snake.SnakeHeadPoint.Y > mapLeft.Y - 5 && Snake.SnakeHeadPoint.Y < (mapLeft.Y + width - 5));
        }

        //重新开始
        public void Reset(Graphics g)
        {
            Snake.UnShowSnake(g);
            Snake.Reset(mapLeft, 5);
        }
    }
}
