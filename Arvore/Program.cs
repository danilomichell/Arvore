﻿using Arvore.Classes;
using Arvore.Services;

var services = new NodeServices();
var nodeDad = new Node("A", true);
var nodeSon1 = new Node("B");
var nodeSon2 = new Node("C");
var nodeSon3 = new Node("D");
var nodeSon4 = new Node("E");

nodeDad.AddSon(nodeSon1);
nodeDad.AddSon(nodeSon2);
nodeSon1.AddSon(nodeSon3);
nodeSon2.AddSon(nodeSon4);

Console.WriteLine("Árvore completa");
services.PrintTree(nodeDad);
Console.WriteLine(new string('-', 40));
Console.WriteLine(NodeServices.NodeLeaf(nodeDad)
    ? $"O nó {nodeDad.Name} é um nó folha"
    : $"O nó {nodeDad.Name} não é um nó folha");
Console.WriteLine(new string('-', 40));
Console.WriteLine($"O grau do nó {nodeDad.Name} é {NodeServices.DegreeNode(nodeDad)}");
Console.WriteLine(new string('-', 40));
Console.WriteLine($"A profundidade do nó {nodeDad.Name} é {NodeServices.DepthNode(nodeDad)}");
Console.WriteLine(new string('-', 40));
Console.WriteLine($"O nível do nó {nodeDad.Name} é {NodeServices.LevelNode(nodeDad)}");
Console.WriteLine(new string('-', 40));
services.PrintSubTree(nodeDad);