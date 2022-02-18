namespace Arvore.Classes
{
    public class Node
    {
        public Node(string name)
        {
            Name = name;
        }
        public Node(string name, bool isRoot)
        {
            Name = name;
            IsRoot = isRoot;
        }

        public string Name { get; set; }
        public Node? Father { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public bool IsRoot { get; set; }
        public int Level { get; set; }

        public void AddSon(Node son)
        {
            son.Level = Level + 1;
            if (Left is null)
                Left = son;
            else
                Right = son;
            son.Father = this;
        }
    }
}
