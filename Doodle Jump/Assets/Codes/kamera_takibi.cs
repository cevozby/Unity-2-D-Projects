using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_takibi : MonoBehaviour
{

    public Transform hedef;
    void Start()
    {
        
    }

    void Update()
    {
        if(hedef.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, hedef.position.y, transform.position.z);
        }
    }
}
