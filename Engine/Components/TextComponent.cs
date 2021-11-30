using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class TextComponent : Component
    {
        //int fontSize;
        string text;
        
        Color color;
        SpriteFont spriteFont;
        TransformComponent myTransform;
        Vector2 anchor;
        Vector2 offset;

        public TextComponent(GameObject parent, SpriteFont spriteFont, string text, Color color)
        {
            this.Parent = parent;
            myTransform = this.Parent.GetComponent<TransformComponent>();
            this.spriteFont = spriteFont;
            this.text = text;
            this.color = color;

            anchor = new Vector2(0.5f, 0.5f);
            offset = new Vector2(50.0f, 50.0f);
        }
        public void SetText(string text)
        {
            this.text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);            

            spriteBatch.DrawString(spriteFont, text, GetAchoredAndOffsettedPosition(), color);
        }

        Vector2 GetAchoredAndOffsettedPosition()
        {
            Vector2 anchorPoint = spriteFont.MeasureString(text);
            anchorPoint *= anchor;
            return myTransform.Position - anchorPoint + offset;
        }

        public void SetOffset(Vector2 value)
        {
            offset = value;
        }
        public void SetOffset(float x, float y)
        {
            offset = new Vector2(x,y);
        }
        public void SetAnchor(Vector2 value)
        {
            anchor = value;
        }



    }
}