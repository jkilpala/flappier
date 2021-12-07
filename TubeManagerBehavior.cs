using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace flappy{
    class TubeManagerBehavior : Behavior
    {
        List<GameObject> tubes;
        List<GameObject> tubesToDestroy;


        Texture2D tubeImage;
        GraphicsDevice device;

        float timer = 0.0f;
        float spawnTime = 3.0f;

        public TubeManagerBehavior(Texture2D image, GraphicsDevice device)
        {
            tubeImage = image;
            this.device = device;
            tubes = new List<GameObject>();
            tubesToDestroy = new List<GameObject>();
        }
        public GameObject GenerateTube()
        {
            var tube = new GameObject();
            var transform = tube.GetComponent<TransformComponent>();
            transform.Position = new Vector2(400, 0);
            tube.AddComponent(new SpriteComponent(tubeImage));
            var boxCollider = (BoxColliderComponent)tube.AddComponent(new BoxColliderComponent(tube, device));
            boxCollider.SetSize(new Point(128,256));            
            tube.AddComponent(new MoveTubeBehavior());
            tube.OnStart();
            return tube;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            timer += deltaTime;
            if(timer >= spawnTime)
            {
                tubes.Add(GenerateTube());
                timer -= spawnTime;
            }

            foreach(var item in tubes)
            {
                item.Update(deltaTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach(var item in tubes)
            {
                item.Draw(spriteBatch);
            }
        }

    }
}