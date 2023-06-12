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

       

        // éwíËÇ≥ÇÍÇΩïbêîå„Ç… Kagi.SetActive(true) Çé¿çs
        float delay = 0.7f; // íxâÑÇ∑ÇÈïbêî
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
