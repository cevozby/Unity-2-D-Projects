using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction 
{
    protected string name;
    protected int needEnergy, x_size, y_size;
    protected bool energyControl;
    public Construction()
    {
        this.name = null;
        this.needEnergy = 0;
        this.x_size = 0;
        this.y_size = 0;
    }

    public Construction(string name, int x_size, int y_size)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.needEnergy = 0;
    }

    public Construction(string name, int x_size, int y_size, int needEnergy)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.needEnergy = needEnergy;
    }

    public Construction(string name, int x_size, int y_size, bool energyControl)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.needEnergy = 0;
        this.energyControl = energyControl;
    }
}
