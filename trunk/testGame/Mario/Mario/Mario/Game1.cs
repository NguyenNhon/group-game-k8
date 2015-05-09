using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Mario
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Mario m_Mario;
        MapLoader m_Map;
        //List<Brick> m_Brick;
        //List<Goomba> m_Goomba;
        //Koopa m_Koopa;
        //List<CoinBrick> m_Question;
        //Pipe m_Pipe;
        //Coin m_Coin;
        //RedMushRoom m_RedMushRoom;
        //GreenBrick m_GreenBrick;
        //RedBrick m_RedBrick;
        //FlowerBrick m_FlowerBrick;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            ObjectManager.GetInstance();
            GlobalVariable.GetInstance();
            Camera.GetInstance();
            ResourceManager.GetInstance();

            graphics.PreferredBackBufferWidth = GlobalVariable.GetInstance().ScreenSize.X;
            graphics.PreferredBackBufferHeight = GlobalVariable.GetInstance().ScreenSize.Y;
            
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.GetInstance().LoadContent(Content);
            m_Map = new MapLoader();
            m_Mario = (Mario)ObjectManager.GetInstance().GetMario();
            
            base.LoadContent();
        }

        protected override void UnloadContent()
        {       
        }

        protected override void Update(GameTime gameTime)
        {
            m_Mario.HandleInput();
            ObjectManager.GetInstance().Update(gameTime);
            ObjectManager.GetInstance().CheckCollision();
            Camera.GetInstance().SetMatrix(m_Mario.Physic.Position);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, Camera.GetInstance().TransformMatrix);
           
            ObjectManager.GetInstance().DrawObject(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
