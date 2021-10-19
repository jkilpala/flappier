using Engine;

namespace flappy
{
    class TestBehavior : Behavior
    {
        TransformComponent myTransform;

        public override void OnStart()
        {
            myTransform = Parent.GetComponent<TransformComponent>();
            base.OnStart();
        }

        public override void Update(float deltaTime)
        {
            myTransform.Rotation = 1.0f * deltaTime;
            base.Update(deltaTime);
        }
    }
}