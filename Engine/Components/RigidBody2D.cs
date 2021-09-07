using Microsoft.Xna.Framework;

namespace Engine
{
    enum ForceType { Impulse, Constant }
    class RigidBody2D : Component
    {
        Vector2 velocity;
        float friction;
        float mass;
        TransformComponent MyTransform;
        
        public RigidBody2D()
        {
            velocity = Vector2.Zero;
            mass = 1.0f;
            friction = 0.9f;
            PhysicsEngine.Instance.RegisterToPhysics(this);
        }

        public void AddForce(ForceType forceType, Vector2 direction)
        {
            if(forceType == ForceType.Impulse)
            {
                velocity += direction;
            }
        }

        public void Update(float deltaTime)
        {
            if(MyTransform == null)
                MyTransform = Parent.GetComponent<TransformComponent>();

            velocity *= friction;
            MyTransform.Position += velocity;
        }

    }
}