using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

   public  float ChaceDistance = 3f;
    public GameObject TargetObject;

    [SerializeField]
    private Transform[] waypoints;
    private int currentWaypointIndex;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
      
        //Distance between player and enemy
        float distanceToPlayer = Vector3.Distance(transform.position, TargetObject.transform.position);

        // float distanceToEnemy = Vector3.Distance(transform.position, LoiteringObject[rndnum].transform.position);
        Text textScript = FindObjectOfType<Text>();
        if (ChaceDistance > distanceToPlayer)
        {
            Debug.Log(distanceToPlayer);

            
            if (textScript != null)
            {
                textScript.changetext("なにかが近づいている");
            }
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

                //textScript.ClearText();
                //changedist
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    // 目的地の番号を１更新（右辺を剰余演算子にすることで目的地をループさせれる）
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                    // 目的地を次の場所に設定
                    navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
                   
                }
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
