using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Playfield : MonoBehaviour
{
    //public static Playfield Instance;
  
    public static int w = 10;//col
    public static int h = 20;

    
    public static int scoreno;
   

    public static Transform[,] grid = new Transform[w, h];


    public void Start()
    {
        scoreno = 0;
       
    }
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }
    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
    }

    public static void deleteRow(int y)
    {
        Debug.Log("Delete ");
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] != null)
            {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }
    }

    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
        {
            for (int x = 0; x < w; ++x)
            {
                if (grid[x, i] != null)
                {
                    grid[x, i - 1] = grid[x, i];
                    grid[x, i] = null;

                    grid[x, i - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }
    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }
    public static void deleteFullRows()
    {
        int linesCleared = 0;
        for (int y = 0; y < h; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                
                decreaseRowsAbove(y + 1);
                --y;
                linesCleared++;
            }
        }
        if (linesCleared > 0)
        {
            scoreno += (linesCleared-1) + 100;
            Score.instance.UpdateScoreText();
        }
    }

    public void ClearPlayfield()
    {
        for (int x = 0; x < w; ++x)
        {
            for (int y = 0; y < h; ++y)
            {
                if (grid[x, y] != null)
                {
                    Destroy(grid[x, y].gameObject);
                    grid[x, y] = null;
                }
            }
        }
    }
  
}
