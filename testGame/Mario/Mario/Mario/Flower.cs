using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Mario
{
    class Flower: CObject
    {
        public Flower(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0, 3);
            m_Object = EObject.FLOWER;
            m_Physic.Position = _position;
            m_Physic.Velocity = new Vector2(0.0f, 0.0f);
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Flower);
            m_Status = EStatus.LIVE;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            this.UpdateAnimation(_gameTime);

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
                                    if (this.Status == EStatus.LIVE)
                                    {
                                        this.Status = EStatus.DIE; 
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.QUESTION:
                    break;
                case EObject.GREEN_BRICK:
                    break;
                case EObject.RED_BRICK:
                    break;
                case EObject.FLOWER_BRICK:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.Physic.Velocity.Y > 0)
                                    {
                                        this.Physic.Velocity = new Vector2(0.0f, 0.0f);
                                        this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.0f);
                                    }
                                    //this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2 - this.Sprite.FrameSize.Y / 2 + 1);
                                }
                                break;
                            case ECollision.LEFT:
                                break;
                            case ECollision.RIGHT:
                                break;
                            case ECollision.NONE:
                                {
                                    //this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.009f);
                                }
                                break;
                            default:
                                break;
                        }
                    } 
                    break;
                case EObject.COIN_BRICK:
                    break;
                case EObject.BRICK:
                    break;
                case EObject.GOOMBA:
                    break;
                case EObject.GREEN_MUSH_ROOM:
                    break;
                case EObject.RED_MUSH_ROOM: 
                    break;
                case EObject.KOOPA:
                    break;
                case EObject.PIPE:
                    break;
                case EObject.COIN:
                    break;
                default:
                    break;
            }
        }
    }
}
