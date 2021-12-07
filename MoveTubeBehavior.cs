using Engine;

namespace flappy
{
    class MoveTubeBehavior : Behavior
    {
        TransformComponent myTransform;

        public override void OnStart()
        {
            myTransform = Parent.GetComponent<TransformComponent>();
            base.OnStart();
        }

        public override void Update(float deltaTime)
        {
            myTransform.Position = new Microsoft.Xna.Framework.Vector2(myTransform.Position.X - 100 * deltaTime, myTransform.Position.Y);

            base.Update(deltaTime);
        }
    }
}