using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap roadMap;
    //public TileBase roadTile;
    public Vector3Int[,] spots;
    Astar astar;
    List<Spot> roadPath = new List<Spot>();
    new Camera camera;
    BoundsInt bounds;

    public GameObject soldierSelect;

    void Start()
    {
        tilemap.CompressBounds();
        roadMap.CompressBounds();
        bounds = tilemap.cellBounds;
        camera = Camera.main;


        CreateGrid();
        astar = new Astar(spots, bounds.size.x, bounds.size.y);
    }
    public void CreateGrid()
    {
        spots = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++)
            {
                if (tilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    spots[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    spots[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
    }
    /*private void DrawRoad()
    {
        for (int i = 0; i < roadPath.Count; i++)
        {
            roadMap.SetTile(new Vector3Int(roadPath[i].X, roadPath[i].Y, 0), roadTile);
        }
    }*/
    // Update is called once per frame
    public Vector2Int start;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 world = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = tilemap.WorldToCell(world);
            start = new Vector2Int(gridPos.x, gridPos.y);

            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                Debug.Log("Target Object is true");
                soldierSelect = targetObject.transform.gameObject;
            }
        }
        if (Input.GetMouseButton(1))
        {
            CreateGrid();

            Vector3 world = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = tilemap.WorldToCell(world);

            if (roadPath != null && roadPath.Count > 0)
                roadPath.Clear();

            roadPath = astar.CreatePath(spots, start, new Vector2Int(gridPos.x, gridPos.y), 1000);
            if (roadPath == null)
                return;

            StartCoroutine(SoldierMovement());
            start = new Vector2Int(roadPath[0].X, roadPath[0].Y);

            GridBuildingSystem.current.FollowBuilding();
        }
    }

    IEnumerator SoldierMovement()
    {
        for (int i = 0; i < roadPath.Count; i++)
        {
            soldierSelect.transform.position = new Vector3Int(roadPath[i].X, roadPath[i].Y, 0);
            Debug.Log("Road: " + roadPath.Count);
            Debug.Log("X: " + roadPath[i].X);
            Debug.Log("Y: " + roadPath[i].Y);
            //roadMap.SetTile(new Vector3Int(roadPath[i].X, roadPath[i].Y, 0), roadTile);
            
        }
        yield return new WaitForSeconds(1f);
    }
}
