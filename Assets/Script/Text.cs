using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // �e�L�X�g�̐ݒ��
       
    }

    //�e�L�X�g�̕ύX���\�b�h
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
