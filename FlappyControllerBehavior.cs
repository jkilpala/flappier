using System;
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

        Action gameOverAction;
        private Action restartGameAction;

        TransformComponent myTransform;

        public void SetGameOverAction(Action action)
        {
            gameOverAction = action;
        }

        public void SetTubeManager(TubeManagerBehavior manager)
        {
            tubeManagerBehavior = manager;
            myTransform = Parent.GetComponent<TransformComponent>();
        }

        public override void Update(float deltaTime)
        {
            KeyboardState state = Keyboard.GetState();

            if(state.IsKeyDown(Keys.Space) & !previousState.IsKeyDown(Keys.Space) && alive)
            {
                Parent.GetComponent<RigidBody2D>().AddForce(ForceType.Impulse, new Vector2(0.0f,-10.0f));
                Parent.GetComponent<SpriteSwapperBehavior>().SwapImages();
            }
            else if(state.IsKeyDown(Keys.Space) & !previousState.IsKeyDown(Keys.Space) && !alive)
            {
                restartGameAction.Invoke();
            }
            
            if(myTransform.Position.Y > 600)
            {
                Die();
            }

            previousState = state;
            base.Update(deltaTime);
        }
        public void Die()
        {
            if(!alive) return;
            System.Diagnostics.Debug.WriteLine("On flappy controller");
            tubeManagerBehavior.StopTubes();
            Parent.GetComponent<RigidBody2D>().StopVelocity();
            alive = false;
            gameOverAction.Invoke();
        }
        public override void OnCollision(BoxColliderComponent otherComponent)
        {
            if(otherComponent.Parent.GetComponent<NameComponent>().GetName().Equals("trigger"))
            {

            }
            else
            {
                Die();
            }
        }

        internal void SetRestartAction(Action restartGame)
        {
            restartGameAction = restartGame;
        }
    }
}