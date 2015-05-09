using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Pipe: CObject
    {
        public Pipe(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0);

            m_Object = EObject.PIPE;

            m_Physic.Position = _position;
            m_Physic.Velocity = Vector2.Zero;
            m_Physic.Accelarate = Vector2.Zero;

            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Pipe);

            m_Status = EStatus.LIVE;
        }

        public override void Update(GameTime _gameTime)
        {
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
                default:
                    break;
            }
        }
    }
}
