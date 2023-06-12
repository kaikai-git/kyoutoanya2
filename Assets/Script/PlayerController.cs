using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject sword;
    Animator animator;
    //
    bool have = false;

    //


    private void Awake()
    {
        animator = sword.GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (have)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // マウスがクリックされたらアニメーションを再生
                animator.SetTrigger("IsAttack");

                Debug.Log("A");
            }
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    // マウスクリックが解除されたらアニメーションを停止
        //    animator.SetTrigger("IsAttack");
           
        //    Debug.Log("B");
        //}
    }

    


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword"))
        {
            Debug.Log("アイテムを取得");
            sword = other.gameObject;
            
            sword.transform.SetParent(transform);
            sword.transform.localPosition = new Vector3(0.01f, 0, 0.01f);

            have = true;
            //持っている状態にする
            //sword.AddComponet<sword>();
        }
        //
      
        //
    }
}
