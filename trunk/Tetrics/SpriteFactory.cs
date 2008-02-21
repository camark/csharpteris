using System;
using System.Collections.Generic;
using System.Text;

namespace Tetrics
{
    class SpriteFactory
    {
        public Sprite nextSprite
        {
            get
            {
                Random rnd = new Random();
                int i = rnd.Next(7);

                switch (i)
                {
                    case 0:
                        return new ISprite();
                    case 1:
                        return new LSprite();
                    case 2:
                        return new SSprite();
                    case 3:
                        return new ZSprite();
                    case 4:
                        return new PSprite();
                    case 5:
                        return new OSprite();
                    case 6:
                        return new TSprite();
                }

                return null;
            }
        }

    }
}
