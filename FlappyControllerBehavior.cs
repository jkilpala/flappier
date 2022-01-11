using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace flappy
{
    class FlappyControllerBehavior : Behavior
    {
        KeyboardState previousState;

        TubeManagerBehavior tubeManagerBehavior;
        bool alive = true;

        public void SetTubeManager(TubeManagerBehavior manager)
        {
            tubeManagerBehavior = manager;
        }

        public override void Update(float deltaTime)
        {
            KeyboardState state = Keyboard.GetState();

            if(state.IsKeyDown(Keys.Space) & !previousState.IsKeyDown(Keys.Space) && alive)
            {
                Parent.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(0.0f,-10.0f));
                Parent.GetComponent<SpriteSwapperBehavior>().SwapImages();
            }
            
            previousState = state;
            base.Update(deltaTime);
        }
        public override void OnCollision(BoxColliderComponent otherComponent)
        {
            base.OnCollision(otherComponent);
            if(!alive) return;
            System.Diagnostics.Debug.WriteLine("On flappy controller");
            tubeManagerBehavior.StopTubes();
            Parent.GetComponent<RigidBody2D>().StopVelocity();
            alive = false;
        }
    }
}