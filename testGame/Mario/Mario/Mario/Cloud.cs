using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mario
{
    class Cloud: CObject
    {
        public Cloud(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0, 2);
            m_Object = EObject.CLOUD;
            m_Status = EStatus.LIVE;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Cloud);
            m_Physic.Position = _position;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            base.UpdateAnimation(_gameTime);
        }
    }
}
