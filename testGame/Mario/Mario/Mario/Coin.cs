using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Coin: CObject
    {
        public Coin(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0, 6);
            m_Object = EObject.COIN;

            m_Physic.Position = _position;

            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Coin);

            m_Status = EStatus.LIVE;

        }   

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            this.UpdateAnimation(_gameTime);
        }

        public override void UpdateCollision(CObject _object)
        {
            if (m_Status == EStatus.DIE)
            {
                return;
            }

            ECollision dircol = Physic.CheckCollision(this, _object);

            switch (_object.Object)
            {
                case EObject.MARIO:
                    {
                        switch (dircol)
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
                default:
                    break;
            }
        }
    }
}
