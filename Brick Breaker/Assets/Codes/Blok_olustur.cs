using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blok_olustur : MonoBehaviour
{
    public GameObject blokObjesi, gucluBlokObjesi;
    //private static blokObjesi;
    public static int olusanBlokSayisi=0;
    
    void Start()
    {

        Vector3 blokPozisyonu = new Vector3();
        for (int i = -8; i <= 8; i++)
        {
            for (float j = 1; j <= 4; j = j + 0.5f)
            {
                blokPozisyonu.x = i;
                blokPozisyonu.y = j;
                if(i%3==0 && (j==1 || j == 3))
                {
                    Instantiate(gucluBlokObjesi, blokPozisyonu, Quaternion.identity);
                }
                else
                {
                    Instantiate(blokObjesi, blokPozisyonu, Quaternion.identity);
                }
                olusanBlokSayisi++;
            }
        }
    }

    void Update()
    {
        
    }
}
