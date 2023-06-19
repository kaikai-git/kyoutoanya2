using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    float ChaceDistance = 3f;
    public GameObject TargetObject;
    public GameObject[] LoiteringObject;

    UnityEngine.AI.NavMeshAgent navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distance between player and enemy
        float distanceToPlayer = Vector3.Distance(transform.position, TargetObject.transform.position);

        if (ChaceDistance > distanceToPlayer)
        {
            Debug.Log(distanceToPlayer);
           
            // NavMesh
            if (navMeshAgent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
            {
                // NavMeshAgent�ɖړI�n���Z�b�g
                navMeshAgent.SetDestination(TargetObject.transform.position);
            }
        }
        //enemy loitering
        else
        {
            // NavMesh
            if (navMeshAgent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
            {
                // NavMeshAgent�ɖړI�n���Z�b�g
                //for (int i = 0; i < LoiteringObject.Length; i++)
                //{
                //    navMeshAgent.SetDestination(LoiteringObject.transform.position);
                //}

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        StartPlay.IsDeath = true;
        if (other.CompareTag("Player"))
        {
            Debug.Log("ge-muo-ba-");
            SceneManager.LoadScene("GameOver");
           
        }

        
        
    }


}
