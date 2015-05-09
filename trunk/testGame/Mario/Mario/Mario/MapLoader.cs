using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Xml;

namespace Mario
{
    class MapLoader
    {
        XmlDocument map;
        static public int maxID = 0;
        public MapLoader()
        {
            map = new XmlDocument();
            map.Load("map.mr");

            XmlNode root = map.SelectSingleNode("ObjectManager");

            XmlNodeList nodeList = root.SelectNodes("GameObject");

            for (int i = 0; i < nodeList.Count; i++)
            {
                EObject ObjectID = (EObject)Enum.Parse(typeof(EObject), nodeList[i].Attributes["EObject"].Value, true);
                Vector2 Position = new Vector2(int.Parse(nodeList[i].Attributes["X"].Value), int.Parse(nodeList[i].Attributes["Y"].Value));
                
                if (ObjectID == EObject.MARIO)
                {
                    ObjectManager.GetInstance().AddObject(new Mario(Position));
                }
            }

            
            for (int i = 0; i < nodeList.Count; i++)
            {                
                EObject ObjectID = (EObject)Enum.Parse(typeof(EObject), nodeList[i].Attributes["EObject"].Value, true);
                Vector2 Position = new Vector2(int.Parse(nodeList[i].Attributes["X"].Value), int.Parse(nodeList[i].Attributes["Y"].Value));
                if (maxID < int.Parse(nodeList[i].Attributes["ID"].Value))
                {
                    maxID = int.Parse(nodeList[i].Attributes["ID"].Value) + 1;
                }
                switch (ObjectID)
                {
                    case EObject.BRICK:
                        {
                            CObject temp = new Brick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.GOOMBA:
                        {
                            //ObjectManager.GetInstance().AddObject(new Goomba(Position));
                            CObject temp = new Goomba(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.KOOPA:
                        {
                            //ObjectManager.GetInstance().AddObject(new Koopa(Position));
                            CObject temp = new Koopa(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.QUESTION:
                        {
                            CObject temp = new QuestionBrick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.PIPE:
                        {
                            CObject temp = new Pipe(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.COIN:
                        {
                            //ObjectManager.GetInstance().AddObject(new Coin(Position));
                            CObject temp = new Coin(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.COIN_BRICK:
                        {
                            //ObjectManager.GetInstance().AddObject(new CoinBrick(Position));
                            CObject temp = new CoinBrick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.GREEN_MUSH_ROOM:
                        {
                            CObject temp = new GreenMushRoom(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.GREEN_BRICK:
                        {
                            //ObjectManager.GetInstance().AddObject(new GreenBrick(Position));
                            CObject temp = new GreenBrick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.RED_MUSH_ROOM:
                        {
                            CObject temp = new RedMushRoom(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.RED_BRICK:
                        {
                            //ObjectManager.GetInstance().AddObject(new RedBrick(Position));
                            CObject temp = new RedBrick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.FLOWER:
                        {
                            CObject temp = new Flower(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.FLOWER_BRICK:
                        {
                            //ObjectManager.GetInstance().AddObject(new FlowerBrick(Position));
                            CObject temp = new FlowerBrick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.BULLET:
                        {
                            CObject temp = new Bullet(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.BIG_MOUNTAIN:
                        {
                            //ObjectManager.GetInstance().AddObject(new BigMountain(Position));
                            CObject temp = new BigMountain(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.SMALL_MOUNTAIN:
                        {
                            //ObjectManager.GetInstance().AddObject(new SmallMountain(Position));
                            CObject temp = new SmallMountain(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.BUILDING:
                        {
                            //ObjectManager.GetInstance().AddObject(new Building(Position));
                            CObject temp = new Building(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.CLOUD:
                        {
                            //ObjectManager.GetInstance().AddObject(new Cloud(Position));
                            CObject temp = new Cloud(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.GRASS:
                        {
                            //ObjectManager.GetInstance().AddObject(new Grass(Position));
                            CObject temp = new Grass(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.STRONG_BRICK:
                        {
                            //ObjectManager.GetInstance().AddObject(new StrongBrick(Position));
                            CObject temp = new StrongBrick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.WIN_POLE:
                        {
                            //ObjectManager.GetInstance().AddObject(new WinPole(Position));
                            CObject temp = new WinPole(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    case EObject.BREAK_BRICK:
                        {
                            //ObjectManager.GetInstance().AddObject(new BreakBrick(Position));
                            CObject temp = new BreakBrick(Position);
                            temp.IdentityObject = int.Parse(nodeList[i].Attributes["ID"].Value);
                            ObjectManager.GetInstance().AddObject(temp);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
