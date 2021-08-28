using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class top_hareketi : MonoBehaviour
{
    public Rigidbody2D top;
    public float ziplamaGucu;
    private int star=0;
    public Color sariRenk, turkuazRenk, morRenk, pembeRenk;
    public string mevcutRenk;
    public SpriteRenderer ressam;
    public Transform degistirici, skorStar, kontrol1, kontrol2, cember, kare;
    public TextMeshProUGUI skorYazisi;

    void Start()
    {
        RastgeleRenk();
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            top.velocity = Vector2.up * ziplamaGucu;
            Time.timeScale = 1;
        }
        skorYazisi.text = "Skor: " + star.ToString();
    }

    void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.tag != mevcutRenk && temas.tag != "YeniRenk" && temas.tag != "Star" && temas.tag != "Kontrol1" && temas.tag != "Kontrol2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (temas.tag == "YeniRenk")
        {
            degistirici.position = new Vector3(degistirici.position.x, degistirici.position.y + 4f, degistirici.position.z);
            RastgeleRenk();
        }
        if (temas.tag == "Star")
        {
            skorStar.position = new Vector3(skorStar.position.x, skorStar.position.y + 4f, skorStar.position.z);
            star++;

        }
        if (temas.tag == "Kontrol1")
        {
            kontrol1.position = new Vector3(kontrol1.position.x, kontrol1.position.y + 8f, kontrol1.position.z);
            cember.position = new Vector3(cember.position.x, cember.position.y + 8f, cember.position.z);
        }
        if (temas.tag == "Kontrol2")
        {
            kontrol2.position = new Vector3(kontrol2.position.x, kontrol2.position.y + 8f, kontrol2.position.z);
            kare.position = new Vector3(kare.position.x, kare.position.y + 8f, kare.position.z);
        }
    }

    void RastgeleRenk()
    {
        int rastgele = Random.Range(0, 4);

        switch (rastgele)
        {
            case 0:
                mevcutRenk = "Turkuaz";
                ressam.color = turkuazRenk;
                break;
            case 1:
                mevcutRenk = "Sari";
                ressam.color = sariRenk;
                break;
            case 2:
                mevcutRenk = "Mor";
                ressam.color = morRenk;
                break;
            case 3:
                mevcutRenk = "Pembe";
                ressam.color = pembeRenk;
                break;
        }
    }

}
