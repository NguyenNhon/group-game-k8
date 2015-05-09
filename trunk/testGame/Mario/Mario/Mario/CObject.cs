using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Mario
{
    enum ECollision
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT,
        NONE
    }

    enum EObject
    {
        MARIO,
        BRICK,
        GOOMBA,
        KOOPA,
        QUESTION,
        PIPE,
        COIN,
        COIN_BRICK,
        GREEN_MUSH_ROOM,
        GREEN_BRICK,
        RED_MUSH_ROOM,
        RED_BRICK,
        FLOWER,
        FLOWER_BRICK,
        BULLET,
        BIG_MOUNTAIN,
        SMALL_MOUNTAIN,
        BUILDING,
        CLOUD,
        GRASS,
        STRONG_BRICK,
        WIN_POLE,
        BREAK_BRICK,
    }

    enum EStatus
    {
        DIE,
        LIVE,
        BEFORE_DIE,
        BEFORE_DIE1,
        BEFORE_DISPLAY,
        BEFORE_CHANGE_LEVEL,
        KOOPA_BEFORE_DIE,
    }

    struct BOX
    {
        public float top;
        public float bottom;
        public float left;
        public float right;

        public BOX(CObject _object)
        {
            top = _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2;
            bottom = _object.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2;
            left = _object.Physic.Position.X - _object.Sprite.FrameSize.X / 2;
            right = _object.Physic.Position.X + _object.Sprite.FrameSize.X / 2 ;        
        }
    }

    class CObject
    {
        protected Physic m_Physic;
        protected Sprite m_Sprite;
        protected Animation m_Animation;
        protected EObject m_Object;
        protected EStatus m_Status;
        private int m_IdentityObject;

        public int IdentityObject
        {
            get { return m_IdentityObject; }
            set { m_IdentityObject = value; }
        }
        public EStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public EObject Object
        {
            get { return m_Object; }
            set { m_Object = value; }
        }

        public Physic Physic
        {
            get { return m_Physic; }
            set { m_Physic = value; }
        }

        public Sprite Sprite
        {
            get { return m_Sprite; }
            set { m_Sprite = value; }
        }

        public Animation Animation
        {
            get { return m_Animation; }
            set { m_Animation = value; }
        }

        public Vector2 Velocity
        {
            get { return m_Physic.Velocity; }
            set { m_Physic.Velocity = value; }
        }

        public Vector2 Accelarate
        {
            get { return m_Physic.Accelarate; }
            set { m_Physic.Accelarate = value; }
        }

        public Vector2 Position
        {
            get { return m_Physic.Position; }
            set { m_Physic.Position = value; }
        }

        public CObject()
        {
            m_Physic = new Physic();
            m_Sprite = new Sprite();
            m_Animation = new Animation();
            m_Status = EStatus.LIVE;
        }

        public Rectangle GetRectangle()
        {
            Rectangle result = new Rectangle((int)(this.Position.X - this.Sprite.FrameSize.X / 2), (int)(this.Position.Y - this.Sprite.FrameSize.Y / 2), (int)this.Sprite.FrameSize.X, (int)this.Sprite.FrameSize.Y);
            return result;
        }

        public virtual void Initialize()
        {
            m_Animation.Initialize(m_Sprite.Texture.Width, m_Sprite.FrameSize.X);
        }

        public virtual void UpdateAnimation(GameTime _gameTime)
        {
            m_Animation.UpdateAnimation(_gameTime);
        }

        public virtual void LoadContent(ContentManager _content, string _nameTexture)
        {
            m_Sprite.LoadContent(_content, _nameTexture);
        }

        public virtual void Update(GameTime _gameTime)
        {
            m_Physic.Update(_gameTime);
            //m_Animation.UpdateAnimation(_gameTime);
        }

        public virtual void Draw(SpriteBatch _sprite)
        {
            m_Sprite.Draw(_sprite, m_Physic.Position, m_Animation.IndexFrameCurrent);
        }

        public virtual void UpdateCollision(CObject _object)
        {
 
        }

    }
}
