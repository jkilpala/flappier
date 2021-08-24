using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Engine
{
    class SpriteComponent : Component
    {
        public TransformComponent MyTransform;
        public Color DrawColor;
        public Texture2D SpriteImage;
        public int DrawOrder;

        public SpriteComponent()
        {
            DrawColor = Color.White;
            DrawOrder = 0;
        }
        public SpriteComponent(Texture2D texture)
        {
            SpriteImage = texture;
            DrawColor = Color.White;
            DrawOrder = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(MyTransform == null)
                MyTransform = Parent.GetComponent<TransformComponent>();


            spriteBatch.Draw(
                SpriteImage, 
                MyTransform.Position,
                null, 
                DrawColor, 
                MyTransform.Rotation, 
                Vector2.Zero, 
                MyTransform.Scale, 
                SpriteEffects.None, 
                DrawOrder);

            base.Draw(spriteBatch);
        }

    }
}