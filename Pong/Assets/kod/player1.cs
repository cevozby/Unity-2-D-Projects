using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public float hiz; 

    void Start()
    {
        
    }



    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, hiz * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -hiz * Time.deltaTime, 0f);
        }

        float yPozisyon = Mathf.Clamp(transform.position.y, -2.9f, 2.9f);
        transform.position = new Vector2(transform.position.x, yPozisyon);
    }
}
