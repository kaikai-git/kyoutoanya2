using UnityEngine.UI;
using UnityEngine;
using System.Collections; // 追加
using UnityEngine.SceneManagement;


public class Enemy2 : MonoBehaviour
{

    public GameObject TargetObject;
    public RectTransform SpecialPerform;

    private Color color;
    private float fadeSpeed = 0.02f; // アルファ値の変化量
    private bool peformtime = false;

    UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 0.2f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
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

        if (peformtime)
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
        if (other.CompareTag("Player"))
        {
            Debug.Log("ge-muo-ba-");
            SceneManager.LoadScene("GameOver");
            StartPlay.IsDeath = true;
        }

        //SpecialPerformance
        else if (other.CompareTag("PlayerSub"))
        {
            StartPlay.IsDeath = true;
            peformtime = true;
            Time.timeScale = 0;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CanSee")
        {
            color.a += fadeSpeed;
            color.a = Mathf.Clamp01(color.a); // アルファ値を0から1の範囲に制限する
            gameObject.GetComponent<SpriteRenderer>().color = color;
            Debug.Log("hiy");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CanSee")
        {
            StartCoroutine(FadeOut());
            Debug.Log("Hanareta");
        }
    }

    private void peformanceCompleate()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameOver");
        
        // フェードアウトが完了したら行いたい処理を記述する
        // 例えば、シーン切り替えなどの操作を行う
    }

    IEnumerator FadeOut()
    {
        while (color.a > 0.0f)
        {
            color.a -= fadeSpeed;
            color.a = Mathf.Clamp01(color.a); // アルファ値を0から1の範囲に制限する
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
    }
}
