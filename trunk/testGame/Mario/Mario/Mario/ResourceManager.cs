using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    enum EResource
    {
        ID_MarioSmall,
        ID_MarioMedium,
        ID_MarioBig,
        ID_BaseBrick,
        ID_Goomba,
        ID_Koopa,
        ID_QuestionBrick,
        ID_Pipe,
        ID_Coin,
        ID_GreenMushRoom,
        ID_RedMushRoom,
        ID_Flower,
        ID_Bullet,
        ID_BigMountain,
        ID_SmallMountain,
        ID_Building,
        ID_Cloud,
        ID_Grass,
        ID_StrongBrick,
        ID_WinPole,
        ID_BreakBrick,
        ID_Count
    }

    //return SPRITE suitable with ID_...
    class ResourceManager
    {
        private static ResourceManager m_Instance;
        private Dictionary<EResource, Sprite> m_ListResource;

        private ResourceManager()
        {
            m_ListResource = new Dictionary<EResource, Sprite>();
            for (int i = 0; i < (int)EResource.ID_Count; i++)
            {
                m_ListResource.Add((EResource)i, new Sprite());
            }
        }

        public static ResourceManager GetInstance()
        {
            if (m_Instance == null)
            {
                m_Instance = new ResourceManager();
            }
            return m_Instance;
        }

        public Sprite GetSprite(EResource _resouce)
        {
            return new Sprite(m_ListResource[_resouce]);
        }

        public void LoadContent(ContentManager _content)
        {
            for (int i = 0; i < m_ListResource.Count; i++)
            {
                switch ((EResource)i)
                {
                    case EResource.ID_MarioSmall:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "MarioSmall");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Depth = 1.0f;
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                        }
                        break;
                    case EResource.ID_MarioMedium:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "MarioMedium");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 100.0f);
                            m_ListResource[(EResource)i].Depth = 1.0f;
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f);
                        }
                        break;
                    case EResource.ID_MarioBig:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "MarioBig");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 100.0f);
                            m_ListResource[(EResource)i].Depth = 1.0f;
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f);
                        }
                        break;
                    case EResource.ID_BreakBrick:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "BreakBrick");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                        }
                        break;
                    case EResource.ID_StrongBrick:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "StrongBrick");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                        }
                        break;
                    case EResource.ID_BaseBrick:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "BaseBrick");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(150.0f, 100.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(150.0f / 2, 50.0f);
                        }
                        break;
                    case EResource.ID_Goomba:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Goomba");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Depth = 0.9f;
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                        }
                        break;
                    case EResource.ID_Koopa:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Koopa");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 72.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 72.0f / 2);
                            m_ListResource[(EResource)i].Depth = 0.9f;
                        }
                        break;
                    case EResource.ID_QuestionBrick:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "QuestionBrick");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                            m_ListResource[(EResource)i].Depth = 1.0f;
                        }
                        break;
                    case EResource.ID_Pipe:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Pipe");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(100, 100);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f, 50.0f);
                        }
                        break;
                    case EResource.ID_Coin:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Coin");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                        }
                        break;
                    case EResource.ID_GreenMushRoom:
                    case EResource.ID_RedMushRoom:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "MushRoom");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                        }
                        break;
                    case EResource.ID_Flower:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Flower");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 50.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 50.0f / 2);
                            m_ListResource[(EResource)i].Depth = 0.9f;
                        }
                        break;
                    case EResource.ID_Bullet:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Bullet");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(26.0f, 26.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(13.0f, 13.0f);
                        }
                        break;
                    case EResource.ID_BigMountain:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "MountainLager");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(828.0f, 400.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(828.0f / 2, 200.0f);
                        }
                        break;
                    case EResource.ID_SmallMountain:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "MountainSmall");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(500.0f, 200.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(500.0f / 2, 100.0f);
                        }
                        break;
                    case EResource.ID_Building:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Building");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(500.0f, 550.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(500.0f / 2, 550.0f / 2);
                        }
                        break;
                    case EResource.ID_Cloud:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Cloud");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(100.0f, 80.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(100.0f / 2, 80.0f / 2);
                        }
                        break;
                    case EResource.ID_Grass:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "Grass");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(100.0f, 50.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f, 50.0f / 2);
                        }
                        break;
                    case EResource.ID_WinPole:
                        {
                            m_ListResource[(EResource)i].LoadContent(_content, "WinPole");
                            m_ListResource[(EResource)i].FrameSize = new Vector2(50.0f, 450.0f);
                            m_ListResource[(EResource)i].Origin = new Vector2(50.0f / 2, 450.0f / 2);
                        }
                        break;
                    default:
                        break;
                } 
            }
        }
    }
}
