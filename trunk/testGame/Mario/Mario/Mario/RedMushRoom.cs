using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class RedMushRoom: CObject
    {
        public RedMushRoom(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0);
            m_Object = EObject.RED_MUSH_ROOM;
            m_Physic.Position = _position;
            m_Physic.Velocity = new Vector2(0.1f, 0.0f);
            m_Physic.Accelarate = new Vector2(0.0f, 0.009f);
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_GreenMushRoom);
            m_Status = EStatus.LIVE;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            if (this.Physic.Position.Y > GlobalVariable.GetInstance().ScreenSize.Y)
            {
                this.Status = EStatus.DIE;
            }
        }

        public override void UpdateCollision(CObject _object)
        {
            base.UpdateCollision(_object);

            if (this.Status == EStatus.DIE)
            {
                return;
            }

            ECollision dirCol = Physic.CheckCollision(this, _object);

            switch (_object.Object)
            {
                case EObject.MARIO:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                            case ECollision.BOTTOM:
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    this.Status = EStatus.DIE;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.GREEN_BRICK:
                case EObject.RED_BRICK:
                case EObject.COIN_BRICK:
                case EObject.BRICK:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
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
                                    this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.009f);
                                }
                                break;
                            default:
                                break;
                        }
                    } 
                    break;
                case EObject.KOOPA:
                case EObject.GOOMBA:
                case EObject.GREEN_MUSH_ROOM:
                case EObject.RED_MUSH_ROOM:
                    //{
                    //    switch (dirCol)
                    //    {
                    //        case ECollision.TOP:
                    //            {
                    //            }
                    //            break;
                    //        case ECollision.BOTTOM:
                    //            {
                    //            }
                    //            break;
                    //        case ECollision.LEFT:
                    //            {
                    //                if (_object.Physic.Position.Y == this.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1)
                    //                {
                    //                    return;
                    //                }
                    //                this.Physic.Velocity = new Vector2(0.1f, this.m_Physic.Velocity.Y);
                    //            }
                    //            break;
                    //        case ECollision.RIGHT:
                    //            {
                    //                if (_object.Physic.Position.Y == this.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1)
                    //                {
                    //                    return;
                    //                }
                    //                this.Physic.Velocity = new Vector2(-0.1f, this.m_Physic.Velocity.Y);
                    //            }
                    //            break;
                    //        case ECollision.NONE:
                    //            {
                    //                this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.009f);
                    //            }
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //} 
                    break;
                //case EObject.KOOPA:
                //    {
                //        switch (dirCol)
                //        {
                //            case ECollision.TOP:
                //                break;
                //            case ECollision.BOTTOM:
                //                break;
                //            case ECollision.LEFT:
                //                {
                //                    if (_object.Status == EStatus.LIVE || _object.Status == EStatus.BEFORE_DIE)
                //                    {
                //                        this.Velocity = new Vector2(0.1f, this.Physic.Velocity.Y);
                //                    }
                //                }
                //                break;
                //            case ECollision.RIGHT:
                //                {
                //                    if (_object.Status == EStatus.LIVE || _object.Status == EStatus.BEFORE_DIE)
                //                    {
                //                        this.Velocity = new Vector2(-0.1f, this.Physic.Velocity.Y);
                //                    }
                //                }
                //                break;
                //            case ECollision.NONE:
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //    break;
                case EObject.QUESTION:
                    break;
                case EObject.PIPE:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                {
                                    this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0.1f);
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2);
                                }
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.Physic.Velocity.Y > 0)
                                    {
                                        this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0);
                                        this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.0f);
                                    }
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2 - this.Sprite.FrameSize.Y / 2 + 1);
                                }
                                break;
                            case ECollision.LEFT:
                                {
                                    this.Position = new Vector2(_object.Position.X + _object.Sprite.FrameSize.X / 2 + this.Sprite.FrameSize.X / 2, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0.1f, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    this.Position = new Vector2(_object.Position.X - _object.Sprite.FrameSize.X / 2 - this.Sprite.FrameSize.X / 2, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(-0.1f, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.009f);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.COIN:
                    break;
                default:
                    break;
            }
        }
    }
}
