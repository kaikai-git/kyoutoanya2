using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject box0;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

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
            Text textScript = FindObjectOfType<Text>();
            if (textScript != null)
            {
                textScript.changetext("�ǂ����̏��O���O�����Ƃ��ł��邩������Ȃ�");
            }
            audioSource.Play();
            box0.SetActive(true);
            Debug.Log(type + "????");
        }
        if (type == Item.Type.Ohuda)
        {
            Hakai.flag1 = false;
            Debug.Log(Hakai.flag1);
            Text textScript = FindObjectOfType<Text>();
            if (textScript != null)
            {
                textScript.changetext("�����C�z����菜���Ă��ꂻ����");
            }
            audioSource.Play();
            box1.SetActive(true);
            Debug.Log(type + "????");
            
            
        }
        if (type == Item.Type.Boueikun)
        {
            Text textScript = FindObjectOfType<Text>();
            if (textScript != null)
            {
                textScript.changetext("�ǂ����Ō������Ƃ̂���L�����N�^�[�̃X�g���b�v��");
            }
            audioSource.Play();
            box2.SetActive(true);
            Debug.Log(type + "????");
        }
        if (type == Item.Type.Sho)
        {
            Text textScript = FindObjectOfType<Text>();
            if (textScript != null)
            {
                textScript.changetext("���̏�̏Z�l���낤���H");
            }
            audioSource.Play();
            box3.SetActive(true);
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
        if (type == Item.Type.Sho)
        {

            return box3.activeSelf;

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
