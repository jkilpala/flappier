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
        GameObject go;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            go = new GameObject();
            var nameC = go.GetComponent<NameComponent>();
            var transformC = go.GetComponent<TransformComponent>();             
            
            //GameObject go2 = new GameObject();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            go.AddComponent(new SpriteComponent(Content.Load<Texture2D>("Ship")));
            go.AddComponent(new RigidBody2D());
            go.AddComponent(new BoxColliderComponent(go, GraphicsDevice));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            PhysicsEngine.Instance.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your update logic here

            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                go.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(0.0f,2.0f));
            }

            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                go.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(2.0f,0.0f));
            }
            
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                go.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(0.0f,-1.0f));
            }

            if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                go.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(-1.0f,0.0f));
            }

            go.Update((float)gameTime.TotalGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            go.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
