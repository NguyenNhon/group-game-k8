using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class FlowerBrick: QuestionBrick
    {
        Flower m_Flower;
        bool m_LifeFlower;
        float m_PositionNow;

        public FlowerBrick(Vector2 _position): base(_position)
        {
            m_Flower = new Flower(new Vector2(_position.X, _position.Y - 10));
            m_Flower.Physic.Accelarate = Vector2.Zero;
            m_PositionNow = m_Flower.Position.Y;
            m_Object = EObject.FLOWER_BRICK;
            m_Flower.Status = EStatus.DIE;
            m_LifeFlower = false;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            this.m_Animation.UpdateAnimation(_gameTime);

            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;

            if (this.m_Flower.Status == EStatus.BEFORE_DISPLAY)
            {
                if (this.m_Flower.Position.Y < this.Position.Y + this.Sprite.FrameSize.Y / 2 && this.m_Flower.Position.Y > this.Position.Y - this.Sprite.FrameSize.Y / 2 - this.m_Flower.Sprite.FrameSize.Y / 2)
                {
                    this.m_Flower.Physic.Velocity = new Vector2(0.0f, 0.0f);
                    this.m_Flower.Physic.Accelarate = new Vector2(0.0f, 0.0f);
                    this.m_Flower.Position = new Vector2(this.m_Flower.Position.X, m_PositionNow);
                    m_PositionNow -= 2.0f;
                }
                else
                {
                    this.m_Flower.Position = new Vector2(this.Position.X, this.Position.Y - this.Sprite.FrameSize.Y / 2 - this.m_Flower.Sprite.FrameSize.Y / 2);
                    this.m_Flower.Status = EStatus.LIVE;
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
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.m_LifeFlower == false)
                                    {
                                        this.m_Flower.Status = EStatus.BEFORE_DISPLAY;
                                        this.m_Flower.IdentityObject = MapLoader.maxID++;
                                        ObjectManager.GetInstance().AddObject(this.m_Flower);
                                        this.m_LifeFlower = true;
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
