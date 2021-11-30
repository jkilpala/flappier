using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace flappy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //GameObject go;
        //GameObject go2;
        GameObject background;
        GameObject backgroundTop;
        GameObject backgroundTop2;

        GameObject flappy;
        


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //go = new GameObject();
            //var nameC = go.GetComponent<NameComponent>();
            //var transformC = go.GetComponent<TransformComponent>();             
            
            //GameObject go2 = new GameObject();
            //go2 = new GameObject();
            //go2.GetComponent<TransformComponent>().Position = new Vector2(0, 100);
            //go2.AddComponent(new BoxColliderComponent(go2, GraphicsDevice));
            _graphics.PreferredBackBufferWidth = 512;
            _graphics.PreferredBackBufferHeight = 512;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new GameObject();
            background.AddComponent(new SpriteComponent(Content.Load<Texture2D>("background")));
            
            backgroundTop = new GameObject();
            backgroundTop.AddComponent(new SpriteComponent(Content.Load<Texture2D>("backgroundtop")));
            backgroundTop.GetComponent<TransformComponent>().Position = new Vector2(0,512 - 128);
            //Behavior
            backgroundTop.AddComponent(new MovementBehavior());
            backgroundTop.OnStart();

            backgroundTop2 = new GameObject();
            backgroundTop2.AddComponent(new SpriteComponent(Content.Load<Texture2D>("backgroundtop")));
            backgroundTop2.GetComponent<TransformComponent>().Position = new Vector2(512,512 - 128);
            //Behavior
            backgroundTop2.AddComponent(new MovementBehavior());
            backgroundTop2.OnStart();


            flappy = new GameObject();
            var spriteCompnent = (SpriteComponent)flappy.AddComponent(new SpriteComponent(Content.Load<Texture2D>("Ship")));
            spriteCompnent.Anchor = new Vector2(0.5f,0.5f);
            flappy.GetComponent<TransformComponent>().Position = new Vector2(256,256);
            flappy.AddComponent(new BoxColliderComponent(flappy, _graphics.GraphicsDevice));
            flappy.AddComponent(new RigidBody2D());
            //Behavior
            flappy.OnStart();

            //go.GetComponent<TransformComponent>().Position = new Vector2(50,50);
            //go.AddComponent(new SpriteComponent(Content.Load<Texture2D>("Ship")));
            //go.AddComponent(new RigidBody2D());
            //go.AddComponent(new BoxColliderComponent(go, GraphicsDevice));
            //go.AddComponent(new TextComponent(go, Content.Load<SpriteFont>("TestFont"),"Muumi", Color.Black));

            //go.AddComponent(new TestBehavior());

            //var text1 = (TextComponent)go2.AddComponent(new TextComponent(go2, Content.Load<SpriteFont>("TestFont"),"Kukka", Color.Red));
            //text1.SetOffset(50,0);

            //text1 = (TextComponent)go2.AddComponent(new TextComponent(go2, Content.Load<SpriteFont>("TestFont"),"Joku", Color.Red));
            //text1.SetOffset(50,50);

            //go.OnStart();
            //go2.OnStart();
            // TODO: use this.Content to load your game content here
        }
        bool wBlocker = false;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            PhysicsEngine.Instance.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your update logic here

            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //go.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(0.0f,2.0f));
            }

            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //go.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(2.0f,0.0f));
            }
            
            if(Keyboard.GetState().IsKeyDown(Keys.W) && !wBlocker)
            {
                flappy.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(0.0f,-10.0f));
                wBlocker = true;
            }
            else if(Keyboard.GetState().IsKeyUp(Keys.W))
            {
                wBlocker = false;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //go.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(-1.0f,0.0f));
            }

            //go.Update((float)gameTime.TotalGameTime.TotalSeconds);
            //go2.Update((float)gameTime.TotalGameTime.TotalSeconds);
            backgroundTop.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            backgroundTop2.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            flappy.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            background.Draw(_spriteBatch);
            backgroundTop.Draw(_spriteBatch);
            backgroundTop2.Draw(_spriteBatch);
            flappy.Draw(_spriteBatch);
            //go.Draw(_spriteBatch);
            //go2.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
