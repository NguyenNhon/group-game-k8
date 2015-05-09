using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class Mario: CObject
    {
        private bool m_IsJump;
        //private float m_LifeTime;
        private float m_BlinkTime; 
        private bool m_IsBlink;
        //private float m_TimeChangeLevel;
        private float m_TimeDie;
        private int m_MarioLevel;

        private float m_TimeDelayShoot;

        public bool IsJump
        {
            get { return m_IsJump; }
            set { m_IsJump = value; }
        }

        public int MarioLevel
        {
            get { return m_MarioLevel; }
            set { m_MarioLevel = value; }
        }

        public Mario(Vector2 _Position):base()
        {
            m_Object = EObject.MARIO;
            m_Status = EStatus.LIVE;
            m_Physic.Position = _Position;
            m_Animation.IndexFrameBegin = 0;
            m_Animation.IndexFrameCurrent = 0;
            m_Animation.IndexFrameEnd = 5;
            m_Animation.TimeChangeFrame = 100.0f;
            
            m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioSmall);

            m_Physic.Accelarate = new Vector2(0.0f, 0.005f);
            m_Physic.Velocity = new Vector2(0.0f, 0.0f);
            
            m_IsJump = false;
            m_MarioLevel = 0;
            //m_LifeTime = 0;
            m_BlinkTime = 0;
            m_IsBlink = false;
            m_TimeDie = 0;
            m_TimeDelayShoot = 1000;
        }

        public override void Initialize()
        {
            base.Initialize();
            m_Animation.IndexFrameEnd = 3;
        }

        public override void LoadContent(ContentManager _content, string _nameTexture)
        {
            base.Sprite.LoadContent(_content, _nameTexture);
        }

        public override void Draw(SpriteBatch _sprite)
        {
            base.Sprite.Draw(_sprite, m_Physic.Position, m_Animation.IndexFrameCurrent);
        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            m_Animation.UpdateAnimation(_gameTime);

            float deltaTime = _gameTime.ElapsedGameTime.Milliseconds;
            Random rand = new Random();

            if (this.m_Physic.Position.X - this.m_Sprite.FrameSize.X / 2 < Camera.GetInstance().Left)
            {
                this.Position = new Vector2(Camera.GetInstance().Left + this.m_Sprite.FrameSize.X / 2, this.Position.Y);
            }
            if(this.Physic.Position.Y > GlobalVariable.GetInstance().ScreenSize.Y && this.Status == EStatus.LIVE)
            {
                this.Status = EStatus.BEFORE_DIE;
                this.m_Animation.SetIndexFrame(5);
                this.m_Physic.Velocity = new Vector2(0.0f, -1.0f);
                this.Accelarate = new Vector2(0.0f, this.Accelarate.Y);
                GlobalVariable.GetInstance().MarioLife--;
            }

            if (this.Status == EStatus.BEFORE_DIE)
            {
                m_TimeDie += deltaTime;
                this.Accelarate = new Vector2(0.0f, 0.005f);
                if (m_TimeDie > 700)
                {
                    this.Status = EStatus.DIE;
                    this.Velocity = Vector2.Zero;
                    m_TimeDie = 0;
                }
            }
            
            if (GlobalVariable.GetInstance().MarioLife >= 0 && this.Status == EStatus.DIE)
            {
                this.m_Status = EStatus.LIVE;
                this.m_Physic.Position = new Vector2(0, 25);
                this.Velocity = new Vector2(0.0f, 1.0f);
                this.Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioSmall);
                this.m_MarioLevel = 0;
                Camera.GetInstance().ResetCamera();
            }

            if (this.Status == EStatus.LIVE && m_IsBlink == true)
            {
                m_BlinkTime += deltaTime;
                if (m_BlinkTime < 700)
                {
                    m_Sprite.Scale = new Vector2(1.0f,(float) rand.NextDouble());
                }
                else
                {
                    m_IsBlink = false;
                    m_Sprite.Scale = new Vector2(1.0f, 1.0f);
                    m_BlinkTime = 0;
                }
            }
        }

        public void HandleInput()
        {
            if (this.m_Status == EStatus.DIE || this.m_Status == EStatus.BEFORE_DIE)
            {
                this.Velocity = new Vector2(0.0f, this.Velocity.Y);
                return; 
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && m_TimeDelayShoot >= 500 && m_MarioLevel == 2)
            {
                Bullet bullet = new Bullet(this.Position);
                bullet.Status = EStatus.LIVE;
                if (this.m_Sprite.SpriteEffect == SpriteEffects.None)
                {
                    bullet.Velocity = new Vector2(0.7f, 0.0f);
                }
                else
                {
                    bullet.Velocity = new Vector2(-0.7f, 0.0f);
                }
                bullet.IdentityObject = MapLoader.maxID++;
                ObjectManager.GetInstance().AddObject(bullet);
                m_TimeDelayShoot = 0;
            }

            if (m_TimeDelayShoot <= 500)
            {
                m_TimeDelayShoot += 16;
            }

            if (m_IsJump == false && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up))
            {
                m_Physic.Velocity = new Vector2(0.0f, m_Physic.Velocity.Y);
                m_Animation.IndexFrameBegin = 0;
                m_Animation.IndexFrameEnd = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                m_Physic.Velocity = new Vector2(0.5f, m_Physic.Velocity.Y);
                m_Sprite.SpriteEffect = SpriteEffects.None;
                m_Animation.IndexFrameBegin = 0;
                m_Animation.IndexFrameEnd = 2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                m_Physic.Velocity = new Vector2(-0.5f, m_Physic.Velocity.Y);
                m_Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
                m_Animation.IndexFrameBegin = 0;
                m_Animation.IndexFrameEnd = 2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && m_IsJump == false && (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.Right)))
            {
                m_IsJump = true;
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    m_Physic.Velocity = new Vector2(-0.5f, -1.5f);
                    m_Physic.Accelarate = new Vector2(0.0f, 0.009f);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    m_Physic.Velocity = new Vector2(0.5f, -1.5f);
                    m_Physic.Accelarate = new Vector2(0.0f, 0.009f);
                }

                m_Animation.IndexFrameBegin = 3;
                m_Animation.IndexFrameEnd = 3;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && m_IsJump == false && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                m_IsJump = true;
                m_Physic.Velocity = new Vector2(0.0f, -1.5f);
                m_Physic.Accelarate = new Vector2(0.0f, 0.009f);
                m_Animation.IndexFrameBegin = 3;
                m_Animation.IndexFrameEnd = 3;
            }

            if(m_IsJump == true && m_Physic.Velocity.X != 0)
            {
                if (m_Physic.Velocity.X > 0)
                {
                    m_Physic.Velocity = new Vector2(0.5f, m_Physic.Velocity.Y);
                }
                else
                {
                    m_Physic.Velocity = new Vector2(-0.5f, m_Physic.Velocity.Y); 
                }
                m_Animation.IndexFrameBegin = 3;
                m_Animation.IndexFrameEnd = 3;
            }

        }

        public override void UpdateCollision(CObject _object)
        {
            if (this.m_Status == EStatus.BEFORE_DIE || this.m_Status == EStatus.DIE)
            {
                return;
            }

            ECollision dirCol = Physic.CheckCollision(this, _object);

            switch (_object.Object)
            {
                case EObject.MARIO:
                    break;
                case EObject.BRICK:
                    #region MyRegion
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                {
                                    this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0.1f);
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2  + this.Sprite.FrameSize.Y / 2);
                                }
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.Physic.Velocity.Y > 0)
                                    {
                                        this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0);
                                        this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.0f);
                                    }
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2 - this.Sprite.FrameSize.Y / 2 + 1);

                                    this.IsJump = false;
                                }
                                break;
                            case ECollision.LEFT:
                                {
                                    this.Position = new Vector2(_object.Position.X + _object.Sprite.FrameSize.X / 2 + this.Sprite.FrameSize.X / 2 - 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    this.Position = new Vector2(_object.Position.X - _object.Sprite.FrameSize.X / 2 - this.Sprite.FrameSize.X / 2 + 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.009f);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                     #endregion
                    break;
                case EObject.GOOMBA:
                    #region MyRegion
		            {
                        if (_object.Status == EStatus.BEFORE_DIE || _object.Status == EStatus.DIE || this.m_IsBlink == true)
                        {
                            return;
                        }
                        switch (dirCol)
                        {
                            case ECollision.BOTTOM:
                                {
                                    if (_object.Status == EStatus.LIVE)
                                    {
                                        this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, -1.0f);
                                    }
                                }
                                break;
                            case ECollision.TOP:
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    if (m_MarioLevel == 0)
                                    {
                                        this.m_Status = EStatus.BEFORE_DIE ;
                                        this.m_Animation.SetIndexFrame(5);
                                        this.m_Physic.Velocity = new Vector2(0.0f, -1.0f);
                                    }
                                    else if (m_MarioLevel == 1)
                                    {
                                        this.m_Status = EStatus.LIVE;
                                        this.m_Animation.SetIndexFrame(0, 4);
                                        m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioSmall);
                                        m_MarioLevel = 0;
                                    }
                                    else if (m_MarioLevel == 2)
                                    {
                                        this.m_Status = EStatus.LIVE;
                                        this.m_Animation.SetIndexFrame(0, 4);
                                        m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioMedium);
                                        m_MarioLevel = 1;
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Accelarate = new Vector2(0.0f, 0.009f);
                                }
                                break;
                            default:
                                break;
                        }
                    } 
	                #endregion  
                    break;
                case EObject.KOOPA:
                    #region MyRegion
                    {
                        if (this.m_IsBlink == true)
                        {
                            return;
                        }
                        switch (dirCol)
                        {
                            case ECollision.BOTTOM:
                                {
                                    switch (_object.Status)
                                    {
                                        case EStatus.DIE:
                                            break;
                                        case EStatus.LIVE:
                                            {
                                                this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, -1.0f);
                                            }
                                            break;
                                        case EStatus.BEFORE_DIE:
                                            {
                                                this.Physic.Velocity = new Vector2(m_Physic.Velocity.X, -1.0f);
                                                m_IsJump = false;
                                            }
                                            break;
                                        case EStatus.BEFORE_DIE1:
                                            {
                                                this.Physic.Velocity = new Vector2(m_Physic.Velocity.X, -1.0f);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case ECollision.TOP:
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    switch (_object.Status)
                                    {
                                        case EStatus.DIE:
                                            break;
                                        case EStatus.BEFORE_DIE:
                                            break;
                                        case EStatus.BEFORE_DIE1:
                                        case EStatus.LIVE:
                                            {
                                                if (m_MarioLevel == 0)
                                                {
                                                    this.m_Status = EStatus.BEFORE_DIE;
                                                    this.m_Animation.SetIndexFrame(5);
                                                    this.m_Physic.Velocity = new Vector2(0.0f, -1.0f);
                                                }
                                                else if (m_MarioLevel == 1)
                                                {
                                                    this.m_Status = EStatus.LIVE;
                                                    this.m_Animation.SetIndexFrame(0, 4);
                                                    m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioSmall);
                                                    m_IsBlink = true;
                                                    m_MarioLevel = 0;
                                                }
                                                else if (m_MarioLevel == 2)
                                                {
                                                    this.m_Status = EStatus.LIVE;
                                                    this.m_Animation.SetIndexFrame(0, 4);
                                                    m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioMedium);
                                                    m_IsBlink = true;
                                                    m_MarioLevel = 1;
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Accelarate = new Vector2(0.0f, 0.009f);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion
                    break;
                case EObject.QUESTION:
                case EObject.GREEN_BRICK:
                case EObject.RED_BRICK:
                case EObject.FLOWER_BRICK:
                case EObject.COIN_BRICK:
                    #region MyRegion
		            {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                {
                                    this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0.1f);
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1);
                                }
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.Physic.Velocity.Y > 0)
                                    {
                                        this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0);
                                        this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.0f);
                                    }
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2 - this.Sprite.FrameSize.Y / 2 + 1);

                                    this.IsJump = false;
                                }
                                break;
                            case ECollision.LEFT:
                                {
                                    this.Position = new Vector2(_object.Position.X + _object.Sprite.FrameSize.X / 2 + this.Sprite.FrameSize.X / 2 - 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    this.Position = new Vector2(_object.Position.X - _object.Sprite.FrameSize.X / 2 - this.Sprite.FrameSize.X / 2 + 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    } 
	                #endregion
                    break;
                case EObject.BREAK_BRICK:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                {
                                    this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0.1f);
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2 - 1);
                                }
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.Physic.Velocity.Y > 0)
                                    {
                                        this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0);
                                        this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.0f);
                                    }
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2 - this.Sprite.FrameSize.Y / 2 + 1);

                                    this.IsJump = false;
                                }
                                break;
                            case ECollision.LEFT:
                                {
                                    this.Position = new Vector2(_object.Position.X + _object.Sprite.FrameSize.X / 2 + this.Sprite.FrameSize.X / 2 - 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    this.Position = new Vector2(_object.Position.X - _object.Sprite.FrameSize.X / 2 - this.Sprite.FrameSize.X / 2 + 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.PIPE:
                    #region CollisionPipe
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                                {
                                    this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0.1f);
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y + _object.Sprite.FrameSize.Y / 2 + this.Sprite.FrameSize.Y / 2);
                                }
                                break;
                            case ECollision.BOTTOM:
                                {
                                    if (this.Physic.Velocity.Y > 0)
                                    {
                                        this.Physic.Velocity = new Vector2(this.Physic.Velocity.X, 0);
                                        this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.0f);
                                    }
                                    this.Physic.Position = new Vector2(this.Physic.Position.X, _object.Physic.Position.Y - _object.Sprite.FrameSize.Y / 2 - this.Sprite.FrameSize.Y / 2 + 1);

                                    this.IsJump = false;
                                }
                                break;
                            case ECollision.LEFT:
                                {
                                    this.Position = new Vector2(_object.Position.X + _object.Sprite.FrameSize.X / 2 + this.Sprite.FrameSize.X / 2 - 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.RIGHT:
                                {
                                    this.Position = new Vector2(_object.Position.X - _object.Sprite.FrameSize.X / 2 - this.Sprite.FrameSize.X / 2 + 4, this.Position.Y);
                                    this.Physic.Velocity = new Vector2(0, this.m_Physic.Velocity.Y);
                                }
                                break;
                            case ECollision.NONE:
                                {
                                    this.Physic.Accelarate = new Vector2(this.Physic.Accelarate.X, 0.009f);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion
                    break;
                case EObject.GREEN_MUSH_ROOM:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                            case ECollision.BOTTOM:
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    if (_object.Status == EStatus.LIVE)
                                    {
                                        GlobalVariable.GetInstance().MarioLife++; 
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case EObject.RED_MUSH_ROOM:
                    {
                        switch (dirCol)
                        {
                            case ECollision.TOP:
                            case ECollision.BOTTOM:
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    if (m_MarioLevel == 0)
                                    {
                                        this.m_Status = EStatus.LIVE;
                                        this.m_Animation.SetIndexFrame(0, 4);
                                        this.m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioMedium);
                                        m_IsBlink = true;
                                        m_MarioLevel = 1;
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                        
                    }
                    break;
                case EObject.FLOWER:
                    {
                        if (this.m_IsBlink == true || _object.Status == EStatus.DIE)
                        {
                            return;
                        }
                        switch (dirCol)
                        {
                            case ECollision.BOTTOM:
                                break;
                            case ECollision.TOP:
                            case ECollision.LEFT:
                            case ECollision.RIGHT:
                                {
                                    if (this.m_MarioLevel == 0)
                                    {
                                        this.m_Status = EStatus.LIVE;
                                        this.m_Animation.SetIndexFrame(0, 4);
                                        this.m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioMedium);
                                        this.m_IsBlink = true;
                                        m_MarioLevel = 1;
                                        _object.Status = EStatus.DIE;
                                    }
                                    else if (this.m_MarioLevel == 1)
                                    {
                                        this.m_Status = EStatus.LIVE;
                                        this.m_Animation.SetIndexFrame(0, 4);
                                        this.m_Sprite = ResourceManager.GetInstance().GetSprite(EResource.ID_MarioBig);
                                        this.m_IsBlink = true;
                                        m_MarioLevel = 2;
                                        _object.Status = EStatus.DIE;
                                    }
                                }
                                break;
                            case ECollision.NONE:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
