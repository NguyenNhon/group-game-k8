using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mario
{
    class Grass: CObject
    {
        public Grass(Vector2 _position)
        {
            m_Animation.SetIndexFrame(0, 2);
            m_Object = EObject.GRASS;
            m_Status = EStatus.LIVE;
            m_Physic.Position = _position;
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_Grass);
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            base.UpdateAnimation(_gameTime);
        }
    }
}
