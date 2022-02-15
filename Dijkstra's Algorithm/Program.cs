﻿/*
This program using Dijkstra's single source shortest path algorithm.
- For adjacency matrix representation of the graph
 */

 using System;

 class GUtil {
     /* 
     This utility function finds the vertex with minimum distance value
     from the set of vertices not yet included in shortest path tree.
     */
     static int numV = 9;

     int minDistance(int[] dist, bool[] sptSet){
         
         // Initialize minimum value
         int min = int.MaxValue, min_index = -1;

        for(int v = 0; v < numV; v++){
            if(sptSet[v] == false && dist[v] <= min){
                min = dist[v];
                min_index = v;
            }
        }
        return min_index;
     }

     // Utility function which prints the constructed distance array
     void printSolution(int[] dist, int n){
         Console.Write("Vertex      Distance from source " + "\n");
         for(int i = 0; i < numV; i++){
             Console.Write(i + " \t\t " + dist[i] + "\n");
         }
     }

     // Function which implements Dijkstra's single source shortest path algorithm
     void dijkstra(int[, ] graph, int src){
         // Output array - dist[i] - will hold the shortest distance from src to i
         int[] dist = new int[numV];

        // sptSet[i] will be true if vertex i is included in shortest path tree or shortest distance from src to i is finalized
        bool[] sptSet = new bool[numV];

        // Initialize all distances as infinite and stpSet[] as false
        for(int i = 0; i < numV; i++){
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        // Distance of source vertex from itself is always 0
        dist[src] = 0;

        // Find the shortest path for all vertices
        for (int count = 0; count < numV - 1; count++){
            // Pick the minimum distance vertex from the set of vertices not yet processed. u is always equal to src in first iteration.
            int u = minDistance(dist, sptSet);

            // Mark the picked vertex as processed
            sptSet[u] = true;

            // Update dist value of the adjacent vertices of the picked vertex
            for (int v = 0; v < numV; v++){
                // Update dist[v] only if it is not in sptSet, there is an edge from u to v, and total weight of path from src to v through u is smaller than current value of dist[v]
                if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v]){
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }
        printSolution(dist, numV);
     }

     // Driver Code
     public static void Main(string[] args){
         int[, ] graph = new int[, ] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

        GUtil t = new GUtil();
        t.dijkstra(graph, 0);
     }
 }