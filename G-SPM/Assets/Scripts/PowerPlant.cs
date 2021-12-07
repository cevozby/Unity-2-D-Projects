using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant : Construction
{
    public PowerPlant(string name, int x_size, int y_size, int giveEnergy)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.giveEnergy = giveEnergy;
    }
}
