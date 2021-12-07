using Engine;
using Microsoft.Xna.Framework.Graphics;

namespace flappy
{
    class SpriteSwapperBehavior : Behavior
    {
        SpriteComponent mySpriteComponent;
        Texture2D image01;
        Texture2D image02;

        bool setFirstImage = true;

        public void SetImages(Texture2D i1, Texture2D i2)
        {
            image01 = i1;
            image02 = i2;
            mySpriteComponent = Parent.GetComponent<SpriteComponent>();
        }

        public void SwapImages()
        {
            if(setFirstImage)
            {
                mySpriteComponent.SetImage(image01);
                setFirstImage = false;
            }
            else
            {
                mySpriteComponent.SetImage(image02);
                setFirstImage = true;
            }
        }


    }

}