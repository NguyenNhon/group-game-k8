using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    class GreenBrick: QuestionBrick
    {
        GreenMushRoom m_GreenMushRoom;
        bool m_LifeGreen;
        //float m_DisplayTime;
        //Vector2 m_PositionNow;

        public GreenBrick(Vector2 _position): base(_position)
        {
            m_GreenMushRoom = new GreenMushRoom(new Vector2(_position.X, _position.Y - 5));
            m_Object = EObject.GREEN_BRICK;
            m_GreenMushRoom.Status = EStatus.DIE;
            m_LifeGreen = false;
            //m_DisplayTime = 0;
            //m_PositionNow = m_GreenMushRoom.Position;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            this.m_Animation.UpdateAnimation(_gameTime);

            //float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;

            //if (this.m_GreenMushRoom.Status == EStatus.BEFORE_DISPLAY)
            //{
            //    m_DisplayTime += deltaTime;
            //    m_PositionNow.Y -= 1;
            //    this.m_GreenMushRoom.Position = m_PositionNow;
            //    if (m_DisplayTime >= 200)
            //    {
            //        this.m_GreenMushRoom.Status = EStatus.LIVE;
            //    }
            //}

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
                                    if (this.m_LifeGreen == false)
                                    {
                                        this.m_GreenMushRoom.Status = EStatus.BEFORE_DISPLAY;
                                        this.m_GreenMushRoom.Velocity = new Vector2(0.1f, -1.0f);
                                        m_GreenMushRoom.IdentityObject = MapLoader.maxID++;
                                        ObjectManager.GetInstance().AddObject(this.m_GreenMushRoom);
                                        this.m_LifeGreen = true;
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
