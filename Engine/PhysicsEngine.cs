using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine
{
    class PhysicsEngine
    {
        static PhysicsEngine instance;
        Vector2 gravity = new Vector2(0,9.81f);
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
        List<BoxColliderComponent> boxColliders;

        public Vector2 GetGravity()
        {
            return gravity;
        }

        public PhysicsEngine()
        {
            affectedObjects = new List<RigidBody2D>();
            boxColliders = new List<BoxColliderComponent>();
        }

        public PhysicsEngine RegisterToPhysics(RigidBody2D rigidBody2D)
        {
            affectedObjects.Add(rigidBody2D);
            return this;
        }
        public void RegisterCollider(BoxColliderComponent colliderComponent)
        {
            boxColliders.Add(colliderComponent);
        }

        public void Update(float deltaTime)
        {
            if(boxColliders.Count > 1)
            {
                for(int i = 0; i < boxColliders.Count; i++)
                {
                    for(int n = i+1; n <= boxColliders.Count-1; n++)
                    {
                        var collider1 = boxColliders[i].GetCollider();
                        var collider2 = boxColliders[n].GetCollider();

                        var collision = collider1.Intersects(collider2);

                        if(collision)
                        {
                            System.Diagnostics.Debug.WriteLine("Törmäys");
                            boxColliders[i].ReportCollision(boxColliders[n]);
                        }
                    }
                }

            }


            for(int i = 0; i < affectedObjects.Count; i++)
            {
                affectedObjects[i].Update(deltaTime);
            }
        }
    }
}