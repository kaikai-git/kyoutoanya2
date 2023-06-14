using UnityEngine.UI;
using UnityEngine;
using System.Collections; // 追加

public class Enemy2 : MonoBehaviour
{
    private Color color;
    private float fadeSpeed = 0.02f; // アルファ値の変化量

    void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 0.0f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
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
