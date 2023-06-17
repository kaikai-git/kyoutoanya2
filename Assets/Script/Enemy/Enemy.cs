using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public GameObject TargetObject;
    public RectTransform SpecialPerform;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    private bool peformtime = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        // NavMesh
        if (navMeshAgent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            // NavMeshAgent�ɖړI�n���Z�b�g
            navMeshAgent.SetDestination(TargetObject.transform.position);
        }

        if(peformtime)
        {
            Vector3 currentPosition = SpecialPerform.anchoredPosition3D;
            Debug.Log("2");
            if (currentPosition.x < -1)
            {
                Vector3 newPosition = currentPosition + new Vector3(10f, 0f, 0f);
                SpecialPerform.anchoredPosition3D = newPosition;
                Debug.Log("d");
            }
           
            //if(newPosition = )
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("ge-muo-ba-");
            //SceneManager.LoadScene("GameOver");
        }

        //SpecialPerformance
        else if (other.CompareTag("PlayerSub"))
        {
            
                peformtime = true;
            
        }
        
    }

   
   
    

}
