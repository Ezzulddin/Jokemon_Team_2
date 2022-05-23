using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Jokemon_Team_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player player;
        private MessageWindow MessageBox;
        private SpriteFont loadFont;
        private Texture2D loadContent;
        private Building house;
        private Tree trees;
        private ReadableObject Wood_sign;

        private List<Tree> treeObjects = new List<Tree>();
        private PhysicsManager pManager = new PhysicsManager();
        private InputManager iManager = new InputManager();
        private List<Building> buildingObjects = new List<Building>();
        private List<Building> postObjects = new List<Building>();
        private List<ReadableObject> signObjects = new List<ReadableObject>();

        private Tile[,] tileArray = new Tile[10, 10];
        private char[,] tileValuesArray;
        private Texture2D big_tree, building, Tile_sign;
        private const int TILE_SIZE = 80;

        private MouseState oldMouseState;
        MouseState mouse;

        private bool windowInPosition;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            MapReader.MapSize = 10;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tileArray = new Tile[MapReader.MapSize, MapReader.MapSize];
            tileValuesArray = MapReader.ReadFile("../../../Content/Text_file/Tile_Map");
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            big_tree = Content.Load<Texture2D>("Big_tree");

            building = Content.Load<Texture2D>("House_Wood");

            Tile_sign = Content.Load<Texture2D>("Sign");

            loadContent = Content.Load<Texture2D>("Player_M");
            player = new Player(loadContent, new Vector2(360, 380), new Vector2(35, 50), true);


            loadContent = Content.Load<Texture2D>("MessageBox");
            loadFont = Content.Load<SpriteFont>("File");
            MessageBox = new MessageWindow(loadContent, new Vector2(Window.ClientBounds.Width / 2 - 750 / 2, 800), new Vector2(750, 150), loadFont, ("This is a sign!"), new Vector2(80, 670));


            CreateMap();
        }
        public void CreateMap()
        {

            Vector2 temPosition;
            Vector2 bSize = new Vector2(150, 150);
            Vector2 tSize = new Vector2(80, 100);
            Vector2 sSize = new Vector2(30, 30);
            for (int i = 0; i <= tileArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= tileArray.GetUpperBound(1); j++)
                {
                    if (tileValuesArray[i, j].ToString().Contains("1"))
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(big_tree, temPosition, tSize);
                        trees = new Tree(big_tree, temPosition, tSize, true);
                        treeObjects.Add(trees);
                    }
                    if (tileValuesArray[i, j].ToString().Contains("2"))
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(building, temPosition, bSize);
                        house = new Building(building, temPosition, bSize, true);
                        buildingObjects.Add(house);
                    }
                    if (tileValuesArray[i, j].ToString().Contains("3"))
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(Tile_sign, temPosition, sSize);
                        Wood_sign = new ReadableObject(Tile_sign, temPosition, sSize, true);
                        signObjects.Add(Wood_sign);
                    }
                    else if (tileValuesArray[i, j].ToString().Contains("0"))
                    {
                        tileArray[i, j] = new Tile(new Texture2D(GraphicsDevice, 10, 10), new Vector2(0, 0), new Vector2(0, 0));
                    }
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {

            mouse = Mouse.GetState();

            Console.WriteLine("X:{0} Y:{1}",mouse.X,mouse.Y);
            

            // TODO: Add your update logic here
            iManager.CheckKeys(player, _graphics);

            foreach (Tree t in treeObjects)
            {
                pManager.CheckCollision(player, t);
            }
            foreach (Building b in buildingObjects)
            {
                pManager.CheckCollision(player, b);
            }
            foreach (ReadableObject r in signObjects)
            {
                pManager.CheckCollision(player, r);
            }
            pManager.CheckCollision(player, Wood_sign);


            //STAND UNDER SIGN TO ACTIVATE MESSAGE
            if (player.hasCollidedTop == true && MessageBox.spritePosition.Y >= Window.ClientBounds.Height - MessageBox.spriteSize.Y - 9)
            {
                //Move box up animation
                MessageBox.spritePosition = new Vector2(MessageBox.spritePosition.X, MessageBox.spritePosition.Y - 20);
                //check if box in right place
                if (MessageBox.spritePosition.Y <= Window.ClientBounds.Height - MessageBox.spriteSize.Y - 9)
                {
                    windowInPosition = true;
                }
            }
            //if player no longer standing under sign and the box is still on screen
            if (player.hasCollidedTop == false && MessageBox.spritePosition.Y < 801)
            {
                //move box down so box is not in the engaged position 
                MessageBox.spritePosition = new Vector2(MessageBox.spritePosition.X, MessageBox.spritePosition.Y + 1000);
                //box no longer in engaged position
                windowInPosition = false;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);
            foreach (Tile t in tileArray)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }

            player.DrawSprite(_spriteBatch, player.spriteTexture);

            //If the player is touching the bottom of the sign
            if (player.hasCollidedTop == true)
            {
                //Draw the message box
                MessageBox.DrawSprite(_spriteBatch, MessageBox.spriteTexture);
                //If the message box is in the engaged position
                if (windowInPosition == true)
                {
                    //Draw the text
                    MessageBox.DrawMessage(_spriteBatch);
                }
            }


            base.Draw(gameTime);
        }
    }
}