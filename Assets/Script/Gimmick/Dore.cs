using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dore : MonoBehaviour
{
    // ドアのアニメーター
    [SerializeField]
    [Tooltip("自動ドアのアニメーター")]
    private Animator[] opendoreAnims;
    [SerializeField] GameObject SousaPanel;
    AudioSource audioSource;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// 自動ドア検知エリアに入った時
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
       
        SousaPanel.SetActive(false);
        // アニメーションパラメータをtrueにする。(ドアが開く)
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
