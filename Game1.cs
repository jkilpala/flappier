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

        //GameObject tube;
        GameObject tubeManager;

        bool GameOver = false;
        


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
        void RestartGame()
        {
            //background object
            background = new GameObject();
            background.AddComponent(new SpriteComponent(Content.Load<Texture2D>("background")));
            
            //paralax bckgrounds
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

            //Flappy object
            flappy = new GameObject();
            var spriteCompnent = (SpriteComponent)flappy.AddComponent(new SpriteComponent(Content.Load<Texture2D>("Ship")));
            spriteCompnent.Anchor = new Vector2(0.5f,0.5f);
            flappy.GetComponent<TransformComponent>().Position = new Vector2(256,256);
            var boxCollider = (BoxColliderComponent)flappy.AddComponent(new BoxColliderComponent(flappy, _graphics.GraphicsDevice));
            boxCollider.SetSize(new Point(64,64));
            boxCollider.SetAnchor(new Vector2(0.5f,0.5f));
            var spriteSwapper = (SpriteSwapperBehavior)flappy.AddComponent(new SpriteSwapperBehavior());            
            spriteSwapper.SetImages(Content.Load<Texture2D>("Ship02"), Content.Load<Texture2D>("Ship"));
            flappy.AddComponent(new RigidBody2D());
            flappy.AddComponent(new RotatorBehavior());

            var controller =  (FlappyControllerBehavior)flappy.AddComponent(new FlappyControllerBehavior());
            controller.SetGameOverAction(SetGameOver);
            controller.SetRestartAction(RestartGame);
            //Behavior
            flappy.OnStart();            

            tubeManager = new GameObject();
            var manager =  (TubeManagerBehavior)tubeManager.AddComponent(new TubeManagerBehavior(Content.Load<Texture2D>("tube"), _graphics.GraphicsDevice));

            controller.SetTubeManager(manager);
            GameOver = false;
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            RestartGame();
            // TODO: use this.Content to load your game content here
        }
        bool wBlocker = false;

        void SetGameOver()
        {
            GameOver = true;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            PhysicsEngine.Instance.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your update logic here

            

            //go.Update((float)gameTime.TotalGameTime.TotalSeconds);
            //go2.Update((float)gameTime.TotalGameTime.TotalSeconds);

            if(!GameOver)
            {
                backgroundTop.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                backgroundTop2.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                tubeManager.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            
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
            tubeManager.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
