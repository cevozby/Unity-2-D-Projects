using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public static Building current;
    public bool Placed { get; private set; }
    public BoundsInt area;

    int x_size, y_size;


    private void Awake()
    {
        current = this;
    }


    #region Build Methods

    public bool CanBePlaced()
    {
        PositionControl();
        x_size = GridBuildingSystem.current.x_size;
        y_size = GridBuildingSystem.current.y_size;
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(new Vector3(transform.position.x - x_size, transform.position.y - y_size, transform.position.z));
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridBuildingSystem.current.CanTakeArea(areaTemp))
        {
            return true;
        }
        return false;
    }

    public void Place()
    {
        PositionControl();
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(new Vector3(transform.position.x - x_size, transform.position.y - y_size, transform.position.z));
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        GridBuildingSystem.current.TakeArea(areaTemp);
    }

    #endregion
    public void PositionControl()
    {
        if ((transform.position.x / 2) > 1)
        {
            x_size = 1;
        }
        else
        {
            x_size = 0;
        }
        if ((transform.position.y / 2) > 1)
        {
            y_size = 1;
        }
        else
        {
            y_size = 0;
        }
        
    }
}
