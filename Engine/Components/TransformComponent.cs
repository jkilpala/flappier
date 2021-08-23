using Microsoft.Xna.Framework;

namespace Engine
{
    class TransformComponent : Component
    {
        Vector2 Position;
        float Rotation;
        Vector2 Scale;

        public TransformComponent()
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Scale = Vector2.One;
        }
    }
}