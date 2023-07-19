using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToStart : MonoBehaviour
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

    //スタートボタンを押したら実行する
    public void StartGame()
    {
        isFading = true;
        Debug.Log("q");
        //SceneManager.LoadScene("Animation");
    }
    

    private void FadeOutComplete()
    {
       
            SceneManager.LoadScene("Start");
        
    }


    
    //public Image fadeoutImage;
    //public float fadeSpeed = 0.1f;

    //private bool isFading = false;

    //private void Start()
    //{
    //    // フェードアウトイメージの初期設定
    //    fadeoutImage.color = new Color(fadeoutImage.color.r, fadeoutImage.color.g, fadeoutImage.color.b, 0f);
    //}

    //private void Update()
    //{
    //    // フェードアウト処理
    //    if (isFading)
    //    {
    //        fadeoutImage.color = new Color(fadeoutImage.color.r, fadeoutImage.color.g, fadeoutImage.color.b, fadeoutImage.color.a + fadeSpeed * Time.deltaTime);

    //        if (fadeoutImage.color.a >= 1f)
    //        {
    //            // フェードアウトが完了したら処理を行う（例：シーン切り替え）
    //            FadeOutComplete();
    //        }
    //    }
    //}

    //public void StartFadeOut()
    //{
    //    Debug.Log("a");
    //    // ボタンがクリックされたらフェードアウトを開始する
    //    isFading = true;
    //    SceneManager.LoadScene("Animation");
    //}

    //private void FadeOutComplete()
    //{
    //    // フェードアウトが完了したら行いたい処理を記述する
    //    // 例えば、シーン切り替えなどの操作を行う
    //}
}