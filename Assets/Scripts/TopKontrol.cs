using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    private Rigidbody rb;
    public float H�z = 1.8f;

    public Text zaman, can, durum;

    float zamanSayac� = 500;
    float canSayac� = 20;

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
            zamanSayac� -= Time.deltaTime;
            zaman.text = (int)zamanSayac� + ""; // k�s�ratlar� g�rmemek i�in
        }
        else if(!oyunTamam)
        {
            panel.SetActive(true);
            durum.text = "Oyun tamamlanamad�";
        }

        if(zamanSayac� < 0)
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

            rb.AddForce(kuvvet * H�z);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        string obje�smi = other.gameObject.name;

        if (obje�smi.Equals("Biti�"))
        {
            oyunTamam = true;
            durum.text = "Oyunu tamamlad�n�z. Tebrikler!";
            panel.SetActive(true);
            // print("Oyunu Kazand�n�z");
        }
        else if (!obje�smi.Equals("Zemin") && !obje�smi.Equals("LabirentZemin") && !obje�smi.Equals("Ba�lang��"))
        {
            canSayac� -= 1;
            can.text = canSayac� + "";

            if(canSayac� == 0)
            {
                oyunDevam = false;
            }
        }       
    }
}
