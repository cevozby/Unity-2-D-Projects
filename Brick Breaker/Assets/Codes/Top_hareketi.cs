using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Top_hareketi : MonoBehaviour
{
    public float xHizi, yHizi;
    public Rigidbody2D top;
    public GameObject bitisPaneli;
    public TextMeshProUGUI bitis, durum;

    void Start()
    {
        float xBaslangicHizi = Random.Range(-10f, 10f);
        //float yBaslangicHizi = Random.Range(5f, 8f);
        top.velocity = new Vector2(xBaslangicHizi, yHizi);

    }

    void Update()
    {
        /*float xPozisyon = Mathf.Clamp(transform.position.x, -7.87f, 7.87f);
        float yPozisyon = Mathf.Clamp(transform.position.y, -5.1f, 4.85f);
        transform.position = new Vector2(xPozisyon, yPozisyon);*/
        if(Blok.blokSayisi == Blok_olustur.olusanBlokSayisi)
        {
            Time.timeScale = 0;
            bitisPaneli.SetActive(true);
            durum.text = "Kazandýnýz";
            bitis.text = "Kýrýlan Blok Sayýsý: " + Blok.blokSayisi.ToString() + "\nTekrar oynamak için bir tuþa basýnýz";
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
        else if(Blok.blokSayisi!=Blok_olustur.olusanBlokSayisi && Time.timeScale == 0)
        {
            bitisPaneli.SetActive(true);
            durum.text = "Kaybettiniz";
            bitis.text = "Kýrýlan Blok Sayýsý: " + Blok.blokSayisi.ToString() + "\nTekrar oynamak için bir tuþa basýnýz";
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BitisCubugu")
        {
            Time.timeScale = 0;
        }
        else if (collision.gameObject.tag == "Tavan")
        {
            top.velocity = new Vector2(top.velocity.x, -yHizi);
        }
        else if (collision.gameObject.tag == "SolDuvar")
        {
            top.velocity = new Vector2(xHizi, top.velocity.y);
        }
        else if(collision.gameObject.tag == "SagDuvar")
        {
            top.velocity = new Vector2(-xHizi, top.velocity.y);
        }
        else if (collision.gameObject.tag == "Player")
        {
            top.velocity = new Vector2(top.velocity.x, yHizi);
        }
    }
}
