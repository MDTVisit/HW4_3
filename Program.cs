using System;

class MainClass {
  public static void Main (string[] args) {
    Console.Write("Enter number of nodes: ");
    int n = int.Parse(Console.ReadLine());

    int[,] graph = new int[n, n];

    int i, j;
    while (true) {
      Console.Write("i = ");
      i = int.Parse(Console.ReadLine());
      if (i < 0 || i >= n) break;

      Console.Write("j = ");
      j = int.Parse(Console.ReadLine());
      if (j < 0 || j >= n) break;

      graph[i, j] = 1;
    }

    while (true) {
      Console.Write("j = ");
      j = int.Parse(Console.ReadLine());
      if (j < 0 || j >= n) break;

      Console.Write("i = ");
      i = int.Parse(Console.ReadLine());
      if (i < 0 || i >= n) break;

      bool reachable = IsReachable(graph, j, i, n);
      if (reachable) {
        Console.WriteLine("Reachable");
      } else {
        Console.WriteLine("Unreachable");
      }
    }
  }

  static bool IsReachable(int[,] graph, int j, int i, int n) {
    bool[] visited = new bool[n];
    visited[j] = true;
    return DFS(graph, visited, j, i);
  }

  static bool DFS(int[,] graph, bool[] visited, int j, int i) {
    if (j == i) {
      return true;
    }

    for (int k = 0; k < visited.Length; k++) {
      if (graph[j, k] == 1 && !visited[k]) {
        visited[k] = true;
        if (DFS(graph, visited, k, i)) {
          return true;
        }
      }
    }

    return false;
  }
}
