using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject box0;

   

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
            Debug.Log(type + "取得");
        }
    }


    public bool CanUseItem(Item.Type type)
    {
        //アイテムを使える角y化は表示されているか同課が分かればいい
        //表示されているかどうかは、activeselfを使えばいい
        if (type == Item.Type.Key)
        {
            
            return box0.activeSelf;
            
        }
       
        return false;
    }

    public void UseItem(Item.Type type)
    {
        if (type == Item.Type.Key)
        {
            Debug.Log(type + "を使った");
            box0.SetActive(false);
        }
        
    }
}
