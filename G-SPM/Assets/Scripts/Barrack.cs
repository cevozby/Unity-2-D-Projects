using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrack : Construction
{
    public Barrack(string name, int x_size, int y_size, bool checkEnergy)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.checkEnergy = checkEnergy;
    }
}
