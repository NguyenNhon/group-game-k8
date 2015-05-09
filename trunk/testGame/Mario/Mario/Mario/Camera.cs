using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Camera
    {
        private static Camera m_Camera;
        private int m_Left;
        private Matrix m_TransformMatrix;
        private int deltaPosition;

        public int Left
        {
            get { return m_Left; }
            set { m_Left = value; }
        }
        
        public int DeltaPosition
        {
            get { return deltaPosition; }
            set { deltaPosition = value; }
        }

        public Matrix TransformMatrix
        {
            get { return m_TransformMatrix; }
            set { m_TransformMatrix = value; }
        }

        private Camera()
        {
            m_TransformMatrix = new Matrix();
            m_TransformMatrix.M11 = 1;
            m_TransformMatrix.M22 = 1;
            m_TransformMatrix.M33 = 1;
            m_TransformMatrix.M44 = 1;
            m_Left = 0;
            deltaPosition = 0;
        }

        public static Camera GetInstance()
        {
            if (m_Camera == null)
            {
                m_Camera = new Camera();
            }
            return m_Camera;
        }

        public void ResetCamera()
        {
            m_Left = 0;
            deltaPosition = 0;
        }

        public Rectangle GetRectangle()
        {
            Rectangle result = new Rectangle(m_Left, 0, 2 * GlobalVariable.GetInstance().ScreenSize.X,  GlobalVariable.GetInstance().ScreenSize.Y);
            return result;
        }

        public void SetMatrix(Vector2 _positionMario)
        {
            if (_positionMario.X > m_Left + GlobalVariable.GetInstance().ScreenSize.X / 2)
            {
                deltaPosition = -(int)(_positionMario.X - GlobalVariable.GetInstance().ScreenSize.X / 2);
                m_Left = -((int)m_TransformMatrix.M41);
            }

            //if (_positionMario.X > GlobalVariable.GetInstance().ScreenSize.X / 2)
            //{
            //    deltaPosition = -(int)(_positionMario.X - GlobalVariable.GetInstance().ScreenSize.X / 2);
            //}

            m_TransformMatrix.M41 = deltaPosition;
            
        }
    }
}
