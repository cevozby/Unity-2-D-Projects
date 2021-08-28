using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blok : MonoBehaviour
{
    //private float blokSagligi = 2;
    //private MeshRenderer ressam;
    public GameObject blokObjesi;
    Vector3 yeniBlok = new Vector3();
    public static int blokSayisi=0;
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Top")
        {
            
            //blokSagligi--;
            if (this.gameObject.tag == "GucluBlok")
            {
                yeniBlok.x = transform.position.x;
                yeniBlok.y = transform.position.y;
                Destroy(this.gameObject);
                Instantiate(blokObjesi, yeniBlok, Quaternion.identity);
            }
            else
            {
                Destroy(this.gameObject);
            }
            blokSayisi++;
            
        }
    }
}
