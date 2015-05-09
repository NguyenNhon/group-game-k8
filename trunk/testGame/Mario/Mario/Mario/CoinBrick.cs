using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Mario
{
    class CoinBrick : QuestionBrick 
    {
        Coin m_Coin;
        float m_Time;
        bool m_IsActive;

        public CoinBrick(Vector2 _position): base(_position)
        {
            m_Coin = new Coin(new Vector2(_position.X, _position.Y - 50));            
            m_Object = EObject.COIN_BRICK;
            m_Time = 0;
            m_Coin.Status = EStatus.DIE;
            m_Coin.Animation.SetIndexFrame(0, 6);
            m_Coin.Animation.TimeChangeFrame = 50;
            m_IsActive = false;
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            this.UpdateAnimation(_gameTime);

            float _deltaTime = _gameTime.ElapsedGameTime.Milliseconds;

            if (this.m_Coin.Status == EStatus.LIVE)
            {
                m_Time += _deltaTime;
                if (m_Time > 200)
                {
                    this.m_Coin.Status = EStatus.DIE;
                    m_Time = 0;
                }
            }
        }

        public override void UpdateCollision(CObject _object)
        {
            base.UpdateCollision(_object);

            ECollision dirCol = Physic.CheckCollision(this, _object);

            switch (_object.Object)
            {
                case EObject.MARIO:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (!m_IsActive)
                                    {
                                        m_Coin.Status = EStatus.LIVE;
                                        m_Coin.Velocity = new Vector2(0.0f, -0.5f);
                                        GlobalVariable.GetInstance().Identity++;
                                        m_Coin.IdentityObject = MapLoader.maxID++;
                                        ObjectManager.GetInstance().AddObject(m_Coin);
                                        m_IsActive = true;
                                    }
                                }
                                break;
                            case ECollision.LEFT:
                                break;
                            case ECollision.RIGHT:
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.BRICK:
                    break;
                case EObject.GOOMBA:
                    break;
                case EObject.KOOPA:
                    break;
                case EObject.QUESTION:
                    break;
                case EObject.PIPE:
                    break;
                case EObject.COIN:
                    break;
                case EObject.COIN_BRICK:
                    break;
                default:
                    break;
            }
        }

    }
}
