using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public GameObject Ghost;
    [SerializeField] GameObject item;
    //???????????@?????^?o??????
    public enum Type
    {
        Key,
        Ohuda,
        Boueikun,
        Sho
    }
    public Type type;
    [SerializeField] GameObject Player;
    
   

    // ?A?C?e??????????????????
    float interactionDistance = 2f;
    //?v???C???[???A?C?e??????????
    float PlayerItemDistance;

    private Outline outline;

    

    void Start()
    {
        outline = item.GetComponent<Outline>();
      
    }

    void Update()
    {
        //Player?????????????????A?E?g???C?????\??
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

    //?^?C?~???O?@?N???b?N????????
    public void OnPointerClick(PointerEventData eventData)
    {
        if (interactionDistance > PlayerItemDistance)
        {

           
            //:?A?C?e?????????????i?[????
            ItemBox.instance.SetItem(type);


            Ghost.SetActive(true);
            //gameObject.SetActive(false);
            Debug.Log("Click");
            Destroy(gameObject);

            //????????
           
        }
    }
}
