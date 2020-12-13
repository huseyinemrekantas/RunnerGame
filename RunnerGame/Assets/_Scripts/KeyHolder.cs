using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public GameObject RedObject;
    public GameObject GreenObject;
    public GameObject BlueObject;

    public static GameObject Red;
    public static GameObject Green;
    public static GameObject Blue;

    public GameObject character;
    Vector3 distance;

    static int KeyNumber; // 1. Red 2. Green 3. Blue


    void Start()
    {
        Red = RedObject;
        Green = GreenObject;
        Blue = BlueObject;
        distance = transform.position - character.transform.position;
        KeySpecifier();
    }

    // Update is called once per frame
    void Update()
    {
        Red = RedObject;
        Green = GreenObject;
        Blue = BlueObject;
        transform.position = character.transform.position + distance;
    }
    public static void KeySpecifier()
    {
        //Debug.Log("Anahtar Seçici Method Çalıştı...");
        Red.SetActive(false);
        Blue.SetActive(false);
        Green.SetActive(false);

        KeyNumber = Random.Range(1, 4);

        if (KeyNumber==1)
        {
            Red.SetActive(true);     
        }
        if (KeyNumber==2)
        {
           Green.SetActive(true);
        }
        if (KeyNumber==3)
        {
            Blue.SetActive(true);
        }
    }
}
