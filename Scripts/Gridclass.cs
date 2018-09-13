using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridclass : MonoBehaviour {

    public static int w = 20;
    public static int h = 23;
    public static Element[,] elements = new Element[w, h];

    public static void uncoverMines()
 {
     foreach (Element elem in elements)
         if (elem.mine)
             elem.loadTexture(0);
 }
    public static bool mineLocation(int x, int y)
    {

     if (x >= 0 && y >= 0 && x < w && y < h)
         return elements[x, y].mine;
     return false;
    }
    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineLocation(x, y + 1)) ++count; 
        if (mineLocation(x + 1, y + 1)) ++count; 
        if (mineLocation(x + 1, y)) ++count; 
        if (mineLocation(x + 1, y - 1)) ++count; 
        if (mineLocation(x, y - 1)) ++count; 
        if (mineLocation(x - 1, y - 1)) ++count; 
        if (mineLocation(x - 1, y)) ++count; 
        if (mineLocation(x - 1, y + 1)) ++count;

        return count;
    }
    public static void Uncover(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            if (visited[x, y])
            {
                return;
            }

            elements[x, y].loadTexture(adjacentMines(x, y));

            if (adjacentMines(x, y) > 0)
                return;

            visited[x, y] = true;
            Uncover(x - 1, y, visited);
            Uncover(x + 1, y, visited);
            Uncover(x, y - 1, visited);
            Uncover(x, y + 1, visited);
        }
    }
    public static bool IsFinished()
    {
        foreach (Element elem in elements)
            if (elem.isCovered() && !elem.mine)
                return false;

        return true;
    }
}
