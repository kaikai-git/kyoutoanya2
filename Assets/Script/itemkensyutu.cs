using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemkensyutu : MonoBehaviour
{
   void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,10.0f))
            {
                GameObject clickedObject = hit.collider.gameObject;
                
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                {
                    Debug.Log("アイテムをクリックした");
                }
            }

           
        }
    }
   
        
}
