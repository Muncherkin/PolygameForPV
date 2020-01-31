using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygame
{
    public class BoxCollider2D : Component
    {
        public int GetHeight { get => myHeight; }
        public int GetWidth { get => myWidth; }
        int myHeight;
        int myWidth;
        public BoxCollider2D (int aWidth, int aHeight)
        {
            myHeight = aHeight;
            myWidth = aWidth;
        }
    }
}
