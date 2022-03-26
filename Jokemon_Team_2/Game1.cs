using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Jokemon_Team_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int posX = 0;
        private int posY = 0;
        private Texture2D loadContent;
        private Player player;
        private InputManager iManager = new InputManager();
        private Tree[] treeRow1 = new Tree[10];
        private Tree[] treeRow2 = new Tree[15];
        private Tree[] treeRow3 = new Tree[7];
        private Tree[] treeRow4 = new Tree[8];
        private Tree[] treeRow5 = new Tree[10];
        private List<Tree> treeObjects = new List<Tree>();

        private LoadLevelClass blackscreen = new LoadLevelClass();
        private PhysicsManager pManager = new PhysicsManager();
        private List<Building> buildingObjects = new List<Building>();
        private List<Building> postObjects = new List<Building>();
        private List<ReadableObject> signObjects = new List<ReadableObject>();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            timer = 60 * 3;
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
                treeRow1[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow1[i]);
            }

            posX = 50;
            posY = 740;

            for (int i = 0; i < treeRow2.Length; i++)
            {
                posX = 50 + (i * 50);

                treeRow2[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow2[i]);
            }
            posX = 0;
            posY = 0;

            for (int i = 0; i < treeRow3.Length; i++)
            {
                posX = 0 + (i * 50);

                treeRow3[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow3[i]);
            }
            posX = 430;
            posY = 0;

            for (int i = 0; i < treeRow4.Length; i++)
            {
                posX = 430 + (i * 45);

                treeRow4[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow4[i]);
            }
            posX = 0;
            posY = 0;

            for (int i = 0; i < treeRow5.Length; i++)
            {
                posY = 0 + (i * 80);

                treeRow5[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow5[i]);
            }




            loadContent = Content.Load<Texture2D>("Player_M");
            player = new Player(loadContent,new Vector2(360,380),new Vector2(35,50));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            iManager.CheckKeys(player,_graphics);

            foreach (Tree t in treeObjects)
            {
                pManager.CheckCollision(player, t);
            }
            //foreach (Building b in buildingObjects)
            //{
            //    pManager.CheckCollision(player, b);
            //}
            //foreach (ReadableObject r in signObjects)
            //{
            //    pManager.CheckCollision(player, r);
            //}
            blackScreen.FadeScreen(player, GraphicsDevice, timer);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);
            foreach(Tree t in treeObjects)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }
            
            player.DrawSprite(_spriteBatch, player.spriteTexture);

            if(player.spritePosition.Y <=5)
            {
                GraphicsDevice.Clear(Color.Black);
                
            }
            
            
            base.Draw(gameTime);
        }
    }
}
