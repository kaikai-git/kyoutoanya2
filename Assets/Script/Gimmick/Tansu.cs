using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tansu : MonoBehaviour
{
    private Animator opentansu;

   
    public GameObject Kagi;

    

    // Start is called before the first frame update
    void Start()
    {
        opentansu = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        
        Debug.Log("Click");

        opentansu.SetTrigger("Open");

       

        // �w�肳�ꂽ�b����� Kagi.SetActive(true) �����s
        float delay = 0.7f; // �x������b��
        Invoke("ActivateKagi", delay);
    }

    public void ActivateKagi()
    {
        if(Kagi != null)
        {
            Kagi.SetActive(true);
        }
        
    }   
}
