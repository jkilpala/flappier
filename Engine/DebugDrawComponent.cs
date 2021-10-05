using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;


namespace Engine
{
    class DebugDrawComponent : Component
    {
        Texture2D pixel;
        List<Vector2> vectors;
        Color color;
        Vector2 position;
        float depth;

        public DebugDrawComponent(GraphicsDevice device)
        {
            //Create pixel texture
            pixel = new Texture2D(device,1,1,false,SurfaceFormat.Color);
            Color[] pixels = new Color[1];
            pixels[0] = Color.Yellow;
            pixel.SetData<Color>(pixels);

            color = Color.White;
            position = Vector2.Zero;
            depth = 0;

            vectors = new List<Vector2>();
        }

        public void UpdateGraphicsPosition(Vector2 pos)
        {
            position = pos;
        }

        protected void AddVectorsForRectangle(Rectangle rect)
        {
            // vectors.Add(new Vector2(rect.X,rect.Y));
            // vectors.Add(new Vector2(rect.X + rect.Width,rect.Y));
            // vectors.Add(new Vector2(rect.X + rect.Width,rect.Y + rect.Height));
            // vectors.Add(new Vector2(rect.X, rect.Y + rect.Height));
            // vectors.Add(new Vector2(rect.X,rect.Y));

            vectors.Add(new Vector2(0,0));
            vectors.Add(new Vector2(rect.Width,0));
            vectors.Add(new Vector2(rect.Width,rect.Height));
            vectors.Add(new Vector2(0, rect.Height));
            vectors.Add(new Vector2(0,0));

        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(vectors.Count < 2)
                return;
            
            for(int i = 1; i < vectors.Count; i++)
            {
                Vector2 vector1 = vectors[i - 1];
                Vector2 vector2 = vectors[i];

                //Calculate the distance between the two vectors
                float distance = Vector2.Distance(vector1, vector2);

                //Calculate the angle between the two vectors
                float angle = (float)Math.Atan2((double)(vector2.Y - vector1.Y), (double)(vector2.X - vector1.X));

                //strech the pixel between the two vectors
                spriteBatch.Draw(
                    pixel,
                    position + vector1,
                    null,
                    color,
                    angle,
                    Vector2.Zero,
                    new Vector2(distance, 1),
                    SpriteEffects.None,
                    depth
                );
            }        
            
            base.Draw(spriteBatch);
        }

    }
}