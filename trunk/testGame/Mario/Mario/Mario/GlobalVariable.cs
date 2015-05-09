using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    class GlobalVariable
    {
        private static GlobalVariable m_Instance;
        private Point m_ScreenSize;
        private int m_MarioLife;
        private int m_Identity;

        public int Identity
        {
            get { return m_Identity; }
            set { m_Identity = value; }
        }

        public Point ScreenSize
        {
            get { return m_ScreenSize; }
            set { m_ScreenSize = value; }
        }

        public int MarioLife
        {
            get { return m_MarioLife; }
            set { m_MarioLife = value; }
        }
        
        private GlobalVariable()
        {
            m_ScreenSize = new Point(800, 600);
            //m_ScreenSize = new Point(1280, 750);
            m_Identity = 300;
            m_MarioLife = 2;
        }

        public static GlobalVariable GetInstance()
        {
            if(m_Instance == null)
            {
                m_Instance = new GlobalVariable();
            }
            return m_Instance;
        }
    }
}
