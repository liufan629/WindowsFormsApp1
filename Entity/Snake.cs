using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1.Entity
{
    class Snake
    {
        //蛇的身体构成的集合
        private List<Block> snakeBody;
        //蛇的方向0-上，1-右，2-下，3-左
        private int direction = 1;
        //蛇的编号，蛇的长度
        private int snakeLenth = 1;
        private Point snakeHeadPoint;
        private Point mapLeft;
        //蛇的构造函数
        public Snake(Point map, int count)
        {
            Block snakeBlock;
            mapLeft = map;
            //定义蛇尾的位置
            Point snakeTailPoint = new Point(map.X + 15, map.Y + 15);
            snakeBody = new List<Block>();
            for (int i = 0; i <= count; i++)
            {
                //x坐标加15
                snakeTailPoint.X += 15;
                //实例化蛇块
                snakeBlock = new Block();
                //定义蛇块的左上角位置 
                snakeBlock.BlockOrigin = snakeTailPoint;
                //定义蛇块的编号1，2，3...
                snakeBlock.BlockNumber = i + 1;
                if (i == count - 1)
                {
                    //蛇头
                    //给蛇头位置赋值
                    snakeHeadPoint = snakeBlock.BlockOrigin;
                }
                snakeBody.Add(snakeBlock);

            }
            snakeLenth = count;
        }

        public Point SnakeHeadPoint { get => snakeHeadPoint; }
        public int Direction { get => direction; set => direction = value; }
        /// <summary>
        /// 蛇的转换方向
        /// </summary>
        /// <param name="pDirection">想要改变的方向</param>
        public void TurnDirection(int pDirection)
        {
            switch (direction)
            {
                //原来向上运动
                case 0:
                    //希望向左运动
                    if (pDirection == 3)
                        direction = 3;
                    //希望向右运动
                    else if (pDirection == 1)
                        direction = 1;
                    break;
                //原来向右运动
                case 1:
                    //下
                    if (pDirection == 2)
                        direction = 2;
                    //上
                    else if (pDirection == 0)
                        direction = 0;
                    break;
                case 2:
                    if (pDirection == 1)
                        direction = 1;
                    else if (pDirection == 3)
                        direction = 3;
                    break;
                case 3:
                    if (pDirection == 0)
                        direction = 0;
                    else if (pDirection == 2)
                        direction = 2;
                    break;

            }
        }
        //蛇吃到食物后变长，蛇头+1
        public void SnakeGrowth()
        {
            //找到蛇头的坐标
            Point head = snakeBody[snakeBody.Count - 1].BlockOrigin;
            int x = head.X;
            int y = head.Y;
            //判断蛇的运动方向,改变蛇头的位置
            switch (direction)
            {
                case 0:
                    //向上运动
                    y -= 15;
                    break;
                case 1:
                    x += 15;
                    break;
                case 2:
                    y += 15;
                    break;
                case 3:
                    x -= 15;
                    break;
            }
            //把原先蛇头的块变为普通块
            snakeBody[snakeBody.Count - 1].IsHeader = false;
            //实例化新蛇头
            Block headNew = new Block();
            headNew.IsHeader = true;
            headNew.BlockNumber = snakeBody.Count + 1;
            headNew.BlockOrigin = new Point(x, y);
            snakeBody.Add(headNew);
            snakeLenth++;
            snakeHeadPoint = headNew.BlockOrigin;
        }

        //蛇向前运动（没有吃到食物的情况），蛇尾移除，蛇头移位+1
        public void Go(Graphics g)
        {
            Block snakeTail = snakeBody[0];
            //消除蛇尾块
            snakeTail.UnShowBlock(g);
            //集合中移除设为块
            snakeBody.RemoveAt(0);
            foreach (var item in snakeBody)
            {
                item.BlockNumber--;
            }
            //由于SnakeGrowth中仅仅使蛇头+1，但是headNumber++了。但是此值并没有改变，所以先--
            snakeLenth--;
            SnakeGrowth();
        }

        //画出蛇
        public void ShowSnake(Graphics g)
        {
            foreach (var item in snakeBody)
            {
                item.ShowBlock(g);
            }
        }
        //隐藏蛇
        public void UnShowSnake(Graphics g)
        {
            foreach (var item in snakeBody)
            {
                item.UnShowBlock(g);
            }
        }
        //重置蛇
        public void Reset(Point map, int count)
        {
            Block blockSnake;
            //定义蛇的起始位置（蛇尾）
            Point p = new Point(mapLeft.X + 15, mapLeft.Y + 15);
            snakeBody = new List<Block>();
            //循环画蛇块用于填充蛇集合
            for (int i = 0; i < count; i++)
            {
                //x坐标加15
                p.X += 15;
                //实例化蛇块
                blockSnake = new Block();
                //定义蛇块的左上角位置 
                blockSnake.BlockOrigin = p;
                //定义蛇块的编号1，2，3...
                blockSnake.BlockNumber = i + 1;
                if (i == count - 1)
                {
                    //蛇头
                    //给蛇头位置赋值
                    snakeHeadPoint = blockSnake.BlockOrigin;
                    blockSnake.IsHeader = true;
                }
                snakeBody.Add(blockSnake);

            }
            //蛇的长度赋值
            snakeLenth = count;
            direction = 1;
        }
        //是否碰到自己
        public bool IsTouchMyself()
        {
            bool isTouched = false;
            for (int i = 0; i < snakeBody.Count - 1; i++)
            {
                if (snakeHeadPoint == snakeBody[i].BlockOrigin)
                {
                    isTouched = true;
                    break;
                }
            }
            return isTouched;
        }
    }

}
