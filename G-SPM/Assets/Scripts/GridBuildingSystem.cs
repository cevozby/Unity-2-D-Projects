using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem current;

    public GridLayout gridLayout;
    public Tilemap MainTilemap;
    public Tilemap TempTilemap;

    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

    private Building temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;

    public Transform buildingPlace;

    public int giveEnergy, totalEnergy = 0, count = 0, x_size, y_size;
    public bool checkEnergy;
    public bool barrackSelected = false, powerPlantSelected = false;
    public GameObject warningText;

    Construction barrackBuild = new Barrack("barrack", 4, 4, false);
    Construction powerPlantBuild = new PowerPlant("PowerPlant", 2, 3, 2);

    Vector3 soldierLocation;



    #region Unity Methods

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        string tilePath = @"Tiles\";
        tileBases.Add(TileType.Empty, null);
        tileBases.Add(TileType.White, Resources.Load<TileBase>(path: tilePath + "white"));
        tileBases.Add(TileType.Green, Resources.Load<TileBase>(path: tilePath + "green"));
        tileBases.Add(TileType.Red, Resources.Load<TileBase>(path: tilePath + "red"));

        giveEnergy = powerPlantBuild.giveEnergy;
        checkEnergy = barrackBuild.checkEnergy;
    }

    private void Update()
    {
        if (!temp)
        {
            return;
        }

        if (totalEnergy >= 6)
        {
            checkEnergy = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }

            if (!temp.Placed)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 cellPos = gridLayout.LocalToCell(touchPos);

                if (prevPos != cellPos)
                {
                    temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos + new Vector3(0f, 0f, 0f));
                    prevPos = cellPos;
                    FollowBuilding();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (temp.CanBePlaced())
            {
                temp.Place();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearArea();
            Destroy(temp.gameObject);
        }
    }

    #endregion

    #region Tilemap Management

    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
        }
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;
        
        foreach(var v in area.allPositionsWithin){
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }

    #endregion

    #region Building Placement

    public void InitializeBarrack(GameObject barrack)
    {
        if(checkEnergy)
        {
            temp = Instantiate(barrack, Vector3.zero, Quaternion.identity, buildingPlace).GetComponent<Building>();
            barrackSelected = true;
            FollowBuilding();
            totalEnergy -= 6;
            
        }
        else
        {
            StartCoroutine(Warning());
        }
    }

    public void InitializePowerPlant(GameObject powerPlant)
    {
        temp = Instantiate(powerPlant, Vector3.zero, Quaternion.identity, buildingPlace).GetComponent<Building>();
        powerPlantSelected = true;
        FollowBuilding();
        totalEnergy += giveEnergy;
    }

    public void InitializeSoldier(GameObject soldier)
    {
        SoldierPlace();
        temp = Instantiate(soldier, soldierLocation, Quaternion.identity, buildingPlace).GetComponent<Building>();
        if (temp.CanBePlaced())
        {
            temp.Place();
        }
        else
        {
            SoldierNewPlace();
            temp = Instantiate(soldier, soldierLocation, Quaternion.identity, buildingPlace).GetComponent<Building>();
            if (temp.CanBePlaced())
            {
                temp.Place();
            }
        }
    }

    private void ClearArea()
    {
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        TempTilemap.SetTilesBlock(prevArea, toClear);
    }

    public void FollowBuilding()
    {
        ClearArea();
        PositionControl();

        temp.area.position = gridLayout.WorldToCell(new Vector3(temp.gameObject.transform.position.x - x_size, temp.gameObject.transform.position.y - y_size, temp.gameObject.transform.position.z));
        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, MainTilemap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for(int i = 0; i<baseArray.Length; i++)
        {
            if(baseArray[i] == tileBases[TileType.White])
            {
                tileArray[i] = tileBases[TileType.Green];
            }
            else
            {
                FillTiles(tileArray, TileType.Red);
                break;
            }
        }

        TempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    }

    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);
        foreach(var b in baseArray)
        {
            if (b!= tileBases[TileType.White])
            {
                StartCoroutine(PlaceWarning());

                return false;
            }
        }
        return true;
    }

    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, TileType.Empty, TempTilemap);
        SetTilesBlock(area, TileType.Empty, MainTilemap);
    }

    #endregion

    IEnumerator Warning()
    {
        warningText.SetActive(true);
        warningText.GetComponent<Text>().text = "NEED " + (6 - totalEnergy) + " ENERGY";
        yield return new WaitForSeconds(1);
        warningText.SetActive(false);
    }

    IEnumerator PlaceWarning()
    {
        warningText.SetActive(true);
        warningText.GetComponent<Text>().text = "CANNOT PLACE THÝS AREA";
        yield return new WaitForSeconds(1);
        warningText.SetActive(false);
    }

    void SoldierPlace()
    {
        if (MouseManager.current.barrackControl)
        {
            soldierLocation = new Vector3(MouseManager.current.selectedObject.transform.position.x - 3, MouseManager.current.selectedObject.transform.position.y - 3, 0);
        }
    }
    void SoldierNewPlace()
    {
        count++;
        if (count % 3 != 0)
        {
            soldierLocation = new Vector3(soldierLocation.x + 1, soldierLocation.y, soldierLocation.z);
        }
        else
        {
            soldierLocation = new Vector3(soldierLocation.x - 3, soldierLocation.y + 1, soldierLocation.z);
        }
    }
    public void PositionControl()
    {
        if ((temp.gameObject.transform.position.x / 2) > 1)
        {
            x_size = 1;
        }
        else
        {
            x_size = 0;
        }
        if ((temp.gameObject.transform.position.y / 2) > 1)
        {
            y_size = 1;
        }
        else
        {
            y_size = 0;
        }

    }
}

public enum TileType
{
    Empty,
    White,
    Green,
    Red
}