namespace Arvore.Classes
{
    public class Tree
    {
        public Tree(Node nodeRoot)
        {
            NodeRoot = nodeRoot;
        }
        public Node NodeRoot { get; set; }

        public void PrintTree(Node node)
        {
            while (true)
            {
                Console.WriteLine(new string(' ', 3 * node.Level) + node.Name);
                if (node.Left is not null) PrintTree(node.Left);
                if (node.Right is not null)
                {
                    node = node.Right;
                    continue;
                }

                break;
            }
        }

        public bool NodeLeaf(Node node) => node.Left is null && node.Right is null;

        public void PrintSubTree(Node node)
        {
            if (NodeLeaf(node)) Console.WriteLine("Não existe sub árvores para esse nó");

            if (node.Left is null) return;
            Console.WriteLine($"Sub árvore da esquerda do nó {node.Name}");
            PrintTree(node.Left);

            if (node.Right is null) return;
            Console.WriteLine($"Sub árvore da direita do nó {node.Name}");
            PrintTree(node.Right);
        }

        public int DegreeNode(Node node)
        {
            if (NodeLeaf(node))
                return 0;
            return node.Right is null ? 1 : 2;
        }

        private int HeightNodeAbsolute(Node node, int depthAbsolute = 0)
        {
            while (true)
            {
                if (node.Left is not null)
                {
                    if (node.Level >= depthAbsolute)
                    {
                        var increment = depthAbsolute + 1;
                        depthAbsolute = HeightNodeAbsolute(node.Left, increment);
                    }
                    else
                    {
                        var depthRelative = HeightNodeAbsolute(node.Left, node.Left.Level);
                        if (depthAbsolute < depthRelative) depthAbsolute = depthRelative;
                    }
                }

                if (node.Right is not null)
                {
                    if (node.Level >= depthAbsolute)
                    {
                        var increment = depthAbsolute + 1;
                        depthAbsolute = HeightNodeAbsolute(node.Right, increment);
                    }
                    else
                    {
                        var depthRelative = HeightNodeAbsolute(node.Right, node.Right.Level);
                        if (depthAbsolute < depthRelative) depthAbsolute = depthRelative;
                    }
                }
                break;
            }
            return depthAbsolute;
        }

        public int HeightNode(Node node)
        {
            return HeightNodeAbsolute(node) - node.Level;
        }

        public int DepthNode(Node node) => node.Level;
        public int LevelNode(Node node) => node.Level;
    }
}
