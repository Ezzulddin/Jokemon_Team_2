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
        // comment
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
        private List<Rectangle> rectangleObjects = new List<Rectangle>();

        private ReadableObject sign;
        private ReadableObject sign2;


        private Tile[,] tileArray = new Tile[10, 10];
        private char[,] tileValuesArray;
        private Texture2D big_tree, building, Tile_sign;
        private const int TILE_SIZE = 80;

        private CameraManager cManager;
        private CameraManager nullCam;

        private bool Sign_Initialize;
        private bool inBounds;
        private bool inBounds1;
        private List<string> MessageList = new List<string>();

        private Rectangle tc1Rect = new Rectangle();
        private Rectangle tc2Rect = new Rectangle();
        private Rectangle tr1Rect = new Rectangle();
        private Rectangle tr2Rect = new Rectangle();
        private Rectangle tr3Rect = new Rectangle();
        private Rectangle h1Rect = new Rectangle();
        private Rectangle h2Rect = new Rectangle();
        private Rectangle s1Rect = new Rectangle();

        MouseState mouse;
        private bool mousePressed = false;
        public static int screenWidth;
        public static int screenHeight;
        private bool windowInPosition;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            screenHeight = _graphics.PreferredBackBufferHeight;
            screenWidth = _graphics.PreferredBackBufferWidth;

            MapReader.MapSize = 10;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tileArray = new Tile[MapReader.MapSize, MapReader.MapSize];
            tileValuesArray = MapReader.ReadFile("../../../Content/Text_file/Tile_Map");
            Window.AllowUserResizing = false;

            base.Initialize();
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
                        Debug.WriteLine("X: {0} Y:{1}", house.spritePosition.X, house.spritePosition.Y);
                        
                        buildingObjects.Add(house);
                    }//
                    if (tileValuesArray[i, j].ToString().Contains("3"))
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(Tile_sign, temPosition, sSize);
                        Wood_sign = new ReadableObject(Tile_sign, temPosition, sSize, true);
                        Debug.WriteLine("X: {0} Y: {1}", Wood_sign.spritePosition.X, Wood_sign.spritePosition.Y);
                        
                        signObjects.Add(Wood_sign);
                    }
                    else if (tileValuesArray[i, j].ToString().Contains("0"))
                    {
                        tileArray[i, j] = new Tile(new Texture2D(GraphicsDevice, 10, 10), new Vector2(0, 0), new Vector2(0, 0));
                    }
                }
            }
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            big_tree = Content.Load<Texture2D>("Big_tree");

            building = Content.Load<Texture2D>("House_Wood");

            Tile_sign = Content.Load<Texture2D>("Sign");

            loadContent = Content.Load<Texture2D>("Player_M");
            player = new Player(loadContent, new Vector2(360, 380), new Vector2(35, 50), true);
            loadFont = Content.Load<SpriteFont>("File");

            //sign = new ReadableObject(Tile_sign, new Vector2(500, 500), new Vector2(30, 30), loadFont, ("default"), new Vector2(80, 670), true);
            //sign2 = new ReadableObject(Tile_sign, new Vector2(200, 300), new Vector2(30, 30), loadFont, ("Default"), new Vector2(80, 670), true);

            loadContent = Content.Load<Texture2D>("MessageBox");

            //MessageBox = new MessageWindow(Tile_sign, new Vector2(Window.ClientBounds.Width / 2 - 750 / 2, 800), new Vector2(750, 150));

            signObjects.Add(sign);
            signObjects.Add(sign2);
            MessageList.Add("Rest in Peace Ez 2004-2000");
            MessageList.Add("I am sorry this took so long." + System.Environment.NewLine + "");
            MessageList.Add("I am so sorry this took so long");
            CreateMap();
            cManager = new CameraManager();//for all objects in game world(trees, bushes, homes)
            nullCam = new CameraManager();//for all static objects(menus/popups)


            tc1Rect = new Rectangle((int)trees.spritePosition.X, (int)trees.spritePosition.Y, (int)trees.spriteSize.X, (int)trees.spriteSize.Y);
            rectangleObjects.Add(tc1Rect);
            h2Rect = new Rectangle((int)house.spritePosition.X, (int)house.spritePosition.Y, (int)house.spriteSize.X, (int)house.spriteSize.Y);
            rectangleObjects.Add(h2Rect);
            s1Rect = new Rectangle((int)Wood_sign.spritePosition.X, (int)Wood_sign.spritePosition.Y, (int)house.spriteSize.X, (int)house.spriteSize.Y);
            rectangleObjects.Add(s1Rect);
            //rectangleObjects.Add(h1Rect);



            cManager = new CameraManager();
        }
        

        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouse = Mouse.GetState();
            iManager.CheckKeys(player, _graphics);
            cManager.Follow(player);
            //Debug.WriteLine("X:{0} Y:{1}", mouse.X, mouse.Y);

            //if (mouse.X == )
            //{
            //    if(mouse.LeftButton == ButtonState.Pressed)
            //    {
            //        Debug.WriteLine("Mouse Pressed");
            //        mousePressed = true;
            //    }
            //}

            // TODO: Add your update logic here
            iManager.CheckKeys(player,_graphics);

            foreach(Rectangle r in rectangleObjects)
            {
                pManager.checkCollision(player, r);
            }

            cManager.Follow(player);
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

            //inBounds = pManager.CheckInBounds((int)player.spritePosition.X, (int)player.spritePosition.Y, (int)sign.spritePosition.X, (int)sign.spritePosition.Y, 40);
            //if (inBounds == true)
            //{
            //    foreach (ReadableObject s in signObjects)
            //    {
            //        s.message = MessageList[0];
            //    }
            //}
            //inBounds1 = pManager.CheckInBounds((int)player.spritePosition.X, (int)player.spritePosition.Y, (int)sign2.spritePosition.X, (int)sign2.spritePosition.Y, 40);
            //if (inBounds1 == true)
            //{
            //    foreach (ReadableObject s in signObjects)
            //    {
            //        s.message = MessageList[1];
            //    }
            //}
            //Debug.WriteLine("bounds{0}", inBounds);
            ////Debug.WriteLine("bounds1{0}", inBounds1);
            //foreach (ReadableObject s in signObjects)
            //{
            //    Sign_Initialize = pManager.CheckSignCollision(player, s);
            //    //STAND UNDER SIGN TO ACTIVATE

            //    if (Sign_Initialize == true && MessageBox.spritePosition.Y >= 645)
            //    {
            //        //identify sign
            //        //Move box up animation
            //        MessageBox.spritePosition = new Vector2(MessageBox.spriteSize.X / 2 - 350, MessageBox.spritePosition.Y - 20);
            //        //check if box in right place
            //        if (MessageBox.spritePosition.Y <= 650)
            //        {
            //            windowInPosition = true;
            //        }
            //    }

            //    //if player no longer standing under sign and the box is still on screen
            //    if (Sign_Initialize == false && MessageBox.spritePosition.Y < 801)
            //    {
            //        //move box down so box is not in the engaged position 
            //        MessageBox.spritePosition = new Vector2(MessageBox.spritePosition.X, MessageBox.spritePosition.Y + 1000);
            //        //box no longer in engaged position
            //        windowInPosition = false;
            //    }
            //}

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            bool draw = true;
            GraphicsDevice.Clear(Color.LightGreen);
            foreach (Tile t in tileArray)
            {
                if(draw == true)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture,cManager);
                }
                
                if(mousePressed == true)
                {
                    draw = false;

                }
            }
            
            player.DrawSprite(_spriteBatch, player.spriteTexture,cManager);

            //foreach (ReadableObject s in signObjects)
            //{
            //    if (s.IsDrawn)
            //    {
            //        s.DrawSprite(_spriteBatch, sign.spriteTexture, cManager);
            //    }
            //    if (Sign_Initialize == true)
            //    {
            //        //Draw the message box
            //        MessageBox.DrawMessageWindow(_spriteBatch, MessageBox.spriteTexture);
            //    }
            //    //If the message box is in the engaged position
            //    if (windowInPosition == true)
            //    {
            //        //Draw the text
            //        s.DrawMessage(_spriteBatch);

            //    }

            //}
            //If the player is touching the bottom of the sign
            if (player.hasCollidedTop == true)
            {
                //Draw the message box
                MessageBox.DrawSprite(_spriteBatch, MessageBox.spriteTexture,cManager);
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