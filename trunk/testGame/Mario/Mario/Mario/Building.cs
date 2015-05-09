using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mario
{
    class Building: CObject
    {
        public Building(Vector2 _position)
        {
            m_Object = EObject.BUILDING;
            m_Status = EStatus.LIVE;
            m_Physic.Position = _position;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Building);
        }
    }
}
