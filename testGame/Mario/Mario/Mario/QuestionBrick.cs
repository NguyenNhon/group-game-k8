using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Mario
{
    class QuestionBrick: CObject
    {
        public QuestionBrick(Vector2 _position)
        {
            m_Animation.SetIndexFrame(1, 2);
            m_Animation.TimeChangeFrame = 200;

            m_Object = EObject.QUESTION;

            m_Physic.Position = _position;
            m_Physic.Velocity = Vector2.Zero;
            m_Physic.Accelarate = Vector2.Zero;

            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_QuestionBrick);

            m_Status = EStatus.LIVE;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);

            m_Animation.UpdateAnimation(_gameTime);

        }

        public override void UpdateCollision(CObject _object)
        {
            
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
                                    this.Animation.SetIndexFrame(0);
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
                default:
                    break;
            }

        }
    }
}
