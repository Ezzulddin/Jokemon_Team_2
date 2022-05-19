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
        private ReadableObject sign;
        private MessageWindow MessageBox;
        private SpriteFont loadFont;
        private Texture2D loadContent;
        private Building chest;
        private Building Home1;
        private Building Home2;

        
        private Tree[] treeRow2 = new Tree[15];
        private Tree[] treeRow3 = new Tree[7];
        private Tree[] treeRow4 = new Tree[8];
        private Tree[] treeRow5 = new Tree[10];

        
        private List<Tree> treeObjects = new List<Tree>();
        private PhysicsManager pManager = new PhysicsManager();
        private InputManager iManager = new InputManager();
        private List<Building> buildingObjects = new List<Building>();
        private List<Building> postObjects = new List<Building>();
        private List<ReadableObject> signObjects = new List<ReadableObject>();

        private Tile[,] tileArray = new Tile[10,10];
        private char[,] tileValuesArray;
        private Texture2D big, building, Tile_sign;
        private const int TILE_SIZE = 80;

        private bool isBlack;
        private int timer;
        Color background;
        private int posX = 0;
        private int posY = 0;
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

            big = loadContent = Content.Load<Texture2D>("Big_tree");
            //treeObjects.Add(treeRow1);
            //posX = 750;
            //posY = 0;
            //for (int i = 0; i < treeRow1.Length; i++)
            //{
            //    posY = 0 + (i * 80);

            //    treeObjects.Add(treeRow1[i]);
            //}

            //posX = 50;
            //posY = 740;

            //for (int i = 0; i < treeRow2.Length; i++)
            //{
            //    posX = 50 + (i * 50);

            //    treeRow2[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
            //    treeObjects.Add(treeRow2[i]);
            //}
            //posX = 0;
            //posY = 0;

            //for (int i = 0; i < treeRow3.Length; i++)
            //{
            //    posX = 0 + (i * 50);

            //    treeRow3[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
            //    treeObjects.Add(treeRow3[i]);
            //}
            //posX = 430;
            //posY = 0;

            //for (int i = 0; i < treeRow4.Length; i++)
            //{
            //    posX = 430 + (i * 45);

            //    treeRow4[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
            //    treeObjects.Add(treeRow4[i]);
            //}
            //posX = 0;
            //posY = 0;

            //for (int i = 0; i < treeRow5.Length; i++)
            //{
            //    posY = 0 + (i * 80);

            //    treeRow5[i] = new Tree(loadContent, new Vector2(posX, posY), new Vector2(60, 100),true);
            //    treeObjects.Add(treeRow5[i]);
            //}

            loadContent = Content.Load<Texture2D>("Player_M");
            player = new Player(loadContent, new Vector2(360, 380), new Vector2(35, 50), true);

            //loadContent = Content.Load<Texture2D>("Sign");
            ////sign = new ReadableObject(loadContent, new Vector2(500, 500), new Vector2(30, 30),true);
            //signObjects.Add(sign);

            //loadContent = Content.Load<Texture2D>("MessageBox");
            //loadFont = Content.Load<SpriteFont>("File");
            //MessageBox = new MessageWindow(loadContent, new Vector2(Window.ClientBounds.Width / 2 - 750 / 2, 800), new Vector2(750, 150), loadFont, ("This is a sign!"), new Vector2(80, 670));
            ////MessageWindow Types take 6 values:
            ////Box Texture, its Position, Its size
            ////Font File, The desired message, its position

            ////loadContent = Content.Load<Texture2D>("woodenchest");
            ////chest = new Building(loadContent, new Vector2(300, 380), new Vector2(40, 50),true);
            ////buildingObjects.Add(chest);

            //loadContent = Content.Load<Texture2D>("House_Wood");
            ////Home1 = new Building(loadContent, new Vector2(150, 150),new Vector2(150, 150),true);
            ////Home2 = new Building(loadContent, new Vector2(250, 200), new Vector2(250, 200), true);
            //buildingObjects.Add(Home1);
            //buildingObjects.Add(Home2);

            CreateMap();
        }
        public void CreateMap()
        {
            Vector2 temPosition;
            Vector2 size = new Vector2(TILE_SIZE, TILE_SIZE);

            for (int i = 0; i <= tileArray.GetUpperBound(0); i++)
            {
                for(int j = 0; j<=tileArray.GetUpperBound(1);j++)
                {
                    if(tileValuesArray[i,j].ToString().Contains("1") )
                    {
                        temPosition = new Vector2(i * TILE_SIZE, j * TILE_SIZE);
                        tileArray[i, j] = new Tile(big,temPosition,size);
                    }
                    else
                    {
                        //tileArray[i, j] = new Tile(new Rectangle(0,0,0,0), new Vector2(0,0), new Vector2(0,0));
                    }
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            iManager.CheckKeys(player, _graphics);

            //foreach (Tree t in treeObjects)
            //{
            //    pManager.CheckCollision(player, t);
            //}
            //foreach (Building b in buildingObjects)
            //{
            //    pManager.CheckCollision(player, b);
            //}
            //foreach (ReadableObject r in signObjects)
            //{
            //    pManager.CheckCollision(player, sign);
            //}
            //pManager.CheckCollision(player, sign);


            //STAND UNDER SIGN TO ACTIVATE MESSAGE
            //if (player.hasCollidedTop == true && MessageBox.spritePosition.Y >= Window.ClientBounds.Height - MessageBox.spriteSize.Y - 9)
            //{
            //    //Move box up animation
            //    MessageBox.spritePosition = new Vector2(MessageBox.spritePosition.X, MessageBox.spritePosition.Y - 20);
            //    //check if box in right place
            //    if (MessageBox.spritePosition.Y <= Window.ClientBounds.Height - MessageBox.spriteSize.Y - 9)
            //    {
            //        windowInPosition = true;
            //    }
            //}
            //if player no longer standing under sign and the box is still on screen
            //if (player.hasCollidedTop == false && MessageBox.spritePosition.Y < 801)
            //{
            //    //move box down so box is not in the engaged position 
            //    MessageBox.spritePosition = new Vector2(MessageBox.spritePosition.X, MessageBox.spritePosition.Y + 1000);
            //    //box no longer in engaged position
            //    windowInPosition = false;
            //}

            ////////
            //if(player.spritePosition.Y <=5)
            //{
            //    timer--;
            //    background = Color.Black;
            //    player.goingDown = false;
            //    player.goingUp = false;
            //    player.goingRight = false;
            //    player.goingLeft = false;
            //    if (background == Color.Black)
            //    {
            //        isBlack = true;
            //    }
            //    else
            //    {
            //        isBlack = false;
            //    }
            //}
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);
            foreach(Tile t in tileArray)
            {
                t.DrawSprite(_spriteBatch,t.spriteTexture);
            }
            //foreach (Tree t in treeObjects)
            //{
            //    if(t.IsDraw)
            //    {
            //        t.DrawSprite(_spriteBatch, t.spriteTexture);
            //    }
            //}
            //foreach (Building b in buildingObjects)
            //{
            //    if (b.IsDrawn)
            //    {
            //        b.DrawSprite(_spriteBatch, b.spriteTexture);
            //    }
            //}
            player.DrawSprite(_spriteBatch, player.spriteTexture);
            //foreach (ReadableObject s in signObjects)
            //{
            //    if (s.IsDrawn)
            //    {
            //        s.DrawSprite(_spriteBatch, sign.spriteTexture);
            //    }
            //}

            ////If the player is touching the bottom of the sign
            //if (player.hasCollidedTop == true)
            //{
            //    //Draw the message box
            //    MessageBox.DrawSprite(_spriteBatch, MessageBox.spriteTexture);
            //    //If the message box is in the engaged position
            //    if (windowInPosition == true)
            //    {
            //        //Draw the text
            //        MessageBox.DrawMessage(_spriteBatch);
            //    }
            //}

            //if (isBlack == true)
            //{
            //    GraphicsDevice.Clear(background);
            //    foreach(Tree t in treeObjects)
            //    {
            //        t.IsDraw = false;
            //    }
            //    foreach(ReadableObject s in signObjects)
            //    {
            //        s.IsDrawn = false;
            //    }
            //}
            //if (timer == 0)
            //{
            //    player.goingDown = true;
            //    player.goingUp = true;
            //    player.goingRight = true;
            //    player.goingLeft = true;
            //    loadContent = Content.Load<Texture2D>("Player_M");
            //    player = new Player(loadContent, new Vector2(360, 380), new Vector2(35, 50),true);
            //    isBlack = false;
            //    chest.DrawSprite(_spriteBatch, chest.spriteTexture);

            //}

            base.Draw(gameTime);
        }
    }
}
