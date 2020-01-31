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
    public class RigidBody : Component
    {
        const float TerminalVelocity = 20f;
        public Vector2 AccessVelocity { get => myVelocity; set => myVelocity = value; }
        Vector2 myVelocity;
        float myGravityScale;
        int myMass;
        float mySpeed = 10;
        public RigidBody(int aMass, float aGravityScale = 10f)
        {
            myMass = aMass;
            myGravityScale = aGravityScale;
        }

        public override void Update()
        {
            float tempDeltaTime = (float)Game1.GetGameTime.ElapsedGameTime.TotalSeconds;
            myVelocity.Y = Math.Min(myVelocity.Y + myGravityScale * myMass * tempDeltaTime, TerminalVelocity);
            KeyboardState tempKS = Keyboard.GetState();
            if (tempKS.IsKeyDown(Keys.W))
            {
                myVelocity -= Vector2.UnitY * mySpeed * 10 * tempDeltaTime;
            }
            if (tempKS.IsKeyDown(Keys.A))
            {
                myVelocity -= Vector2.UnitX * mySpeed * tempDeltaTime;
            }
            else if (tempKS.IsKeyDown(Keys.D))
            {
                myVelocity += Vector2.UnitX * mySpeed * tempDeltaTime;
            }
            else
            {
                myVelocity = new Vector2(0, myVelocity.Y);
            }
            BoxCollider2D tempBoxCollider = (BoxCollider2D)GetGameObject.GetComponent(typeof(BoxCollider2D));
            if (tempBoxCollider != null)
            {
                SceneManager.HasSceneCollided(tempBoxCollider);
            }
            GetGameObject.AccessPosition += myVelocity;
        }
    }
}