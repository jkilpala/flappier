using Engine;

namespace flappy{

    class RotatorBehavior : Behavior
    {
        TransformComponent myTransform;
        RigidBody2D myRigidBody;

        public override void Update(float deltaTime)
        {
            if(myRigidBody == null)
            {
                myRigidBody = Parent.GetComponent<RigidBody2D>();
                myTransform = Parent.GetComponent<TransformComponent>();
            }
            base.Update(deltaTime);

            if(myRigidBody.GetVelocity().Y < 0)
            {
                myTransform.Rotation = 0;
            }
            else if(myRigidBody.GetVelocity().Y > 0)
            {
                myTransform.Rotation = 90;
            }

        }
    }
}