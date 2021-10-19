using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Component
    {
        Guid ID;
        public GameObject Parent;

        public Component()
        {
            ID = Guid.NewGuid();
        }

        public void SetParent(GameObject gameObject)
        {
            Parent = gameObject;
        }
        
        public virtual void OnStart()
        {
            
        }

        public virtual void Update(float deltaTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}