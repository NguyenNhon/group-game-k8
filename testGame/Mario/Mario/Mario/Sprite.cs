using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    class Sprite
    {
        protected Texture2D m_Texture;
        protected Vector2 m_FrameSize;
        protected SpriteEffects m_SpriteEffect;
        protected Vector2 m_Scale;
        protected float m_Depth;
        protected Vector2 m_Origin;

        public Vector2 Origin
        {
            get { return m_Origin; }
            set { m_Origin = value; }
        }

        public float Depth
        {
            get { return m_Depth; }
            set { m_Depth = value; }
        }

        public Vector2 Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }

        public SpriteEffects SpriteEffect
        {
            get { return m_SpriteEffect; }
            set { m_SpriteEffect = value; }
        }

        public Texture2D Texture
        {
            get { return m_Texture; }
            set { m_Texture = value; }
        }

        public Vector2 FrameSize
        {
            get { return m_FrameSize; }
            set { m_FrameSize = value; }
        }

        public Sprite()
        {
            m_FrameSize = Vector2.Zero;
            m_Scale = new Vector2(1.0f, 1.0f);
            m_SpriteEffect = SpriteEffects.None;
            m_Depth = 0.0f;
            m_Origin = Vector2.Zero; //new Vector2(m_FrameSize.X / 2, m_FrameSize.Y / 2);
        }

        public Sprite(Sprite _copy)
        {
            m_Texture = _copy.Texture;
			m_FrameSize = _copy.FrameSize;
			m_SpriteEffect = _copy.SpriteEffect;
			m_Scale = _copy.Scale;
			m_Depth = _copy.Depth;
			m_Origin = _copy.Origin;
        }

        public void LoadContent(ContentManager _content, string _nameTexture)
        {
            m_Texture = _content.Load<Texture2D>(_nameTexture);
        }

        public void Draw(SpriteBatch _sprite, Vector2 _position, int _indexFrameCurrent)
        {
            //_sprite.Draw(m_Texture, _position, new Rectangle((int)(_indexFrameCurrent * m_FrameSize.X), 0, (int)m_FrameSize.X, (int)m_FrameSize.Y), Color.White, 0.0f, new Vector2(m_FrameSize.X / 2, m_FrameSize.Y / 2), m_Scale, m_SpriteEffect, m_Depth);
            _sprite.Draw(m_Texture, _position, new Rectangle((int)(_indexFrameCurrent * m_FrameSize.X), 0, (int)m_FrameSize.X, (int)m_FrameSize.Y), Color.White, 0.0f, m_Origin, m_Scale, m_SpriteEffect, m_Depth);
        }

    }
}
