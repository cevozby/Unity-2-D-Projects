using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class karakter_hareketi : MonoBehaviour
{

    public float x_karakter_hizi;
    void Start()
    {
        
    }

    void Update()
    {
        float hiz = x_karakter_hizi * Input.GetAxis("Horizontal");
        transform.Translate(hiz * Time.deltaTime, 0f, 0f);

        float xPozisyon = Mathf.Clamp(transform.position.x, -10.47f, 10.47f);
        transform.position = new Vector2(xPozisyon, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bitirici")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
