using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    public int x = 15;
    public int y = 15;

    void Start()
    {
        Invoke("Spawn", 5f);
    }

    public void Spawn()
    {
        for (int y = 0; y < this.y; y++)
        {
            for (int x = 0; x < this.x; x++)
            {
                if (GetTileFromAddress(x, y).tag == "Grass")
                {
                    GetTileFromAddress(x, y).PlaceTrash();
                }
            }
        }

        Invoke("Spawn", 5f);
    }

    public Tile GetTileFromAddress(int x, int y)
    {
        string name = "X" + x + ".Y" + y;
        return GameObject.Find(name).GetComponent<Tile>();
    }
}
