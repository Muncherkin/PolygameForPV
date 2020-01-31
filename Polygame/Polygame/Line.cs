using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polygame
{
    public class Line
    {
        Point[] myPoints;
        public Line(Point aStartPoint, Point anEndPoint)
        {
            if(aStartPoint.ToVector2().Length() > anEndPoint.ToVector2().Length())
            {
                myPoints = new Point[] { anEndPoint, aStartPoint };
            }
            else
            {
                myPoints = new Point[] { aStartPoint, anEndPoint };
            }
        }

        public bool Intersects(BoxCollider2D aCollider)
        {
            RigidBody tempRB = (RigidBody)aCollider.GetGameObject.GetComponent(typeof(RigidBody));
            if(tempRB != null)
            {
                Vector2 _2 = aCollider.GetGameObject.AccessPosition;
                Vector2 _1 = aCollider.GetGameObject.AccessPosition + tempRB.AccessVelocity;

            }
            Vector2 _3 = aCollider.GetGameObject.AccessPosition +
                new Vector2(aCollider.GetWidth / 2.0f, aCollider.GetHeight / 2.0f);
            Vector2[] _4 = new Vector2[]
            {
                aCollider.GetGameObject.AccessPosition,
                aCollider.GetGameObject.AccessPosition + new Vector2(aCollider.GetWidth, 0),
                aCollider.GetGameObject.AccessPosition + new Vector2(0, aCollider.GetHeight),
                aCollider.GetGameObject.AccessPosition + new Vector2(aCollider.GetWidth, aCollider.GetHeight)
            };
            for (int i = 0; i < _4.Length; i++)
            {
                float tempD = ((_1.X - _2.X) * (_3.Y - _4[i].Y)) - ((_1.Y - _2.Y) * (_3.X - _4[i].X));
                if (tempD != 0)
                {
                    float tempT = ((_1.X - _3.X) * (_3.Y - _4[i].Y)) - ((_1.Y - _3.Y) * (_3.X - _4[i].X));
                    float tempU = -(((_1.X - _2.X) * (_1.Y - _3.Y)) - ((_1.Y - _2.Y) * (_1.X - _3.X)));
                    tempT /= tempD;
                    tempU /= tempD;
                    if (tempT >= 0.0 && tempT <= 1.0 && tempU >= 0.0 && tempU <= 1.0)
                    {
                        //Rectangle point in line
                        aCollider.GetGameObject.AccessPosition -= (_4[i] - new Vector2(_1.X + tempT * (_2.X - _1.X), _1.Y + tempT * (_2.Y - _1.Y))) / 2;                           
                    }
                }
            }         
            return false;
        }
    }
}