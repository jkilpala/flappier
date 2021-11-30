using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class GameObject
    {
        List<Component> componentsInGameObject;

        List<NameComponent> qwe;
        public GameObject()
        {
            componentsInGameObject = new List<Component>();
            AddComponent(new NameComponent("Default"));
            AddComponent(new TransformComponent());            
            //qwe = new List<NameComponent>();
        }

        public Component AddComponent(Component component)
        {
            component.SetParent(this);
            componentsInGameObject.Add(component);

            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            return (T)componentsInGameObject.Find(c => c.GetType() == typeof(T));
        }

        public void OnStart()
        {
            for(int i = 0; i < componentsInGameObject.Count; i++)
            {
                componentsInGameObject[i].OnStart();
            }
        }
        public void Update(float deltaTime)
        {
            for(int i = 0; i < componentsInGameObject.Count; i++)
            {
                componentsInGameObject[i].Update(deltaTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < componentsInGameObject.Count; i++)
            {
                componentsInGameObject[i].Draw(spriteBatch);
            }
        }


    }
}