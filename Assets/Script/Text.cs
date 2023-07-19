using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // テキストの設定例
       
    }

    //テキストの変更メソッド
    public void changetext(string newtext)
    {
        //textMeshPro.text = newtext;
        textMeshPro.text = newtext;
        Invoke(nameof(ClearText), 3f);
    }

    public void ClearText()
    {
        textMeshPro.text = "";
    }
}
