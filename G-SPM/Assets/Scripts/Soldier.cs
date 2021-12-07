using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier
{
    public int attack, defans, range, speed;
    public string name, unit;

    public Soldier()
    {
        this.name = null;
        this.unit = null;
        this.attack = 0;
        this.defans = 0;
        this.range = 0;
        this.speed = 0;
    }

    public Soldier(string name, string unit, int attack, int defans, int range, int speed)
    {
        this.name = name;
        this.unit = unit;
        this.attack = attack;
        this.defans = defans;
        this.range = range;
        this.speed = speed;
    }



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
