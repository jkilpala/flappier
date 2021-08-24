using Microsoft.Xna.Framework;

namespace Engine
{
    class TransformComponent : Component
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public TransformComponent()
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Scale = Vector2.One;
        }
    }
}