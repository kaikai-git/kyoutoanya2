using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject item;
    //��ނ�����@�񋓌^�o�����
    public enum Type
    {
        Key,
    }
    public Type type;
    [SerializeField] GameObject Player;
    
   

    // �A�C�e�����擾�ł��鋗��
    float interactionDistance = 2f;
    //�v���C���[�ƃA�C�e���Ƃ̋���
    float PlayerItemDistance;

    private Outline outline;

    

    void Start()
    {
        outline = item.GetComponent<Outline>();
      
    }

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

    //�^�C�~���O�@�N���b�N�����Ƃ�
    public void OnPointerClick(PointerEventData eventData)
    {
        if (interactionDistance > PlayerItemDistance)
        {

           
            //TODO:�A�C�e���ڂ������Ɋi�[����
            ItemBox.instance.SetItem(type);



            //gameObject.SetActive(false);

            Destroy(gameObject);

            //�����擾
           
        }
    }
}
