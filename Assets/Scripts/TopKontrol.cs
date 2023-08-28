using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    private Rigidbody rb;
    public float Hýz = 1.8f;

    public Text zaman, can, durum;

    float zamanSayacý = 500;
    float canSayacý = 20;

    bool oyunDevam = true;
    bool oyunTamam = false;

    public GameObject panel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayacý -= Time.deltaTime;
            zaman.text = (int)zamanSayacý + ""; // küsüratlarý görmemek için
        }
        else if(!oyunTamam)
        {
            panel.SetActive(true);
            durum.text = "Oyun tamamlanamadý";
        }

        if(zamanSayacý < 0)
        {
            oyunDevam = false;
        }
    }

    private void FixedUpdate()
    {
        if(oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");

            Vector3 kuvvet = new Vector3(-yatay, 0, -dikey);

            rb.AddForce(kuvvet * Hýz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        string objeÝsmi = other.gameObject.name;

        if (objeÝsmi.Equals("Bitiþ"))
        {
            oyunTamam = true;
            durum.text = "Oyunu tamamladýnýz. Tebrikler!";
            panel.SetActive(true);
            // print("Oyunu Kazandýnýz");
        }
        else if (!objeÝsmi.Equals("Zemin") && !objeÝsmi.Equals("LabirentZemin") && !objeÝsmi.Equals("Baþlangýç"))
        {
            canSayacý -= 1;
            can.text = canSayacý + "";

            if(canSayacý == 0)
            {
                oyunDevam = false;
            }
        }       
    }
}
