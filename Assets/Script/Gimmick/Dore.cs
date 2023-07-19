using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dore : MonoBehaviour
{
    // �h�A�̃A�j���[�^�[
    [SerializeField]
    [Tooltip("�����h�A�̃A�j���[�^�[")]
    private Animator[] opendoreAnims;
    [SerializeField] GameObject SousaPanel;
    AudioSource audioSource;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// �����h�A���m�G���A�ɓ�������
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
       
        SousaPanel.SetActive(false);
        // �A�j���[�V�����p�����[�^��true�ɂ���B(�h�A���J��)
        foreach (Animator opendoreAnim in opendoreAnims)
        {
            
            opendoreAnim.SetTrigger("open");
            Destroy(gameObject,3f);
        }
    }
     
    void Update()
    {
        if (FPSController.UIoff == false)
        {
            SousaPanel.SetActive(false);
        }
    }
       


  
}
