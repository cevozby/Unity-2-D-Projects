using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class top_hareketleri : MonoBehaviour
{

    public Rigidbody2D top;
    public float xHizi, yHizi;
    public TextMeshProUGUI player1Yazi, player2Yazi, kazanan;
    private int player1Skor, player2Skor;
    public int maxSkor;
    public GameObject BitisPaneli;
    public AudioSource alkis, skor;
    private float xMinus, xPlus;

    void Start()
    {
        /*xMinus = Random.Range(-6f, -5f);
        xPlus = Random.Range(5f, 6f);*/

        //float yatayHiz = xHizi * Time.deltaTime;
        int baslangic = Random.Range(0, 2);
        if (baslangic == 0)
        {
            top.velocity = new Vector2(xHizi, Random.Range(-5f, 5f));
        }
        else if (baslangic == 1)
        {
            top.velocity = new Vector2(-xHizi, Random.Range(-5f, 5f));
        }
        
    }




    void Update()
    {
        player1Yazi.text = player1Skor.ToString();
        player2Yazi.text = player2Skor.ToString();
        if (player1Skor == maxSkor)
        {
            BitisPaneli.SetActive(true);
            kazanan.text = "Player 1 Win\nTekrar baþlamak için enter tuþuna basýnýz";
            Time.timeScale = 0;
        }
        else if (player2Skor == maxSkor)
        {
            BitisPaneli.SetActive(true);
            kazanan.text = "Player 2 Win\nTekrar baþlamak için enter tuþuna basýnýz";
            Time.timeScale = 0;
        }

        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D temas)
    {
        if(temas.gameObject.tag == "Player1")
        {
            top.velocity = new Vector2(-xHizi, top.velocity.y);
        }
        else if (temas.gameObject.tag == "Player2")
        {
            top.velocity = new Vector2(xHizi, top.velocity.y);
        }

        if (temas.gameObject.tag == "UstDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -yHizi);
        }
        else if (temas.gameObject.tag == "AltDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, yHizi);
        }

        if (temas.gameObject.tag == "SolDuvar")
        {
            player1Skor++;
            skor.Play();
            transform.position = new Vector2(0f, 0f);
            top.velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }
        else if (temas.gameObject.tag == "SagDuvar")
        {
            player2Skor++;
            skor.Play();
            transform.position = new Vector2(0f, 0f);
            top.velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }
        if (player1Skor == maxSkor || player2Skor == maxSkor)
        {
            alkis.Play();
        }

        
    }

}
