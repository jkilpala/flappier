using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

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

        internal void SetImage(Texture2D image)
        {
            SpriteImage = image;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(MyTransform == null)
                MyTransform = Parent.GetComponent<TransformComponent>();


            SpriteEffects spriteEffects = SpriteEffects.None;
            Vector2 fixedScale = MyTransform.Scale;

            
            if(MyTransform.Scale.X < 0 && MyTransform.Scale.Y < 0)
            {
                spriteEffects = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
                fixedScale.X *= -1;
                fixedScale.Y *= -1;
            }
            else if(MyTransform.Scale.X < 0)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
                fixedScale.X *= -1;
            }
            else if(MyTransform.Scale.Y < 0)
            {
                spriteEffects = SpriteEffects.FlipVertically;
                fixedScale.Y *= -1;

            }



            spriteBatch.Draw(
                SpriteImage, 
                GetOffsettedPosition(),
                null, 
                DrawColor, 
                MyTransform.Rotation, 
                GetAnchorPoint(), 
                fixedScale, 
                spriteEffects, 
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