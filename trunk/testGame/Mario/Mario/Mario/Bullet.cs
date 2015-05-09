using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    class Bullet: CObject
    {
        float m_LifeTime;
        public Bullet(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0, 3);
            m_Object = EObject.BULLET;
            m_Physic.Position = _position;
            m_Physic.Accelarate = new Vector2(0.0f, 0.004f);
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Bullet);
            m_Status = EStatus.DIE;
            m_LifeTime = 0;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            m_Animation.UpdateAnimation(_gameTime);

            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;

            if (m_Status == EStatus.LIVE)
            {
                m_LifeTime += deltaTime;
                if (m_LifeTime > 3000)
                {
                    m_Status = EStatus.DIE;
                }
            }
        }

        public override void UpdateCollision(CObject _object)
        {
            base.UpdateCollision(_object);

            ECollision dirCol = Physic.CheckCollision(this, _object);

            switch (_object.Object)
            {
                case EObject.MARIO:
                    break;
                case EObject.GOOMBA:
                case EObject.KOOPA:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                break;
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    this.Status = EStatus.DIE;
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.COIN:
                    break;
                case EObject.QUESTION:
                case EObject.PIPE:
                case EObject.BRICK:
                case EObject.COIN_BRICK:
                case EObject.GREEN_BRICK:
                case EObject.RED_BRICK:
                case EObject.FLOWER_BRICK:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                {
                                    this.m_Physic.Velocity = new Vector2(this.m_Physic.Velocity.X, -0.7f);
                                }
                                break;
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    this.Status = EStatus.DIE;
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.GREEN_MUSH_ROOM:
                    break;
                case EObject.RED_MUSH_ROOM:
                    break;
                case EObject.FLOWER:
                    break;
                case EObject.BULLET:
                    break;
                default:
                    break;
            }

        }
    }
}
