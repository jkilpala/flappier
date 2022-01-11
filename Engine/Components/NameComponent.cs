namespace Engine
{
    class NameComponent : Component
    {
        string Name;

        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }

        public NameComponent(string name)
        {
            Name = name;
        }
    }
}