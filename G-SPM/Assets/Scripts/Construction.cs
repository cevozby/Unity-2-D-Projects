using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction 
{
    public static Construction current;

    public string name;
    public int giveEnergy, x_size, y_size, totalEnergy;
    public bool checkEnergy;

    private void Awake()
    {
        current = this;
    }

    public Construction()
    {
        this.name = null;
        this.giveEnergy = 0;
        this.x_size = 0;
        this.y_size = 0;
    }

    public Construction(string name, int x_size, int y_size)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.giveEnergy = 0;
    }

    public Construction(string name, int x_size, int y_size, int giveEnergy)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.giveEnergy = giveEnergy;
    }

    public Construction(string name, int x_size, int y_size, bool checkEnergy)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.giveEnergy = 0;
        this.checkEnergy = checkEnergy;
    }

}
