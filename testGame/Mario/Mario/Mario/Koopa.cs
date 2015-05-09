using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Koopa : CObject
    {
        float m_DieTimeCounter;
        float xVelocityCurrent;

        public Koopa(Vector2 _position)
        {
            m_Object = EObject.KOOPA;

            m_Animation.IndexFrameBegin = 0;
            m_Animation.IndexFrameCurrent = 0;
            m_Animation.IndexFrameEnd = 1;

            m_Physic.Velocity = new Vector2(0.1f, 0.0f);
            
            m_Physic.Position = _position;

            //m_Sprite.FrameSize = new Vector2(50, 72);
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Koopa);

            m_Status = EStatus.LIVE;
            xVelocityCurrent = 0.0f;

            m_DieTimeCounter = 0;
            m_Animation.TimeChangeFrame = 400.0f;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;


            if (this.Physic.Position.Y > GlobalVariable.GetInstance().ScreenSize.Y && this.m_Status == EStatus.KOOPA_BEFORE_DIE)
	        {
                this.Status = EStatus.DIE;
	        }

            if (m_Status == EStatus.BEFORE_DIE)
            {
                if (m_Physic.Velocity.X == 0)
                {
                    m_DieTimeCounter += deltaTime;
                }
                else
                {
                    m_DieTimeCounter = 0 ;
                }
            }

            if (m_DieTimeCounter >= 5000.0f)
            {
                m_Status = EStatus.LIVE;
                m_Sprite.FrameSize = new Vector2(50.0f, 72.0f);

                m_Physic.Velocity = new Vector2(xVelocityCurrent, m_Physic.Velocity.Y);

                m_Animation.SetIndexFrame(0, 1);
                m_DieTimeCounter = 0;
            }

            m_Animation.UpdateAnimation(_gameTime);
        }
        
        public override void UpdateCollision(CObject _object)
        {
            base.UpdateCollision(_object);

            if (this.Status == EStatus.DIE || this.Status == EStatus.KOOPA_BEFORE_DIE)
            {
                return;
            }

            ECollision dirCol = Physic.CheckCollision(this, _object);

            if (m_Status != EStatus.LIVE)
            {
                m_Animation.TimeChangeFrame = 50;
                m_Sprite.Origin = new Vector2(50.0f / 2, 50.0f / 2);
            }
            else
            {
                m_Animation.TimeChangeFrame = 100;
                m_Sprite.Origin = new Vector2(50.0f / 2, 72.0f / 2);
            }

            if (m_Physic.Velocity.X > 0)
            {
                m_Sprite.SpriteEffect = SpriteEffects.None;
            }
            else if(m_Physic.Velocity.X < 0)
            {
                m_Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
            }
            
            switch (_object.Object)
            {
                case EObject.MARIO:
                    switch (dirCol)
	                {
                        case ECollision.TOP:
                            {
                                switch (_object.Status)
                                {
                                    case EStatus.DIE:
                                        break;
                                    case EStatus.LIVE:
                                        {
                                            if (this.m_Status == EStatus.LIVE)
                                            {
                                                xVelocityCurrent = m_Physic.Velocity.X; 
                                            }
                                            this.m_Status = EStatus.BEFORE_DIE;
                                            this.m_Sprite.FrameSize = new Vector2(50.0f, 50.0f);
                                            this.m_Sprite.Origin = new Vector2(50.0f / 2, 50.0f / 2);
                                            this.m_Physic.Velocity = new Vector2(0.0f, 0.0f);
                                            this.m_Physic.Accelarate = new Vector2(0.0f, 0.005f);
                                            this.m_Physic.Position = new Vector2(m_Physic.Position.X, 500.0f);
                                            this.m_Animation.SetIndexFrame(2, 4);
                                        }
                                        break;
                                    case EStatus.BEFORE_DIE:
                                        break;
                                    case EStatus.BEFORE_DIE1:
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case ECollision.BOTTOM:
                            break;
                        case ECollision.LEFT:
                            {
                                switch (_object.Status)
                                {
                                    case EStatus.DIE:
                                        break;
                                    case EStatus.LIVE: ///////////////////////////////////////////////////
                                        {
                                            if (this.Status == EStatus.BEFORE_DIE)
                                            {
                                                this.Physic.Position = new Vector2(m_Physic.Position.X + 10, m_Physic.Position.Y);
                                                this.Physic.Velocity = new Vector2(0.5f, this.Physic.Velocity.Y);
                                                this.Status = EStatus.BEFORE_DIE1;
                                            }
                                        }
                                        break;
                                    case EStatus.BEFORE_DIE:
                                        break;
                                    case EStatus.BEFORE_DIE1:
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case ECollision.RIGHT:
                            {
                                switch (_object.Status)
                                {
                                    case EStatus.DIE:
                                        break;
                                    case EStatus.LIVE:
                                        {
                                            if (this.Status == EStatus.BEFORE_DIE)
                                            {
                                                this.Physic.Position = new Vector2(m_Physic.Position.X - 10, m_Physic.Position.Y);
                                                this.Physic.Velocity = new Vector2(-0.5f, this.Physic.Velocity.Y);
                                                this.Status = EStatus.BEFORE_DIE1; 
                                            }
                                        }
                                        break;
                                    case EStatus.BEFORE_DIE:
                                        break;
                                    case EStatus.BEFORE_DIE1:
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case ECollision.NONE:
                            break;
                        default:
                            break;
	                }
                    break;
                case EObject.PIPE:
                case EObject.COIN_BRICK:
                case EObject.FLOWER_BRICK:
                case EObject.GREEN_BRICK:
                case EObject.RED_BRICK:
                case EObject.BRICK:
                    {
                        #region MyRegion
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                {

                                }
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.Physic.Velocity.Y > 0)
                                    {
                                        this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0.0f);
                                        this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.0f);
                                    }
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2 - this.Sprite.FrameSize.Y / 2 + 1);
                                }
                                break;
                            case ECollision.LEFT:
                                {
                                    if (_object.Physic.Position.Y == this.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1)
                                    {
                                        return;
                                    }
                                    m_Sprite.SpriteEffect = SpriteEffects.None;
                                    if (m_Status == EStatus.LIVE)
                                    {
                                        this.Physic.Velocity = new Vector2(0.1f, this.m_Physic.Velocity.Y);
                                    }
                                    else
                                    {
                                        this.Physic.Velocity = new Vector2(0.5f, this.m_Physic.Velocity.Y);            
                                    }
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    if (_object.Physic.Position.Y == this.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1)
                                    {
                                        return;
                                    }
                                    m_Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
                                    if (m_Status == EStatus.LIVE)
                                    {
                                        this.Physic.Velocity = new Vector2(-0.1f, this.m_Physic.Velocity.Y);
                                    }
                                    else
                                    {
                                        this.Physic.Velocity = new Vector2(-0.5f, this.m_Physic.Velocity.Y);
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.005f);
                                }
                                break;
                            default:
                                break;
                        } 
                        #endregion
                    }
                    break;
                case EObject.GOOMBA:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                break;
                            case ECollision.LEFT:
                                {
                                    if (this.m_Status == EStatus.LIVE)
                                    {
                                        this.m_Physic.Velocity = new Vector2(0.1f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status == EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1)
                                    {
                                        this.m_Physic.Velocity = new Vector2(0.5f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status != EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1)
                                    {
                                        this.Physic.Velocity = new Vector2(0.0f, -1.0f);
                                        this.Animation.SetIndexFrame(3);
                                        this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                        this.Status = EStatus.KOOPA_BEFORE_DIE;
                                    }
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    if (this.m_Status == EStatus.LIVE)
                                    {
                                        this.m_Physic.Velocity = new Vector2(-0.1f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status == EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1)
                                    {
                                        this.m_Physic.Velocity = new Vector2(-0.5f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status != EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1)
                                    {
                                        this.Physic.Velocity = new Vector2(0.0f, -1.0f);
                                        this.Animation.SetIndexFrame(3);
                                        this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                        this.Status = EStatus.KOOPA_BEFORE_DIE;
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.005f);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.KOOPA:
                    {
                        #region MyRegion
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                break;
                            case ECollision.LEFT:
                                {
                                    if ((this.m_Status == EStatus.LIVE && _object.Status == EStatus.LIVE) || (this.m_Status == EStatus.LIVE && _object.Status == EStatus.BEFORE_DIE))
                                    {
                                        this.m_Physic.Velocity = new Vector2(0.1f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status == EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1)
                                    {
                                        this.m_Physic.Velocity = new Vector2(0.5f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status != EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1 )
                                    {
                                        this.Physic.Velocity = new Vector2(0.0f, -1.0f);
                                        this.Animation.SetIndexFrame(3);
                                        this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                        this.Status = EStatus.KOOPA_BEFORE_DIE;
                                    }
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    if ((this.m_Status == EStatus.LIVE && _object.Status == EStatus.LIVE) || (this.m_Status == EStatus.LIVE && _object.Status == EStatus.BEFORE_DIE))
                                    {
                                        this.m_Physic.Velocity = new Vector2(-0.1f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status == EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1)
                                    {
                                        this.m_Physic.Velocity = new Vector2(-0.5f, m_Physic.Velocity.Y);
                                    }
                                    else if (this.m_Status != EStatus.BEFORE_DIE1 && _object.Status == EStatus.BEFORE_DIE1)
                                    {
                                        this.Physic.Velocity = new Vector2(0.0f, -1.0f);
                                        this.Animation.SetIndexFrame(3);
                                        this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                        this.Status = EStatus.KOOPA_BEFORE_DIE;
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.005f);
                                }
                                break;
                            default:
                                break;
                        }
                        #endregion
                    }
                    break;
                case EObject.BULLET:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                            case ECollision.BOTTOM:
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    this.Physic.Velocity = new Vector2(0.0f, -1.0f);
                                    this.Animation.SetIndexFrame(3);
                                    this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                    this.Status = EStatus.KOOPA_BEFORE_DIE;
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
