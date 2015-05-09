using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Mario
{
    class Brick: CObject
    {
        public Brick(Vector2 _position)
            : base()
        {
            m_Object = EObject.BRICK;
            m_Status = EStatus.LIVE;
            m_Physic.Position = _position;

            //m_Sprite.FrameSize = new Vector2(150.0f, 100.0f);
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_BaseBrick);
        }

        public override void UpdateCollision(CObject _object)
        {
            //base.UpdateCollision(_object);

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
