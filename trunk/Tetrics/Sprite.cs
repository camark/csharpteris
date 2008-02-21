using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tetrics
{
    abstract class Sprite
    {
        //private int x, y, status;

        private Graphics g;
        private int teris_width = 20;
        private int teris_height = 20;
        public Sprite()
        {
            x = 3;
            y = 1;

            status = 0;
            tiles = new int[4, 4];
        }

        public Graphics graphics
        {
            set
            {
                g = value;
            }
        }

        public int[,] tiles;
        public void left()
        {
            x--;
        }

        public void Right()
        {
            x++;
        }

        public void Down()
        {
            y++;
        }

        private bool canDown()
        {
            if (y < 20)
                return true;
            else
                return false;
        }

        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private int status=0;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual void Rotate()
        {
        }


        public abstract Sprite Clone();
       

        public void Draw()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (tiles[i, j] == 1)
                    {
                        Rectangle rect = new Rectangle((X + i) * teris_width, (Y + j-1) * teris_width, teris_width, teris_width);
                        //g.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), rect);
                        g.FillRectangle(new SolidBrush(Color.YellowGreen), rect);
                    }
                }
        }

        public void Hide()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (tiles[i, j] == 1)
                    {
                        Rectangle rect = new Rectangle((X + i) * teris_width, (Y + j-1) * teris_width, teris_width, teris_width);
                        //g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rect);
                        g.FillRectangle(new SolidBrush(Color.Black), rect);
                    }
                }
        }
    }
}
