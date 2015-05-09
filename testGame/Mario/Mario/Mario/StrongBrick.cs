using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mario
{
    class StrongBrick: CObject
    {
        public StrongBrick(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0);
            m_Object = EObject.STRONG_BRICK;
            m_Status = EStatus.LIVE;
            m_Physic.Position = _position;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_StrongBrick);
        }
    }
}
