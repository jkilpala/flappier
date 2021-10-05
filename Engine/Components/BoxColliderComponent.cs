using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class BoxColliderComponent : DebugDrawComponent
    {
        Vector2 position;
        Rectangle boundingBox;
        bool drawDebug = true;
        TransformComponent myTransform;

        public BoxColliderComponent(GameObject parent, GraphicsDevice device) : base(device)
        {
            position = Vector2.Zero;
            Parent = parent;
            myTransform = Parent.GetComponent<TransformComponent>();
            boundingBox = new Rectangle((int)myTransform.Position.X, (int)myTransform.Position.Y, 100, 100);
            AddVectorsForRectangle(boundingBox);
            PhysicsEngine.Instance.RegisterCollider(this);
        }
        public Rectangle GetCollider()
        {
            return boundingBox;
        }
        public override void Update(float deltaTime)
        {            
            base.Update(deltaTime);
            boundingBox.Location = new Point((int)(myTransform.Position.X + position.X), (int)(myTransform.Position.Y + position.Y));
            UpdateGraphicsPosition(myTransform.Position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(drawDebug)
                base.Draw(spriteBatch);
        }
    }
}