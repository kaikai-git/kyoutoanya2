using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hakai : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject[] HakaiDore;
    public GameObject Obake;

    // ドアの個別の回転角度
    Quaternion[] rotations = new Quaternion[]
    {
        Quaternion.Euler(0, 30, 90), // 0番目のドアの回転角度
        Quaternion.Euler(0, 10, 80), // 1番目のドアの回転角度
        Quaternion.Euler(0, 10, 60), // 2番目のドアの回転角度
        // 必要な回転角度を配列に追加していく
    };


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //コライダー内に入るとイベント発生
    private void OnTriggerEnter(Collider other)
    {
        
        //ドアが破壊される音
        audioSource.Play();
        for (int i = 0; i < HakaiDore.Length; i++)
        {
            if (i < rotations.Length)
            {
                // ドアの位置と角度を設定
                HakaiDore[i].transform.rotation = rotations[i];
            }
        }

        //テキストを表示
        Text textScript = FindObjectOfType<Text>();
        if (textScript != null)
        {
            textScript.changetext("下から何かが壊れる音がした");
        }

        //Collision破壊
        Destroy(gameObject, 3f);

        //お化けを破壊
        Destroy(Obake);

    }
}
