using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dore : MonoBehaviour
{
    // ドアのアニメーター
    [SerializeField]
    [Tooltip("自動ドアのアニメーター")]
    private Animator[] opendoreAnims;

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
        // アニメーションパラメータをtrueにする。(ドアが開く)
        foreach (Animator opendoreAnim in opendoreAnims)
        {
            
            opendoreAnim.SetTrigger("open");
            Destroy(gameObject,3f);
        }
    }
}
