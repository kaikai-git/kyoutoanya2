using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject box0;
    public GameObject box1;
    public GameObject box2;


    public static ItemBox instance;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Awake()
    {
        instance = this;
    }
   
    public void SetItem(Item.Type type)
    {
        if(type == Item.Type.Key)
        {
            audioSource.Play();
            box0.SetActive(true);
            Debug.Log(type + "????");
        }
        if (type == Item.Type.Ohuda)
        {
            audioSource.Play();
            box1.SetActive(true);
            Debug.Log(type + "????");
        }
        if (type == Item.Type.Boueikun)
        {
            audioSource.Play();
            box2.SetActive(true);
            Debug.Log(type + "????");
        }
    }


    public bool CanUseItem(Item.Type type)
    {
        //?A?C?e?????g?????py?????\????????????????????????????????
        //?\???????????????????????Aactiveself???g????????
        if (type == Item.Type.Key)
        {
            
            return box0.activeSelf;
            
        }
        if (type == Item.Type.Ohuda)
        {

            return box1.activeSelf;

        }
        if (type == Item.Type.Boueikun)
        {

            return box2.activeSelf;

        }
        return false;
    }

    public void UseItem(Item.Type type)
    {
        if (type == Item.Type.Key)
        {
            Debug.Log(type + "???g????");
            box0.SetActive(false);
        }

        if (type == Item.Type.Ohuda)
        {
            Debug.Log(type + "???g????");
            box1.SetActive(false);
        }

    }
}
