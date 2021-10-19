using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class TextComponent : Component
    {
        //int fontSize;
        string text;
        //Vector2 offset;
        Color color;
        SpriteFont spriteFont;
        TransformComponent myTransform;

        public TextComponent(GameObject parent, SpriteFont spriteFont, string text, Color color)
        {
            this.Parent = parent;
            myTransform = this.Parent.GetComponent<TransformComponent>();
            this.spriteFont = spriteFont;
            this.text = text;
            this.color = color;
        }
        public void SetText(string text)
        {
            this.text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(spriteFont, text, myTransform.Position, color);
        }


    }
}