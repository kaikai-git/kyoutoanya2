using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TansuOutline : MonoBehaviour
{
    private Outline outline;


    // �A�C�e�����擾�ł��鋗��
    float interactionDistance = 2f;
    //�v���C���[�ƃA�C�e���Ƃ̋���
    float PlayerItemDistance;

    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        outline = this.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
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
