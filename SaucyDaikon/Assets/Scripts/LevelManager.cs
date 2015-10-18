using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public GameObject tilePrefab;

    private enum Tile : int {
        Null=-1,
        Empty=0
    }

    private List<List<Tile>> map = new List<List<Tile>>();
    private int mapSize = 8;

    private const float tileDepth = 100;

	// Use this for initialization
    void Start()
    {
        for (int r = 0; r < mapSize; r++)
        {
            List<Tile> row = new List<Tile>();
            for (int c = 0; c < mapSize; c++)
            {
                row.Add(Tile.Empty);
            }
            map.Add(row);
        }
        map[0][0] = Tile.Null;
        map[mapSize - 1][0] = Tile.Null;
        map[0][mapSize - 1] = Tile.Null;
        map[mapSize - 1][mapSize - 1] = Tile.Null;

        SpawnTiles();
    }
	
	// Update is called once per frame
    void Update()
    {
    }

    void OnDrawGizmos()
    {
    }

    private void SpawnTiles()
    {
        for (int r = 0; r < mapSize; r++)
        {
            for (int c = 0; c < mapSize; c++)
            {
                Tile t = map[r][c];
                Vector3 pos = new Vector3(c, r * 0.5f, tileDepth);
                switch (t)
                {
                    case Tile.Null:
                        break;
                    case Tile.Empty:
                        Instantiate(tilePrefab, pos, Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
