using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTukeru : MonoBehaviour
{
    //�A�E�g���C��
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Affecteditem;
    [SerializeField] Text textScript;

    // �A�C�e�����擾�ł��鋗��
    float interactionDistance = 2f;
    //�v���C���[�ƃA�C�e���Ƃ̋���
    float PlayerItemDistance;
    private Outline outline;

    public GameObject childObject;
    bool LightOn = false;
    
   
    void Start()
    {
        outline = Affecteditem.GetComponent<Outline>();
    }
    void Update()
    {

        UpdateOutline();
    }
    private void OnMouseDown()
    {
        if(LightOn == false)
        {
            childObject.SetActive(true);
            LightOn = true;
            if (textScript != null)
            {
                textScript.changetext("�����������");
            }
        }
        else
        {
            childObject.SetActive(false);
            LightOn = false;
            if (textScript != null)
            {
                textScript.changetext("�������������");
            }
        }
    }

    //�A�E�g���C���̕\�����\�b�h
    public void UpdateOutline()
    {
        //Player�Ƃ̋����ɂ���ăA�E�g���C���̕\��
        PlayerItemDistance = Vector3.Distance(Player.transform.position, transform.position);
        if (interactionDistance > PlayerItemDistance)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }


}
