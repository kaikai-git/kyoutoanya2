using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject TargetObject;

    UnityEngine.AI.NavMeshAgent navMeshAgent;

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
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("ge-muo-ba-");
        }
        
    }
}
