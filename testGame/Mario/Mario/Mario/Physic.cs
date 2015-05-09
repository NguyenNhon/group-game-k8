using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Mario
{
    class Physic
    {
        protected Vector2 m_Position;
        protected Vector2 m_Velocity;
        protected Vector2 m_Accelarate;

        public Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public Vector2 Velocity
        {
            get { return m_Velocity; }
            set { m_Velocity = value; }
        }

        public Vector2 Accelarate
        {
            get { return m_Accelarate; }
            set { m_Accelarate = value; }
        }

        public Physic()
        {
            m_Position = Vector2.Zero;
            m_Velocity = Vector2.Zero;
            m_Accelarate = Vector2.Zero;
        }

        public void Update(GameTime _gameTime)
        {
            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;
            m_Position.X += m_Velocity.X * deltaTime;
            m_Position.Y += m_Velocity.Y * deltaTime;
            m_Velocity.X += m_Accelarate.X * deltaTime;
            m_Velocity.Y += m_Accelarate.Y * deltaTime;
        }

        public static ECollision CheckCollision(CObject _thisObject, CObject _object)
        {
            BOX box1 = new BOX(_thisObject);
            BOX box2 = new BOX(_object);
            float topDistance = Math.Abs(box2.bottom - box1.top);
            float bottomDistance = Math.Abs(box1.bottom - box2.top);
            float leftDistance = Math.Abs(box1.left - box2.right);
            float rightDistance = Math.Abs(box1.right - box2.left);

            float minDistance = Math.Min(Math.Min(topDistance, bottomDistance), Math.Min(leftDistance, rightDistance));

            Rectangle rectangle1 = new Rectangle((int)box1.left, (int)box1.top, (int)_thisObject.Sprite.FrameSize.X, (int)_thisObject.Sprite.FrameSize.Y);
            Rectangle rectangle2 = new Rectangle((int)box2.left, (int)box2.top, (int)_object.Sprite.FrameSize.X, (int)_object.Sprite.FrameSize.Y);

            if (rectangle1.Intersects(rectangle2))// || (box1.bottom == box2.top && ((box1.left < box2.right && box1.left > box2.left) || (box1.right < box2.right && box1.right > box2.left))))
            //if (AABBCheck(rectangle1, rectangle2))
            {
                if (minDistance == topDistance)
                {
                    return ECollision.TOP;
                }
                if (minDistance == bottomDistance)
                {
                    return ECollision.BOTTOM;
                }
                if (minDistance == leftDistance)
                {
                    return ECollision.LEFT;
                }
                if (minDistance == rightDistance)
                {
                    return ECollision.RIGHT;
                }
            }
            return ECollision.NONE;
        }

    }
}
