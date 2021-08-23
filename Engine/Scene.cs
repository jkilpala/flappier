using System.Collections.Generic;

namespace Engine
{
    class Scene
    {
        List<GameObject> gameObjectsInScene;

        public Scene()
        {
            gameObjectsInScene = new List<GameObject>();
        }
    }
}