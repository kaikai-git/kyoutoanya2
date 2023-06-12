using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hakai : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject[] HakaiDore;
    public GameObject Obake;

    // �h�A�̌ʂ̉�]�p�x
    Quaternion[] rotations = new Quaternion[]
    {
        Quaternion.Euler(0, 30, 90), // 0�Ԗڂ̃h�A�̉�]�p�x
        Quaternion.Euler(0, 10, 80), // 1�Ԗڂ̃h�A�̉�]�p�x
        Quaternion.Euler(0, 10, 60), // 2�Ԗڂ̃h�A�̉�]�p�x
        // �K�v�ȉ�]�p�x��z��ɒǉ����Ă���
    };


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //�R���C�_�[���ɓ���ƃC�x���g����
    private void OnTriggerEnter(Collider other)
    {
        
        //�h�A���j�󂳂�鉹
        audioSource.Play();
        for (int i = 0; i < HakaiDore.Length; i++)
        {
            if (i < rotations.Length)
            {
                // �h�A�̈ʒu�Ɗp�x��ݒ�
                HakaiDore[i].transform.rotation = rotations[i];
            }
        }

        //�e�L�X�g��\��
        Text textScript = FindObjectOfType<Text>();
        if (textScript != null)
        {
            textScript.changetext("�����牽�������鉹������");
        }

        //Collision�j��
        Destroy(gameObject, 3f);

        //��������j��
        Destroy(Obake);

    }
}
