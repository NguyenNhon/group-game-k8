using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    class RedBrick: QuestionBrick
    {
        RedMushRoom m_RedMushRoom;
        bool m_LifeRed;

        public RedBrick(Vector2 _position): base(_position)
        {
            m_RedMushRoom = new RedMushRoom(new Vector2(_position.X, _position.Y - 50));
            m_Object = EObject.RED_BRICK;
            m_RedMushRoom.Status = EStatus.DIE;
            m_LifeRed = false;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            this.m_Animation.UpdateAnimation(_gameTime);


        }

        public override void UpdateCollision(CObject _object)
        {
            base.UpdateCollision(_object);

            ECollision dirCol = Physic.CheckCollision(this, _object);

            switch (_object.Object)
            {
                case EObject.MARIO:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.m_LifeRed == false)
                                    {
                                        this.m_RedMushRoom.Status = EStatus.LIVE;
                                        this.m_RedMushRoom.Velocity = new Vector2(0.1f, -1.0f);
                                        this.m_RedMushRoom.IdentityObject = MapLoader.maxID++;
                                        ObjectManager.GetInstance().AddObject(this.m_RedMushRoom);
                                        this.m_LifeRed = true;
                                    }
                                }
                                break;
                            case ECollision.LEFT:
                                break;
                            case ECollision.RIGHT:
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.BRICK:
                    break;
                case EObject.GOOMBA:
                    break;
                case EObject.KOOPA:
                    break;
                case EObject.QUESTION:
                    break;
                case EObject.PIPE:
                    break;
                case EObject.COIN:
                    break;
                case EObject.COIN_BRICK:
                    break;
                case EObject.GREEN_MUSH_ROOM:
                    break;
                case EObject.GREEN_BRICK:
                    break;
                case EObject.RED_MUSH_ROOM:
                    break;
                case EObject.RED_BRICK:
                    break;
                case EObject.FLOWER:
                    break;
                default:
                    break;
            }
        }
    }
}
