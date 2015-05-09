using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Mario
{
    
    class Animation
    {
        protected float m_TimeChangeFrame;
        float distanceTimeCurrently;
        protected int m_IndexFrameCurrent;
        protected int m_IndexFrameBegin;
        protected int m_IndexFrameEnd;

        public float TimeChangeFrame
        {
            get { return m_TimeChangeFrame; }
            set { m_TimeChangeFrame = value; }
        }

        public int IndexFrameEnd
        {
            get { return m_IndexFrameEnd; }
            set { m_IndexFrameEnd = value; }
        }

        public int IndexFrameCurrent
        {
            get { return m_IndexFrameCurrent; }
            set { m_IndexFrameCurrent = value; }
        }

        public int IndexFrameBegin
        {
            get { return m_IndexFrameBegin; }
            set { m_IndexFrameBegin = value; }
        }

        public Animation()
        {
            m_IndexFrameBegin = 0;
            m_IndexFrameCurrent = 0;
            m_IndexFrameEnd = 0;
            m_TimeChangeFrame = 100.0f;
        }

        public void Initialize(float _widthTextureSize, float _widthFrameSize)
        {
            //m_IndexFrameEnd = (int)(_widthTextureSize / _widthFrameSize);
        }

        public void UpdateAnimation(GameTime _gameTime)
        {
            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;
            distanceTimeCurrently += deltaTime;

            if (distanceTimeCurrently >= m_TimeChangeFrame)
            {
                if (m_IndexFrameCurrent >= m_IndexFrameEnd)
                {
                    m_IndexFrameCurrent = m_IndexFrameBegin;
                }
                else
                {
                    m_IndexFrameCurrent++;
                }
                distanceTimeCurrently = 0;
            }
        }

        public void SetIndexFrame(int _frameBegin, int _frameEnd)
        {
            m_IndexFrameBegin = _frameBegin;
            m_IndexFrameCurrent = _frameBegin;
            m_IndexFrameEnd = _frameEnd;
        }

        public void SetIndexFrame(int _frameCurrent)
        {
            m_IndexFrameBegin = m_IndexFrameCurrent = m_IndexFrameEnd = _frameCurrent;
        }
    }
}
