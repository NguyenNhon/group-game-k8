using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mario
{
    class BreakBrick: CObject
    {
        private float m_PopTime;
        private float m_StartPositionY;

        public BreakBrick(Vector2 _position)
        {
            m_Status = EStatus.LIVE;
            m_Object = EObject.BREAK_BRICK;
            m_Physic.Position = _position;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_BreakBrick);
            m_PopTime = 0;
            m_StartPositionY = _position.Y;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);

            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;

            if (this.Velocity.Y != 0)
            {
                m_PopTime += deltaTime;
                if (m_PopTime > 100)
                {
                    this.Velocity = new Vector2(0.0f, 0.1f);
                    if (this.Position.Y > this.m_StartPositionY)
                    {
                        this.Velocity = Vector2.Zero;
                        this.Position = new Vector2(this.Position.X, this.m_StartPositionY);
                        m_PopTime = 0;
                    }
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
                                    if (((Mario)_object).MarioLevel == 0)
                                    {
                                        this.Velocity = new Vector2(0.0f, -0.1f);
                                    }
                                    else
                                    {
                                        
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
                default:
                    break;
            }

        }
    }
}
