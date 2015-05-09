using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    class Goomba : CObject
    {
        float m_DieTimeCounter;

        public Goomba(Vector2 _position)
        {
            m_Object = EObject.GOOMBA;
            m_Status = EStatus.LIVE;

            m_Physic.Position = _position;
            m_Physic.Velocity = new Vector2(0.1f, 0.0f);
            m_Physic.Accelarate = new Vector2(0.0f, 0.005f);

            //m_Sprite.FrameSize = new Vector2(50.0f, 50.0f);
            //m_Sprite.Depth = 0.9f;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Goomba);

            m_Animation.IndexFrameBegin = 0;
            m_Animation.IndexFrameCurrent = 0;
            m_Animation.IndexFrameEnd = 1;
            m_Animation.TimeChangeFrame = 100.0f;
            
            m_DieTimeCounter = 0;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            m_Animation.UpdateAnimation(_gameTime);

            if (this.Physic.Position.Y > GlobalVariable.GetInstance().ScreenSize.Y)
            {
                this.Status = EStatus.DIE;
            }

            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;

            if (m_Status == EStatus.BEFORE_DIE)
            {
                m_Animation.SetIndexFrame(2);
                m_DieTimeCounter += deltaTime;
                this.Velocity = Vector2.Zero;
                this.Accelarate = Vector2.Zero;
                if (m_DieTimeCounter >= 500.0f)
                {
                    m_Status = EStatus.DIE;
                    m_DieTimeCounter = 0;
                }
            }
        }

        public override void UpdateCollision(CObject _object)
        {
            if (this.m_Status == EStatus.DIE || _object.Status == EStatus.DIE || this.Status == EStatus.BEFORE_DIE || this.Status == EStatus.BEFORE_DIE1)
            {
                return;
            }

            ECollision dirCol = Physic.CheckCollision(this, _object);

            switch (_object.Object)
            {
                case EObject.MARIO:
                    {
                        if (_object.Status == EStatus.BEFORE_DIE)
                        {
                            return;
                        }
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                {
                                    this.m_Status = EStatus.BEFORE_DIE;
                                    this.Velocity = new Vector2(0.0f, this.Velocity.Y);
                                }
                                break;
                            case ECollision.BOTTOM:
                                {
                                    this.m_Physic.Velocity = new Vector2(this.m_Physic.Velocity.X, -1.0f);
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
                case EObject.PIPE:
                case EObject.COIN_BRICK:
                case EObject.FLOWER_BRICK:
                case EObject.GREEN_BRICK:
                case EObject.RED_BRICK:
                case EObject.BRICK:
                    #region MyRegion
		            {
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
                                    this.Physic.Velocity = new Vector2(0.1f, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    if (_object.Physic.Position.Y == this.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1)
                                    {
                                        return;
                                    }
                                    this.Physic.Velocity = new Vector2(-0.1f, this.m_Physic.Velocity.Y);
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
                    #endregion
                case EObject.GOOMBA:
                    #region MyRegion
		            {
                        if (_object.Status == EStatus.BEFORE_DIE)
                        {
                            return;
                        }
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                break;
                            case ECollision.LEFT:
                                {
                                    if (_object.Physic.Position.Y == this.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1)
                                    {
                                        return;
                                    }
                                    this.Physic.Velocity = new Vector2(0.1f, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    if (_object.Physic.Position.Y == this.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1)
                                    {
                                        return;
                                    }
                                    this.Physic.Velocity = new Vector2(-0.1f, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    //this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.005f);
                                }
                                break;
                            default:
                                break;
                        }
                    } 
                    break;
                    #endregion
                case EObject.KOOPA:
                    #region MyRegion
                    {
                        if(_object.Status == EStatus.KOOPA_BEFORE_DIE)
                        {
                            return;
                        }
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                break;
                            case ECollision.LEFT:
                                {
                                    if (_object.Status == EStatus.LIVE || _object.Status == EStatus.BEFORE_DIE)
                                    {
                                        this.Velocity = new Vector2(0.1f, this.Physic.Velocity.Y);
                                    }
                                    else
                                    {
                                        this.Physic.Velocity = new Vector2(0.0f, -1.0f);
                                        this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                        this.Status = EStatus.BEFORE_DIE1;
                                    }
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    if (_object.Status == EStatus.LIVE || _object.Status == EStatus.BEFORE_DIE)
                                    {
                                        this.Velocity = new Vector2(-0.1f, this.Physic.Velocity.Y);
                                    }
                                    else
                                    {
                                        this.Physic.Velocity = new Vector2(0.0f, -1.0f);
                                        this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                        this.Status = EStatus.BEFORE_DIE1;
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Accelarate = new Vector2(0.0f, 0.005f);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                    #endregion
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
                                    this.Animation.SetIndexFrame(0);
                                    this.Sprite.SpriteEffect = SpriteEffects.FlipVertically;
                                    this.Status = EStatus.BEFORE_DIE1;
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
