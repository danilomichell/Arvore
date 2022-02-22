using Arvore.Classes;

namespace Arvore.Services
{
    public class NodeServices
    {
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

        public static bool NodeLeaf(Node node) => node.Left is null && node.Right is null;

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

        public static int DegreeNode(Node node)
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
                        var increment = depthAbsolute + 1;
                        depthAbsolute = HeightNode(node.Left, increment);
                    }
                    else
                    {
                        var depthRelative = HeightNode(node.Left, node.Left.Level);
                        if (depthAbsolute < depthRelative) depthAbsolute = depthRelative;
                    }
                }

                if (node.Right is not null)
                {
                    if (node.Level >= depthAbsolute)
                    {
                        var increment = depthAbsolute + 1;
                        depthAbsolute = HeightNode(node.Right, increment);
                    }
                    else
                    {
                        var depthRelative = HeightNode(node.Right, node.Right.Level);
                        if (depthAbsolute < depthRelative) depthAbsolute = depthRelative;
                    }
                }
                break;
            }
            return depthAbsolute;
        }

        public static int DepthNode(Node node) => node.Level;
        public static int LevelNode(Node node) => node.Level;
    }
}
