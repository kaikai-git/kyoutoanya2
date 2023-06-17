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
                if (SpecialPerform.anchoredPosition3D.x >= -2)
                {
                    Debug.Log("3");
                    peformanceCompleate();
                }
            }
           
            //if(newPosition = )
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("ge-muo-ba-");
            SceneManager.LoadScene("GameOver");
        }

        //SpecialPerformance
        else if (other.CompareTag("PlayerSub"))
        {
            
                peformtime = true;
            Time.timeScale = 0;
        }
        
    }

    private void peformanceCompleate()
    {
        SceneManager.LoadScene("GameOver");
        // フェードアウトが完了したら行いたい処理を記述する
        // 例えば、シーン切り替えなどの操作を行う
    }





}
