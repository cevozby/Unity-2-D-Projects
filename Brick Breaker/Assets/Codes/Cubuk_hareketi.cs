using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubuk_hareketi : MonoBehaviour
{
    public float hiz;
    void Start()
    {
        
    }


    void Update()
    {
        float hareketHizi = hiz * Input.GetAxis("Horizontal");
        transform.Translate(hareketHizi * Time.deltaTime, 0f, 0f);

        float xPozisyon = Mathf.Clamp(transform.position.x, -7.87f, 7.87f);
        transform.position = new Vector2(xPozisyon, transform.position.y);
    }
}
