using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Generator generator = (Generator)target;

        if (GUILayout.Button("Generate/Regenerate"))
        {
            generator.CreateRows();
        }

        if (GUILayout.Button("Add Structures"))
        {
            generator.CreateStructures();
        }

        if (GUILayout.Button("Delete"))
        {
            generator.Delete();
        }
    }
}

public class Generator : MonoBehaviour
{
    [Header("Tiles Setup")]
    public List<Tile> allKindsOfTiles = new List<Tile>();

    public int x;
    public int y;
    public float tileWidthness;
    public float tileScale;

    [Space]
    public bool is3D = true;

    [Header("Structure Setup")]
    public float structureYOffset;
    public int structureEmptyTileRate;

    private List<GameObject> rows = new List<GameObject>();

    GameObject root;

    public void CreateRows()
    {
        rows.Clear();

        if(root != null)
        {
            DestroyImmediate(root);
        }

        root = new GameObject();
        root.transform.localPosition = Vector3.zero;
        root.transform.SetParent(transform);
        root.name = "root";

        for (int y = 0; y < this.y; y++)
        {
            GameObject row = new GameObject();
            row.transform.SetParent(root.transform);
            if (is3D)
            {
                row.transform.position = new Vector3(0, 0, y * -tileWidthness);
            }
            else
            {
                row.transform.position = new Vector3(0, y * -tileWidthness, 0);
            }
            row.name = "Row " + y.ToString();
            rows.Add(row);
        }

        CreateTiles();
    }

    public void CreateTiles()
    {
        for (int y = 0; y < this.y; y++)
        {
            for (int x = 0; x < this.x; x++)
            {
                if (x == 0 && y == 0)
                {
                    GameObject tileOBJ = Instantiate(allKindsOfTiles[Random.Range(0, allKindsOfTiles.Count)].gameObject);
                    Tile tile = tileOBJ.GetComponent<Tile>();
                    tile._X = null;
                    tile._Y = null;
                    tile.generator = this;
                    tileOBJ.transform.SetParent(rows[y].transform);
                    tileOBJ.transform.localPosition = new Vector3(x * tileWidthness, 0, 0);
                    tileOBJ.transform.localScale = new Vector3(tileScale, tileScale, tileScale);
                    tileOBJ.name = "X" + x + ".Y" + y;
                }
                else if (x != 0 && y == 0)
                {
                    Tile negX = GetTileFromAddress(x - 1, y);

                    GameObject tileOBJ = Instantiate(hEquals(negX)[Random.Range(0, hEquals(negX).Count)].gameObject);
                    Tile tile = tileOBJ.GetComponent<Tile>();
                    tile._X = negX;
                    tile._Y = null;
                    tile.generator = this;
                    tileOBJ.transform.SetParent(rows[y].transform);
                    tileOBJ.transform.localPosition = new Vector3(x * tileWidthness, 0, 0);
                    tileOBJ.transform.localScale = new Vector3(tileScale, tileScale, tileScale);
                    tileOBJ.name = "X" + x + ".Y" + y;
                }
                else if (x == 0 && y != 0)
                {
                    Tile negY = GetTileFromAddress(x, y - 1);

                    GameObject tileOBJ = Instantiate(vEquals(negY)[Random.Range(0, vEquals(negY).Count)].gameObject);
                    Tile tile = tileOBJ.GetComponent<Tile>();
                    tile._X = null;
                    tile._Y = negY;
                    tile.generator = this;
                    tileOBJ.transform.SetParent(rows[y].transform);
                    tileOBJ.transform.localPosition = new Vector3(x * tileWidthness, 0, 0);
                    tileOBJ.transform.localScale = new Vector3(tileScale, tileScale, tileScale);
                    tileOBJ.name = "X" + x + ".Y" + y;
                }
                else if (x != 0 && y != 0)
                {
                    Tile negX = GetTileFromAddress(x - 1, y);
                    Tile negY = GetTileFromAddress(x, y - 1);

                    GameObject tileOBJ = Instantiate(bothEquals(negX, negY)[Random.Range(0, bothEquals(negX, negY).Count)].gameObject);
                    Tile tile = tileOBJ.GetComponent<Tile>();
                    tile._X = negX;
                    tile._Y = negY;
                    tile.generator = this;
                    tileOBJ.transform.SetParent(rows[y].transform);
                    tileOBJ.transform.localPosition = new Vector3(x * tileWidthness, 0, 0);
                    tileOBJ.transform.localScale = new Vector3(tileScale, tileScale, tileScale);
                    tileOBJ.name = "X" + x + ".Y" + y;
                }
            }
        }
    }

    public void CreateStructures()
    {
        for (int y = 0; y < this.y; y++)
        {
            for (int x = 0; x < this.x; x++)
            {
                GetTileFromAddress(x, y).AddStructures();
            }
        }
    }

    public void Delete()
    {
        if (root != null)
        {
            DestroyImmediate(root);
        }
    }

    public List<Tile> hEquals(Tile tile)
    {
        List<Tile> equals = new List<Tile>();
        equals.AddRange(allKindsOfTiles);

        for (int i = 0; i < allKindsOfTiles.Count; i++)
        {
            if (allKindsOfTiles[i].negX != tile.posX)
            {
                equals.Remove(allKindsOfTiles[i]);
            }
        }

        return equals;
    }

    public List<Tile> vEquals(Tile tile)
    {
        List<Tile> equals = new List<Tile>();
        equals.AddRange(allKindsOfTiles);

        for (int i = 0; i < allKindsOfTiles.Count; i++)
        {
            if (allKindsOfTiles[i].posZ != tile.negZ)
            {
                equals.Remove(allKindsOfTiles[i]);
            }
        }

        return equals;
    }

    public List<Tile> bothEquals(Tile tileX, Tile tileY)
    {
        List<Tile> equals = new List<Tile>();
        equals.AddRange(allKindsOfTiles);

        for (int i = 0; i < allKindsOfTiles.Count; i++)
        {
            if (allKindsOfTiles[i].negX != tileX.posX)
            {
                equals.Remove(allKindsOfTiles[i]);
            }
            if (allKindsOfTiles[i].posZ != tileY.negZ)
            {
                equals.Remove(allKindsOfTiles[i]);
            }
            if (allKindsOfTiles[i].negX != tileX.posX && allKindsOfTiles[i].posZ != tileY.negZ)
            {
                equals.Remove(allKindsOfTiles[i]);
            }
        }

        return equals;
    }

    public Tile GetTileFromAddress(int x, int y)
    {
        string name = "X" + x + ".Y" + y;
        return GameObject.Find(name).GetComponent<Tile>();
    }
}