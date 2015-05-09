using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class SmallMountain : CObject
    {
        public SmallMountain(Vector2 _position)
        {
            m_Object = EObject.SMALL_MOUNTAIN;
            this.Position = _position;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_SmallMountain);
        }
    }
}