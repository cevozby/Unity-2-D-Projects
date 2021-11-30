using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrack : MonoBehaviour
{
    
    GameObject informationMenu;

    /*public Barrack(string name, int x_size, int y_size, int needEnergy)
    {
        this.name = name;
        this.x_size = x_size;
        this.y_size = y_size;
        this.needEnergy = needEnergy;
    }*/


    private void Start()
    {
        
    }

    void Update()
    {
        if(MouseManager.current.barrackPanel)
        {
            GameObject.Find("InformationText").GetComponent<Text>().text = "Barrack";
        }
        
    }
}
