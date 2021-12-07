using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class BoxColliderComponent : DebugDrawComponent
    {
        Vector2 position;
        Rectangle boundingBox;
        bool drawDebug = true;
        public Vector2 Anchor;
        public Point Size;




        TransformComponent myTransform;

        public BoxColliderComponent(GameObject parent, GraphicsDevice device) : base(device)
        {
            Anchor = new Vector2(0.0f, 0.0f);
            Size = new Point(100,100);
            position = Vector2.Zero;
            Parent = parent;
            myTransform = Parent.GetComponent<TransformComponent>();
            boundingBox = new Rectangle(
                (int)myTransform.Position.X -(int)(Size.X * Anchor.X),
                 (int)myTransform.Position.Y -(int)(Size.Y * Anchor.Y),
                  Size.X,
                   Size.Y);
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
            boundingBox.Location = new Point(
                (int)(myTransform.Position.X + position.X - (int)(Size.X * Anchor.X)),
                 (int)(myTransform.Position.Y + position.Y - (int)(Size.Y * Anchor.Y)));
            
            
            UpdateGraphicsPosition(new Vector2(boundingBox.Location.X, boundingBox.Location.Y));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(drawDebug)
                base.Draw(spriteBatch);
        }

        internal void SetSize(Point size)
        {
            Size = size;
            boundingBox = new Rectangle(
                (int)myTransform.Position.X -(int)(Size.X * Anchor.X),
                 (int)myTransform.Position.Y -(int)(Size.Y * Anchor.Y),
                  Size.X,
                   Size.Y);
            AddVectorsForRectangle(boundingBox);
        }

        internal void SetAnchor(Vector2 anchor)
        {
            Anchor = anchor;
        }
    }
}