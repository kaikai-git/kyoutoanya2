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
            Debug.Log(type + "�擾");
        }
    }


    public bool CanUseItem(Item.Type type)
    {
        //�A�C�e�����g����py���͕\������Ă��邩���ۂ�������΂���
        //�\������Ă��邩�ǂ����́Aactiveself���g���΂���
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
            Debug.Log(type + "���g����");
            box0.SetActive(false);
        }
        
    }
}
