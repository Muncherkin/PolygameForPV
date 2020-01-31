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
    public class GameObject
    {
        public Vector2 AccessPosition { get => myPosition; set => myPosition = value; } 
        Vector2 myPosition;

        List<Component> myComponents = new List<Component>();

        public GameObject(Vector2 aPosition)
        {
            myPosition = aPosition;
        }

        public void AddComponent(Component aComponent)
        {
            if(myComponents.FindAll(tempComponents => tempComponents.GetType() == aComponent.GetType()).Count == 0)
            {
                myComponents.Add(aComponent);
                myComponents.Last().Initialize(this);
            }
        }

        public Component GetComponent(Type aType)
        {
            return myComponents.Find(tempComponent => tempComponent.GetType() == aType);
        }
    }
}
