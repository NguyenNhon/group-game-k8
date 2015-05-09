using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mario
{
    class WinPole: CObject
    {
        public WinPole(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0);
            m_Object = EObject.WIN_POLE;
            m_Status = EStatus.LIVE;
            m_Physic.Position = _position;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_WinPole);
        }
    }
}
