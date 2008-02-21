using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetrics
{
    public partial class Form1 : Form
    {
        private bool _isStart = false;
        private int teris_width = 20;
        private int teris_height = 20;
        private int GamePanel_left = 40;
        private int GamePanel_top = 50;
        private int xcount = 10;
        private int ycount = 20;
        private int _GameSpeed = 1;
        private int score = 0;
        private bool _isGameOver = false;
        private SpriteFactory fct = new SpriteFactory();
        private Sprite _sprite = null;
        private int[,] tiles = null;
            //{
            //    {1,1,1,1,1,1,1,1,1,1,1,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,0,0,0,0,0,0,0,0,0,0,1},
            //    {1,1,1,1,1,1,1,1,1,1,1,1}
            //};
        public Form1()
        {
            InitializeComponent();
            //InitGameBoard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isStart = !_isStart;

            timer1.Enabled = _isStart;
            if (_sprite == null)
            {
                _sprite = fct.nextSprite;
                _sprite.graphics = Graphics.FromHwnd(panel1.Handle);
            }
        }

        private void DrawBoard()
        {
            if (_sprite != null)
            {
                _sprite.Draw();
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isStart && !_isGameOver)
            {
                //_sprite.Hide(Graphics.FromHwnd(panel1.Handle));
                SpriteDown();
                //pictureBox1.Invalidate();
                //DrawBoard();                
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            DispatchKey(e);
        }

        private void SpriteLeft()
        {
            //Sprite _tempSprite = _sprite.Clone();
            //_tempSprite.left();
            if (!coolate(_sprite.X - 1, _sprite.Y, _sprite))
            {
                _sprite.Hide();
                _sprite.left();
                _sprite.Draw();
            }
        }

        private void SpriteRight()
        {
            //Sprite _tempSprite = _sprite.Clone();
            //_tempSprite.Right();
            if (!coolate(_sprite.X + 1, _sprite.Y, _sprite))
            {
                _sprite.Hide();
                _sprite.Right();
                _sprite.Draw();
            }
        }

        private void SpriteRotate()
        {
            Sprite _tempSprite = _sprite.Clone();
            _tempSprite.Rotate();
            if (!coolate(_tempSprite))
            {
                _sprite.Hide();
                _sprite.Rotate();
                label1.Text = _sprite.X.ToString();
                label2.Text = _sprite.Y.ToString();
                _sprite.Draw();
            }
        }

        private void SpriteDown()
        {
            //Sprite _tempSprite = _sprite.Clone();
            //_tempSprite.Down();
            if (!coolate(_sprite.X, _sprite.Y + 1, _sprite))
            {
                _sprite.Hide();
                _sprite.Down();
                label1.Text = _sprite.X.ToString();
                label2.Text = _sprite.Y.ToString();
                //dataGridView1.DataSource = _sprite.tiles;                
                _sprite.Draw();
            }
            else
            {
                Combine(_sprite);
                count();
                _sprite = null;
                _sprite = fct.nextSprite;
                _sprite.graphics = Graphics.FromHwnd(panel1.Handle);
            }
        }
        private void DispatchKey(KeyEventArgs e)
        {
            if (_isStart)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        SpriteLeft();
                        break;
                    case Keys.Right:
                        SpriteRight();
                        break;
                    case Keys.Up:
                        SpriteRotate();
                        break;
                    case Keys.A:
                        SpriteLeft();
                        break;
                    case Keys.D:
                        SpriteRight();
                        break;
                    case Keys.S:
                        SpriteRotate();
                        break;
                    case Keys.Space:
                        timer1.Enabled = !timer1.Enabled;
                        break;
                    default:
                        //MessageBox.Show(e.KeyData.ToStrineg());
                        break;
                }
            }
        }



        

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGameBoard();

            panel1.Location = new System.Drawing.Point(GamePanel_left, GamePanel_top);

            panel1.Size = new Size(teris_width * xcount, (teris_height-1) * ycount);
        }

        private void InitGameBoard()
        {
            tiles = new int[ycount+2, xcount+2];
            for (int i = 0; i < xcount+1; i++)
            {
                tiles[0, i] = 1;
                tiles[ycount+1, i] = 1;
            }
            for (int i = 1; i < ycount+1; i++)
            {
                tiles[i, 0] = 1;
                tiles[i, 11] = 1;
            }
            for (int i = 1; i < ycount; i++)
                for (int j = 1; j < xcount; j++)
                    tiles[i, j] = 0;
        }

        /// <summary>
        /// 检查碰撞
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private bool coolate(Sprite sprite)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    int x = sprite.X + j + 1;
                    int y = sprite.Y + i + 1;

                    if (sprite.tiles[i, j] == 1 && tiles[y, x] == 1)
                        return true;
                }

            return false;
        }
        
        /// <summary>
        /// 检查碰撞-2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private bool coolate(int x, int y, Sprite sprite)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (sprite.tiles[i, j] == 1 && tiles[y + j+1, x + i+1] == 1)
                        return true;
                }

            return false;
        }

        /// <summary>
        /// 组合方块
        /// </summary>
        private void Combine(Sprite sprite)
        {
            for (int i = 0; i <4; i++)
            {
                for (int j = 0; j <4; j++)
                {
                    int x = sprite.X + i + 1;
                    int y = sprite.Y + j + 1;
                    if (sprite.tiles[i, j] == 1 && x<xcount+2 && y<ycount+2)
                    {
                        tiles[y, x] = 1;
                    }
                }
            }

            int topLine = GetTopLine();

            if (topLine == 1)
            {
                MessageBox.Show("Game Over!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isGameOver = true;
            }
            ShowData();
        }


        /// <summary>
        /// 扫描方块是否可以消掉
        /// </summary>
        private void count()
        {
            int lines = 0;
            int[,] tmpTiles =
            {
                {1,1,1,1,1,1,1,1,1,1,1,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,0,0,0,0,0,0,0,0,0,0,1},
		        {1,1,1,1,1,1,1,1,1,1,1,1}
   
	        };
            int tempi = 20;
            for (int i = 20; i > 0; i--)
            {
                bool isfull = true;
                for (int j = 1; j < 11; j++)
                {
                    if (tiles[i, j] == 0)
                    {
                        isfull = false;
                        break;
                    }
                }
                if (isfull)
                {
                    lines++;
                }
                else
                {
                    for (int j = 1; j < 11; j++)
                    {
                        tmpTiles[tempi, j] = tiles[i, j];
                    }
                    tempi--;
                }
            }
            if (lines > 0)
            {
                int topLine = GetTopLine();
                HidePanelTile(topLine);
                for (int i = 1; i < 21; i++)
                {
                    for (int j = 1; j < 11; j++)
                    {
                        tiles[i, j] = tmpTiles[i, j];
                    }
                }

                score += GetScoreFromLine(lines);
                lblScore.Text = score.ToString();
                DrawPanelTitle();

                int LevelScore = 5000;
                if (score >= LevelScore)
                {
                    _GameSpeed += score / LevelScore;
                    lblSpeed.Text = _GameSpeed.ToString();
                    timer1.Interval = 500 - _GameSpeed * 50;
                }
                ShowData();
            }
        }


        private int GetScoreFromLine(int lines)
        {
            switch (lines)
            {
                case 1:
                    score=100;
                    break;
                case 2:
                    score = 300;
                    break;
                case 3:
                    score = 600;
                    break;
                case 4:
                    score = 1000;
                    break;
                default:
                    score = 0;
                    break;
            }

            return score;
        }
        private void DrawPanelTitle()
        {
            Graphics g = Graphics.FromHwnd(panel1.Handle);
            for (int i = 20; i > 0; i--)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (tiles[i, j] == 1)
                    {
                        Rectangle rect = new Rectangle((j-1) * teris_width, (i-2) * teris_height, teris_width, teris_height);
                        g.FillRectangle(new SolidBrush(Color.GreenYellow),rect);
                    }
                }
            }
        }

        private void HidePanelTile(int topLine)
        {
            Graphics g = Graphics.FromHwnd(panel1.Handle);
            int invalidate_height = (topLine - 1) * teris_height;
            Rectangle rect = new Rectangle(0, invalidate_height, panel1.Width, panel1.Height - invalidate_height);

            g.FillRectangle(new SolidBrush(Color.Black), rect);
        }

        private int GetTopLine()
        {
            int topLine = 20;
            for (int i = 20; i > 0; i--)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (tiles[i, j] == 1)
                    {
                        topLine--;
                        break;
                    }                    
                }
            }

            return topLine;
        }

        private void ShowData()
        {
            listView1.Items.Clear();
            for (int i = 1; i < 22; i++)
            {
                ListViewItem item = new ListViewItem();
                if (tiles[i, 0] == 1)
                    item.Text = "1";
                else
                    item.Text = "0";
                for (int j = 1; j < 12; j++)
                {
                    if (tiles[i, j] == 1)
                        item.SubItems.Add("1");
                    else
                        item.SubItems.Add("0");
                }

                listView1.Items.Add(item);
            }
            label3.Text = GetTopLine().ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                timer1.Enabled = false;
            }
        }
    }
}