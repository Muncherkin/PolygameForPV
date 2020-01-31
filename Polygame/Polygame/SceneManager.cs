using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Polygame
{
    public static class SceneManager
    {
        static string LEVEL_IMAGE = "/LevelScene.png";
        static string LEVEL_COLLISION_DIAGRAM = "/LevelCollisions.txt";
        static int myCurrentScene;
        static Texture2D[] myScenes;
        static Line[][] myLevelCollisions;
        public static void Initialize(int aSceneNumber)
        {
            myCurrentScene = aSceneNumber;
            string[] tempLevelNames =  Directory.GetDirectories("Levels");
            myScenes = new Texture2D[tempLevelNames.Length];
            myLevelCollisions = new Line[tempLevelNames.Length][];
            for(int i = 0; i < tempLevelNames.Length; i++)
            {
                using(StreamReader tempSR = new StreamReader(tempLevelNames[i] + LEVEL_IMAGE))
                {
                    myScenes[i] = Texture2D.FromStream(Game1.graphics.GraphicsDevice, tempSR.BaseStream);
                }
                List<Line> tempLineList = new List<Line>();
                using (StreamReader tempSR = new StreamReader(tempLevelNames[i] + LEVEL_COLLISION_DIAGRAM))
                {
                    while (!tempSR.EndOfStream)
                    {
                        tempLineList.Add(new Line(
                            new Point(Convert.ToInt32(tempSR.ReadLine()), Convert.ToInt32(tempSR.ReadLine())),
                            new Point(Convert.ToInt32(tempSR.ReadLine()), Convert.ToInt32(tempSR.ReadLine()))));
                    }
                }
                myLevelCollisions[i] = tempLineList.ToArray();
            }
        }

        public static void DrawScene(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.Draw(myScenes[myCurrentScene], Vector2.Zero, Color.White);
        }

        public static bool HasSceneCollided(BoxCollider2D aBoxCollider2D)
        {
            for(int i = 0; i < myLevelCollisions[myCurrentScene].Length; i++)
            {
                if (myLevelCollisions[myCurrentScene][i].Intersects(aBoxCollider2D))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
