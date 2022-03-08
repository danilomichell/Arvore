using Arvore.Classes;

var nodeDad = new Node("A", true);
var nodeSon1 = new Node("B");
var nodeSon2 = new Node("C");
var nodeSon3 = new Node("D");
var nodeSon4 = new Node("E");
var nodeSon5 = new Node("F");
var nodeSon6 = new Node("G");
var nodeSon7 = new Node("H");
var nodeSon8 = new Node("I");

nodeDad.AddSon(nodeSon1);
nodeDad.AddSon(nodeSon2);
nodeSon1.AddSon(nodeSon3);
nodeSon2.AddSon(nodeSon4);
nodeSon3.AddSon(nodeSon5);
nodeSon4.AddSon(nodeSon6);
nodeSon6.AddSon(nodeSon7);
nodeSon7.AddSon(nodeSon8);

var tree = new Tree(nodeDad);
Console.WriteLine("Árvore completa");
tree.PrintTree(nodeDad);
Console.WriteLine(new string('-', 40));
Console.WriteLine(tree.NodeLeaf(nodeDad)
    ? $"O nó {nodeDad.Name} é um nó folha"
    : $"O nó {nodeDad.Name} não é um nó folha");
Console.WriteLine(new string('-', 40));
Console.WriteLine($"O grau do nó {nodeDad.Name} é {tree.DegreeNode(nodeDad)}");
Console.WriteLine(new string('-', 40));
Console.WriteLine($"A profundidade do nó {nodeDad.Name} é {tree.HeightNode(nodeDad)}");
Console.WriteLine(new string('-', 40));
Console.WriteLine($"O nível do nó {nodeDad.Name} é {tree.LevelNode(nodeDad)}");
Console.WriteLine(new string('-', 40));
tree.PrintSubTree(nodeDad);
Console.WriteLine(new string('-', 40));
Console.WriteLine($"A altura do nó {nodeSon3.Name} é {tree.DepthNode(nodeSon3)}");


Console.ReadKey();