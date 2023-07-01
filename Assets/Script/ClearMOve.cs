using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearMOve : MonoBehaviour
{
    public Image fadeout;
    private bool isFading = false;
    
    Color color;
    public float fadeSpeed = 0.1f;

    
    private void Start()
    {
        // フェードアウトイメージの初期設定
        fadeout.color = new Color(fadeout.color.r, fadeout.color.g, fadeout.color.b, 0f);
    }

    private void Update()
    {
        // フェードアウト処理
        if (isFading)
        {
            fadeout.color = new Color(fadeout.color.r, fadeout.color.g, fadeout.color.b, fadeout.color.a + fadeSpeed * Time.deltaTime);

            if (fadeout.color.a >= 1f)
            {
                // フェードアウトが完了したら処理を行う（例：シーン切り替え）
                FadeOutComplete();
            }
        }
    }

    


    private void FadeOutComplete()
    {

        SceneManager.LoadScene("ClearScene");
       
        // フェードアウトが完了したら行いたい処理を記述する
        // 例えば、シーン切り替えなどの操作を行う
    }


    private void OnTriggerEnter(Collider other)
    {
        
        isFading = true;
    }
}
