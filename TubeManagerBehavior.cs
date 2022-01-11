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

        Random random;

        float timer = 0.0f;
        float spawnTime = 3.0f;
        int lastRandom;

        int tubeStep = 50;
        bool moveTubes = true;

        public TubeManagerBehavior(Texture2D image, GraphicsDevice device)
        {
            tubeImage = image;
            this.device = device;
            tubes = new List<GameObject>();
            tubesToDestroy = new List<GameObject>();
            random = new Random();
        }
        public GameObject GenerateTube(bool up)
        {
            var tube = new GameObject();
            var transform = tube.GetComponent<TransformComponent>();            
            
            if(up)
            {
                lastRandom = random.Next(0,3);
                transform.Position = new Vector2(600, -100 + (lastRandom * tubeStep));
                transform.Scale = new Vector2(1, 1);
            }
            else
            {
                transform.Position = new Vector2(600, 312 + (lastRandom * tubeStep));
                transform.Scale = new Vector2(1, -1);
            }
            
            
            
            tube.AddComponent(new SpriteComponent(tubeImage));
            var boxCollider = (BoxColliderComponent)tube.AddComponent(new BoxColliderComponent(tube, device));
            boxCollider.SetSize(new Point(128,256));            
            tube.AddComponent(new MoveTubeBehavior());
            tube.OnStart();
            return tube;
        }

        internal void StopTubes()
        {
            moveTubes = false;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if(!moveTubes) return;

            timer += deltaTime;
            if(timer >= spawnTime)
            {
                tubes.Add(GenerateTube(true));
                tubes.Add(GenerateTube(false));
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