using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    public void YenidenBaşla()
    {
        SceneManager.LoadScene(0);
    }
}
