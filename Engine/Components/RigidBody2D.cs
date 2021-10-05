using Microsoft.Xna.Framework;

namespace Engine
{
    enum ForceType { Impulse, Constant }
    class RigidBody2D : Component
    {
        Vector2 velocity;
        Vector2 acceleration;
        float friction;
        float mass;
        TransformComponent MyTransform;
        PhysicsEngine physicsEngine;
        bool affectedWithGravity = true;

        
        public RigidBody2D()
        {
            velocity = Vector2.Zero;
            mass = 1.0f;
            friction = 0.9f;
            physicsEngine = PhysicsEngine.Instance.RegisterToPhysics(this);
        }

        public void AddForce(ForceType forceType, Vector2 direction)
        {
            if(forceType == ForceType.Impulse)
            {
                acceleration += direction;
            }
        }

        public void Update(float deltaTime)
        {
            if(MyTransform == null)
                MyTransform = Parent.GetComponent<TransformComponent>();

            if(affectedWithGravity)
            {
                acceleration += physicsEngine.GetGravity() * deltaTime;
            }

            acceleration *= (1.0f-friction);
            velocity += acceleration;
            //velocity *= friction;
            MyTransform.Position += velocity;
        }

    }
}