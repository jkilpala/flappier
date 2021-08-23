using System;

namespace Engine
{
    class Component
    {
        Guid ID;

        public Component()
        {
            ID = Guid.NewGuid();
        }
    }
}