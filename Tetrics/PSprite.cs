using System;
using System.Collections.Generic;
using System.Text;

namespace Tetrics
{
    class PSprite:Sprite
    {
        public PSprite()
            : base()
        {
            tiles[0,0] = 0; tiles[0,1] = 1; tiles[0,2] = 1; tiles[0,3] = 0;
            tiles[1,0] = 0; tiles[1,1] = 1; tiles[1,2] = 0; tiles[1,3] = 0;
            tiles[2,0] = 0; tiles[2,1] = 1; tiles[2,2] = 0; tiles[2,3] = 0;
            tiles[3,0] = 0; tiles[3,1] = 0; tiles[3,2] = 0; tiles[3,3] = 0;
        }

        public override void Rotate()
        {
            //base.Rotate();
            if (Status == 2)
            {
                Status = 3;
                tiles[0,0] = 1; tiles[0,1] = 0; tiles[0,2] = 0; tiles[0,3] = 0;
                tiles[1,0] = 1; tiles[1,1] = 1; tiles[1,2] = 1; tiles[1,3] = 0;
                tiles[2,0] = 0; tiles[2,1] = 0; tiles[2,2] = 0; tiles[2,3] = 0;
                tiles[3,0] = 0; tiles[3,1] = 0; tiles[3,2] = 0; tiles[3,3] = 0;
            }
            else
                if (Status == 1)
                {
                    Status = 2;
                    tiles[0,0] = 0; tiles[0,1] = 1; tiles[0,2] = 0; tiles[0,3] = 0;
                    tiles[1,0] = 0; tiles[1,1] = 1; tiles[1,2] = 0; tiles[1,3] = 0;
                    tiles[2,0] = 1; tiles[2,1] = 1; tiles[2,2] = 0; tiles[2,3] = 0;
                    tiles[3,0] = 0; tiles[3,1] = 0; tiles[3,2] = 0; tiles[3,3] = 0;
                }
                else
                    if (Status == 0)
                    {
                        Status = 1;
                        tiles[0,0] = 0; tiles[0,1] = 0; tiles[0,2] = 0; tiles[0,3] = 0;
                        tiles[1,0] = 1; tiles[1,1] = 1; tiles[1,2] = 1; tiles[1,3] = 0;
                        tiles[2,0] = 0; tiles[2,1] = 0; tiles[2,2] = 1; tiles[2,3] = 0;
                        tiles[3,0] = 0; tiles[3,1] = 0; tiles[3,2] = 0; tiles[3,3] = 0;
                    }
                    else
                        if (Status == 3)
                        {
                            Status = 0;
                            tiles[0,0] = 0; tiles[0,1] = 1; tiles[0,2] = 1; tiles[0,3] = 0;
                            tiles[1,0] = 0; tiles[1,1] = 1; tiles[1,2] = 0; tiles[1,3] = 0;
                            tiles[2,0] = 0; tiles[2,1] = 1; tiles[2,2] = 0; tiles[2,3] = 0;
                            tiles[3,0] = 0; tiles[3,1] = 0; tiles[3,2] = 0; tiles[3,3] = 0;
                        }
        }

        public override Sprite Clone()
        {
            //throw new Exception("The method or operation is not implemented.");
            Sprite _temp = new PSprite();
            //_tempSp = this;
            _temp.X = X;
            _temp.Y = Y;
            _temp.Status = Status;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _temp.tiles[i, j] = tiles[i, j];
                }
            }


            return _temp;
        }
    }
}
