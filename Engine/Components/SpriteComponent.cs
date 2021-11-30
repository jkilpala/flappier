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
        public Vector2 Anchor;
        public Vector2 Offset;



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
            Anchor = new Vector2(0.0f, 0.0f);
            Offset = new Vector2(0.0f, 0.0f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(MyTransform == null)
                MyTransform = Parent.GetComponent<TransformComponent>();

            spriteBatch.Draw(
                SpriteImage, 
                GetOffsettedPosition(),
                null, 
                DrawColor, 
                MyTransform.Rotation, 
                GetAnchorPoint(), 
                MyTransform.Scale, 
                SpriteEffects.None, 
                DrawOrder);

            base.Draw(spriteBatch);
        }

        Vector2 GetAnchorPoint()
        {
            Vector2 anchorPoint = new Vector2(SpriteImage.Width, SpriteImage.Height);
            anchorPoint *= Anchor;
            return anchorPoint;
        }

        Vector2 GetOffsettedPosition()
        {
            return MyTransform.Position + Offset;
        }

    }
}