using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ziplama : MonoBehaviour
{

    public float ziplamaGucu;
    private Vector2 karakterHizi;
    private Rigidbody2D fizik;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.relativeVelocity.y <= 0)
        {
            fizik = collision.collider.GetComponent<Rigidbody2D>();

            if (fizik != null)
            {
                karakterHizi = fizik.velocity;
                karakterHizi.y = ziplamaGucu;
                fizik.velocity = karakterHizi;
            }
        }
    }
}
