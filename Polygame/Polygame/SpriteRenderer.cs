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
    public class SpriteRenderer : Component
    {
        Texture2D mySprite;

        public SpriteRenderer(Texture2D aSprite)
        {
            mySprite = aSprite;
        }
        public override void Draw(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.Draw(mySprite, GetGameObject.AccessPosition, Color.White);
        }
    }
}
