namespace Arvore.Classes
{
    public class Tree
    {
        public Tree(Node root)
        {
            NodeRoot = root;
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

        public int HeightNode(Node node, int depthAbsolute = 0)
        {
            while (true)
            {
                if (node.Left is not null)
                {
                    if (node.Level >= depthAbsolute)
                    {
                        var nodeIncrement = depthAbsolute + 1;
                        depthAbsolute = HeightNode(node.Left, nodeIncrement);
                    }
                    else
                    {
                        var nodeDepthRelative = HeightNode(node.Left, node.Left.Level);
                        if (depthAbsolute < nodeDepthRelative) depthAbsolute = nodeDepthRelative;
                    }
                }

                if (node.Right is not null)
                {
                    if (node.Level >= depthAbsolute)
                    {
                        var nodeIncrement = depthAbsolute + 1;
                        depthAbsolute = HeightNode(node.Right, nodeIncrement);
                    }
                    else
                    {
                        var nodeDepthRelative = HeightNode(node.Right, node.Right.Level);
                        if (depthAbsolute < nodeDepthRelative) depthAbsolute = nodeDepthRelative;
                    }
                }
                break;
            }
            return depthAbsolute;
        }

        public int DepthNode(Node node) => node.Level;
        public int LevelNode(Node node) => node.Level;
    }
}
