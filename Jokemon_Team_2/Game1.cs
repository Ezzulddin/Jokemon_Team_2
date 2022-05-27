using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Jokemon_Team_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        
        private SpriteBatch _spriteBatch;

        private Player player;
        
        private ReadableObject sign;
        private ReadableObject sign2;
        
        private MessageWindow MessageBox;
        
        private SpriteFont loadFont;

        private Texture2D loadContent;

        private Building chest;
        private Building Home1;
        private Building Home2;

        private PhysicsManager pManager = new PhysicsManager();

        private InputManager iManager = new InputManager();

        private List<Tree> treeObjects = new List<Tree>();
        private List<Building> buildingObjects = new List<Building>();
        private List<ReadableObject> signObjects = new List<ReadableObject>();
        private List<string> MessageList = new List<string>();

        public static int screenWidth;
        public static int screenHeight;

        private CameraManager cManager;
        private CameraManager nullCam;

        private bool windowInPosition;
        private bool Sign_Initialize;
        private bool inBounds;
        private bool inBounds1;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            screenHeight = _graphics.PreferredBackBufferHeight;
            screenWidth = _graphics.PreferredBackBufferWidth;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.AllowUserResizing = false;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            loadContent = Content.Load<Texture2D>("Big_tree");
            //posX = 750;
            //posY = 0;
            //for (int i = 0; i < treeRow1.Length; i++)
            //{
            //    posY = 0 + (i * 80);
            //    treeRow1[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100), true);
            //    treeObjects.Add(treeRow1[i]);
            //}

            //posX = 50;
            //posY = 740;

            //for (int i = 0; i < treeRow2.Length; i++)
            //{
            //    posX = 50 + (i * 50);

            //    treeRow2[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100), true);
            //    treeObjects.Add(treeRow2[i]);
            //}
            //posX = 0;
            //posY = 0;

            //for (int i = 0; i < treeRow3.Length; i++)
            //{
            //    posX = 0 + (i * 50);

            //    treeRow3[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100), true);
            //    treeObjects.Add(treeRow3[i]);
            //}
            //posX = 430;
            //posY = 0;

            //for (int i = 0; i < treeRow4.Length; i++)
            //{
            //    posX = 430 + (i * 45);

            //    treeRow4[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100), true);
            //    treeObjects.Add(treeRow4[i]);
            //}
            //posX = 0;
            //posY = 0;

            //for (int i = 0; i < treeRow5.Length; i++)
            //{
            //    posY = 0 + (i * 80);

            //    treeRow5[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100), true);
            //    treeObjects.Add(treeRow5[i]);
            //}

            loadContent = Content.Load<Texture2D>("Player_M");
            player = new Player(loadContent, new Vector2(360, 380), new Vector2(35, 50),true);

            loadContent = Content.Load<Texture2D>("Sign");
            loadFont = Content.Load<SpriteFont>("File");

            sign = new ReadableObject(loadContent, new Vector2(500, 500), new Vector2(30, 30), loadFont, ("default"), new Vector2(80, 670),true);
            sign2 = new ReadableObject(loadContent, new Vector2(200, 300), new Vector2(30, 30), loadFont, ("Default"), new Vector2(80, 670),true);
            
            loadContent = Content.Load<Texture2D>("MessageBox");
            MessageBox = new MessageWindow(loadContent, new Vector2(Window.ClientBounds.Width / 2 - 750/2, 800), new Vector2(750, 150));
            
            signObjects.Add(sign);
            signObjects.Add(sign2);
            MessageList.Add("Rest in Peace Ez 2004-2000");
            MessageList.Add("I am sorry this took so long." + System.Environment.NewLine + "");
            MessageList.Add("I am so sorry this took so long");
            //MessageWindow Types take 6 values:
            //Box Texture, its Position, Its size
            //Font File, The desired message, its position

            cManager = new CameraManager();//for all objects in game world(trees, bushes, homes)
            nullCam = new CameraManager();//for all static objects(menus/popups)

            loadContent = Content.Load<Texture2D>("woodenchest");
            chest = new Building(loadContent, new Vector2(300, 380), new Vector2(40, 50),true);
            buildingObjects.Add(chest);

            loadContent = Content.Load<Texture2D>("House_Wood");
            Home1 = new Building(loadContent, new Vector2(150, 150),new Vector2(150, 150),true);
            Home2 = new Building(loadContent, new Vector2(250, 200), new Vector2(250, 200), true);
            buildingObjects.Add(Home1);
            buildingObjects.Add(Home2);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            iManager.CheckKeys(player, _graphics);
            cManager.Follow(player);

            //if (isBlack == false)
            //{

            //    foreach (Tree t in treeObjects)
            //    {
            //        pManager.CheckCollision(player, t);
            //    }
                //foreach (Building b in buildingObjects)
                //{
                //    pManager.CheckCollision(player, b);
                //}

                //SIGN STUFF
                inBounds = pManager.CheckInBounds((int)player.spritePosition.X, (int)player.spritePosition.Y, (int)sign.spritePosition.X, (int)sign.spritePosition.Y, 40);
                if (inBounds == true)
                {
                    foreach (ReadableObject s in signObjects)
                    {
                        s.message = MessageList[0];
                    }
                }
                inBounds1 = pManager.CheckInBounds((int)player.spritePosition.X, (int)player.spritePosition.Y, (int)sign2.spritePosition.X, (int)sign2.spritePosition.Y, 40);
                if (inBounds1 == true)
                {
                    foreach (ReadableObject s in signObjects)
                    {
                        s.message = MessageList[1];
                    }
                }
                Debug.WriteLine("bounds{0}", inBounds);
                //Debug.WriteLine("bounds1{0}", inBounds1);
                foreach (ReadableObject s in signObjects)
                {
                    Sign_Initialize = pManager.CheckSignCollision(player, s);
                    //STAND UNDER SIGN TO ACTIVATE

                if (Sign_Initialize == true && MessageBox.spritePosition.Y >= 645)
                {
                    //identify sign
                    //Move box up animation
                    MessageBox.spritePosition = new Vector2(MessageBox.spriteSize.X / 2 - 350, MessageBox.spritePosition.Y - 20);
                    //check if box in right place
                    if (MessageBox.spritePosition.Y <= 650)
                    {
                        windowInPosition = true;
                    }
                }

                //if player no longer standing under sign and the box is still on screen
                if (Sign_Initialize == false && MessageBox.spritePosition.Y < 801)
                {
                    //move box down so box is not in the engaged position 
                    MessageBox.spritePosition = new Vector2(MessageBox.spritePosition.X, MessageBox.spritePosition.Y + 1000);
                    //box no longer in engaged position
                    windowInPosition = false;
                }

            }

          

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);
            foreach (Tree t in treeObjects)
            {
                if (t.IsDraw)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, cManager);
                }
            }

            player.DrawSprite(_spriteBatch, player.spriteTexture, cManager);

    
            foreach(ReadableObject s in signObjects)
            {
                if (s.IsDrawn)
                {
                    s.DrawSprite(_spriteBatch, sign.spriteTexture, cManager);
                }
                if (Sign_Initialize == true)
                {
                    //Draw the message box
                    MessageBox.DrawMessageWindow(_spriteBatch, MessageBox.spriteTexture);
                }
                //If the message box is in the engaged position
                if (windowInPosition == true)
                {
                    //Draw the text
                    s.DrawMessage(_spriteBatch);

                }
                
            }


            chest.DrawSprite(_spriteBatch, chest.spriteTexture, cManager);
            Home1.DrawSprite(_spriteBatch, Home1.spriteTexture, cManager);
            Home2.DrawSprite(_spriteBatch, Home2.spriteTexture, cManager);

            //foreach (Tree t in treeObjects)
            //{
            //    t.IsDraw = false;
            //}
            //foreach (ReadableObject s in signObjects)
            //{
            //    s.IsDrawn = false;
            //}


            base.Draw(gameTime);
        }
    }
}
