using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this); //hi 
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            loadContent = Content.Load<Texture2D>("Big_tree");
            posX = 750;
            posY = 0;
            for (int i = 0; i < treeRow1.Length; i++)
            {
                posY = 0 + (i * 80);
                treeRow1[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
                treeObjects.Add(treeRow1[i]);
            }

            posX = 50;
            posY = 740;

            for (int i = 0; i < treeRow2.Length; i++)
            {
                posX = 50 + (i * 50);

                treeRow2[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
                treeObjects.Add(treeRow2[i]);
            }
            posX = 0;
            posY = 0;

            for (int i = 0; i < treeRow3.Length; i++)
            {
                posX = 0 + (i * 50);

                treeRow3[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
                treeObjects.Add(treeRow3[i]);
            }
            posX = 430;
            posY = 0;

            for (int i = 0; i < treeRow4.Length; i++)
            {
                posX = 430 + (i * 45);

                treeRow4[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
                treeObjects.Add(treeRow4[i]);
            }
            posX = 0;
            posY = 0;

            for (int i = 0; i < treeRow5.Length; i++)
            {
                posY = 0 + (i * 80);

                treeRow5[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
                treeObjects.Add(treeRow5[i]);
            }

            loadContent = Content.Load<Texture2D>("Player_M");
            player = new Player(loadContent, new Vector2(360, 380), new Vector2(35, 50),true);

            loadContent = Content.Load<Texture2D>("Sign");
            sign = new ReadableObject(loadContent, new Vector2(500, 500), new Vector2(30, 30),true);
            signObjects.Add(sign);

            loadContent = Content.Load<Texture2D>("MessageBox");
            loadFont = Content.Load<SpriteFont>("File");
            MessageBox = new MessageWindow(loadContent, new Vector2(Window.ClientBounds.Width / 2 - 750 / 2, 800), new Vector2(750, 150), loadFont, ("This is a sign!"), new Vector2(80, 670));
            //MessageWindow Types take 6 values:
            //Box Texture, its Position, Its size
            //Font File, The desired message, its position

            loadContent = Content.Load<Texture2D>("woodenchest");
            chest = new Building(loadContent, new Vector2(300, 380), new Vector2(40, 50),true);
            buildingObjects.Add(chest);

            Home1 = loadContent.Load<Texture2D>("House_Wood");
            Home1 = new Building(loadContent, new Vector2(150, 150),new Vector2(150, 150),true);
            buildingObjects.Add(Home1);

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //hello
            base.Draw(gameTime);
        }
    }
}
