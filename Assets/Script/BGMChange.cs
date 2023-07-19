using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChange : MonoBehaviour
{
    public GameObject wall;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        wall.SetActive(true);
        audioSource.volume = 0.5f;
        Debug.Log("Down");
    }
}
