using System.Collections.Generic;

namespace Engine
{
    class PhysicsEngine
    {
        static PhysicsEngine instance;
        public static PhysicsEngine Instance
        {
            get
            {
                if(instance == null)
                    instance = new PhysicsEngine();
                return instance;
            }
        }

        List<RigidBody2D> affectedObjects;

        public PhysicsEngine()
        {
            affectedObjects = new List<RigidBody2D>();
        }

        public void RegisterToPhysics(RigidBody2D rigidBody2D)
        {
            affectedObjects.Add(rigidBody2D);
        }

        public void Update(float deltaTime)
        {
            for(int i = 0; i < affectedObjects.Count; i++)
            {
                affectedObjects[i].Update(deltaTime);
            }
        }
    }
}