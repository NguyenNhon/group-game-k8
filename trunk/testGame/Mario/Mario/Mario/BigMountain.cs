using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class BigMountain : CObject
    {
        public BigMountain(Vector2 _position)
        {
            m_Object = EObject.BIG_MOUNTAIN;
            this.Position = _position;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_BigMountain);
        }

    }
}
