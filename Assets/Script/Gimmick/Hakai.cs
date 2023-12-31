using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hakai : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject[] HakaiDore;
    public GameObject Obake;

    public GameObject[] DoreClose;
    public GameObject[] OhudaDore;
    public GameObject wall;
    public static bool flag1 = false;
    // ?h?A???????????]?p?x
    Quaternion[] rotations = new Quaternion[]
    {
        Quaternion.Euler(0, 30, 90), // 0???????h?A?????]?p?x
        Quaternion.Euler(0, 10, 80), // 1???????h?A?????]?p?x
        Quaternion.Euler(0, 10, 60), // 2???????h?A?????]?p?x
        // ?K?v?????]?p?x???z????????????????
    };


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //?R???C?_?[???????????C?x???g????
    private void OnTriggerEnter(Collider other)
    {
        wall.SetActive(true);
        foreach (GameObject dore in DoreClose)
        {
            dore.SetActive(false);
        }

        foreach (GameObject dore in OhudaDore)
        {
            dore.SetActive(true);
        }


        //?h?A???j??????????
        audioSource.Play();
        for (int i = 0; i < HakaiDore.Length; i++)
        {
            if (i < rotations.Length)
            {
                // ?h?A?????u???p?x??????
                HakaiDore[i].transform.rotation = rotations[i];
            }
        }

        //?e?L?X?g???\??
        Text textScript = FindObjectOfType<Text>();
        if (textScript != null)
        {
            textScript.changetext("下からなにか物音がした");
        }
        flag1 = true;
        //Collision?j??
        Destroy(gameObject, 3f);

        //?????????j??
        Destroy(Obake);

    }
}
