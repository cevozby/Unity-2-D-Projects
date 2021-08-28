using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{

    public float donusHizi;


    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0f, 0f, donusHizi);
    }
}
