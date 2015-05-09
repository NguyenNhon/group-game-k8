using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario
{
    class ObjectManager
    {
        private static ObjectManager m_Instance;
        List<CObject> m_ListObject;
        List<CObject> m_ListObjectUpdate;
        List<int> m_IdObjectUpdate;

        private ObjectManager()
        {
            m_ListObject = new List<CObject>();
            m_ListObjectUpdate = new List<CObject>();
            m_IdObjectUpdate = new List<int>();
        }

        public static ObjectManager GetInstance()
        {

            if(m_Instance == null)
            {
                m_Instance = new ObjectManager();
            }
            return m_Instance;
        }

        public void AddObject(CObject _object)
        {
            m_ListObject.Add(_object);
        }

        public void CheckCollision()
        {
            //for (int i = 0; i < m_ListObjectGame.Count; i++)
            //{
            //    for (int j = 0; j < m_ListObjectGame.Count; j++)
            //    {
            //        if (i != j)
            //        {
            //            m_ListObjectGame[i].UpdateCollision(m_ListObjectGame[j]);
            //        }
            //    }
            //}            
            for (int i = 0; i < m_ListObjectUpdate.Count; i++)
            {
                for (int j = 0; j < m_ListObjectUpdate.Count; j++)
                {
                    if (i != j)
                    {
                        if (m_ListObjectUpdate[i] != null && m_ListObjectUpdate[j] != null)
                        {
                            m_ListObjectUpdate[i].UpdateCollision(m_ListObjectUpdate[j]); 
                        }
                    }
                }
            }
        }

        public void DrawObject(SpriteBatch _sprite)
        {
            //for (int i = 0; i < m_ListObjectGame.Count; i++)
            //{
            //    if(m_ListObjectGame[i].Status != EStatus.DIE)
            //    {
            //        m_ListObjectGame[i].Draw(_sprite);
            //    }
            //}

            //for (int i = 0; i < m_ListObjectGame.Count; i++)
            //{
            //    if (m_ListObjectGame[i].Status == EStatus.DIE)
            //    {
            //        //m_ListObject.Remove(m_ListObjectGame[i]);
            //        //m_ListObjectGame.Remove(m_ListObjectGame[i]);
            //        //m_IdObject.Remove(i);
            //    }
            //}

            for (int i = 0; i < m_ListObjectUpdate.Count; i++)
            {
                if (m_ListObjectUpdate[i] != null || m_ListObjectUpdate[i].Status != EStatus.DIE)
                {
                    m_ListObjectUpdate[i].Draw(_sprite); 
                }
                if(m_ListObjectUpdate[i].Status == EStatus.DIE)
                {
                    m_ListObjectUpdate.Remove(m_ListObjectUpdate[i]);
                }
            }

            for (int i = 0; i < m_ListObject.Count; i++)
            {
                if (m_ListObject[i].Status == EStatus.DIE)
                {
                    m_ListObject.Remove(m_ListObject[i]);
                }
            }

            //for (int i = 0; i < m_ListObject.Count; i++)
            //{
            //    if (m_ListObject[i].Status != EStatus.DIE)
            //    {
            //        m_ListObject[i].Draw(_sprite);
            //    }
            //}

            //for (int i = 0; i < m_ListObject.Count; i++)
            //{
            //    if (m_ListObject[i].Status == EStatus.DIE)
            //    {
            //        m_ListObject.Remove(m_ListObject[i]);
            //    }
            //}

        }

        public bool IsExist(int _id)
        {
            for (int i = 0; i < m_IdObjectUpdate.Count; i++)
            {
                if (m_IdObjectUpdate[i] == _id)
                { 
                    return true; 
                }
            }
            return false;
        }

        public CObject GetMario()
        {
            for (int i = 0; i < m_ListObject.Count; i++)
            {
                if (m_ListObject[i].Object == EObject.MARIO)
                {
                    return m_ListObject[i];
                }
            }
            return null;
        }

        public void Update(GameTime _gameTime)
        {

            for (int i = 0; i < m_ListObject.Count; i++)
            {
                if (Camera.GetInstance().GetRectangle().Intersects(m_ListObject[i].GetRectangle()))
                {
                    if (!IsExist(m_ListObject[i].IdentityObject))
                    {
                        m_ListObjectUpdate.Add(m_ListObject[i]);
                        m_IdObjectUpdate.Add(m_ListObject[i].IdentityObject);
                    }
                }
            }

            for (int i = 0; i < m_ListObjectUpdate.Count; i++)
            {
                if (m_ListObjectUpdate[i] != null)
                {
                    m_ListObjectUpdate[i].Update(_gameTime); 
                }
            }

            //for (int i = 0; i < m_ListObject.Count; i++)
            //{
            //    m_ListObject[i].Update(_gameTime);
            //}
            //for (int i = 0; i < m_ListObject.Count; i++)
            //{
            //    if (IsExist(i))
            //    {
            //        continue;
            //    }
            //    if (Camera.GetInstance().GetRectangle().Intersects(m_ListObject[i].GetRectangle()))
            //    {
            //        m_ListObjectGame.Add(m_ListObject[i]);
            //        m_IdObject.Add(i);
            //    }
            //}

            

            //for (int i = 0; i < m_ListObjectGame.Count; i++)
            //{
            //    if (!Camera.GetInstance().GetRectangle().Intersects(m_ListObjectGame[i].GetRectangle()))
            //    {
            //        if (m_ListObjectGame[i].Object != EObject.MARIO)
            //        {
            //            m_ListObjectGame.Remove(m_ListObjectGame[i]);
            //            m_IdObject.Remove(i);
            //        }
            //    }
            //}

            //for (int i = 0; i < m_ListObjectGame.Count; i++)
            //{
            //     m_ListObjectGame[i].Update(_gameTime); 
            //}


        }
        
    }
}
