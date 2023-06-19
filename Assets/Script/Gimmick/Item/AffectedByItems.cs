using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class AffectedByItems : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Affecteditem;
    [SerializeField] Text textScript;

    public GameObject Kagidore;

    // �A�C�e�����擾�ł��鋗��
    float interactionDistance = 2f;
    //�v���C���[�ƃA�C�e���Ƃ̋���
    float PlayerItemDistance;

    //���h�A�̊J���A�j���[�V�����ƌ��ʉ�
    private Animator kagidore;

    private AudioSource audioSourcedore;


    public float delayInSeconds = 0.7f; // �x��������b��
    private Outline outline;

    AudioSource audioSource;
    void Start()
    {
        outline = Affecteditem.GetComponent<Outline>();
        kagidore = Kagidore.GetComponent<Animator>();
        //�����������Ă��鉹
        audioSource = GetComponent<AudioSource>();

        audioSourcedore = Kagidore.GetComponent<AudioSource>();
    }
    void Update()
    {
        UpdateOutline();
       
    }
    //�^�C�~���O�̓N���b�N�����Ƃ�
    public void OnPointerClick(PointerEventData eventData)
    {
        
        
        bool HasItemKey = ItemBox.instance.CanUseItem(Item.Type.Key);//�A�C�e���{�b�N�X�Ɍ������邩�ǂ��� => Item��ItemBox�����K�v������
        if (HasItemKey == true)//player���t���ς������Ă�����
        {
            if (textScript != null)
            {
                textScript.changetext("�����͂��ꂽ");

               

            }
            //����������
            gameObject.SetActive(false);

            //���h�A�̊J���A�j���[�V����
            kagidore.SetTrigger("Open");


            // �w��b���x�点�ĉ����Đ�
            Invoke("PlayDoorSound", delayInSeconds);


            //�A�C�e�����g��
            ItemBox.instance.UseItem(Item.Type.Key);
            Debug.Log("���");
        }
        else
        {
           
            if (textScript != null)
            {
                //���̂������Ă��鉹

                audioSource.Play();

                textScript.changetext("�����������Ă���悤��");
            }
        }
    }


    private void PlayDoorSound()
    {
        // ���̊J�����Đ�
        audioSourcedore.Play();
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
