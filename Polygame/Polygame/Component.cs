using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using System.Threading.Tasks;

namespace Polygame
{
    public abstract class Component
    {
        public GameObject GetGameObject { get => myGameObject; }
        protected GameObject myGameObject;

        public void Initialize(GameObject aGameObject)
        {
            myGameObject = aGameObject;
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch aSpriteBatch) { }
    }
}
