using System.Collections.Generic;

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

        public void AddComponent(Component component)
        {
            componentsInGameObject.Add(component);
        }


    }
}