using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject item;
    //種類がある　列挙型出かんり
    public enum Type
    {
        Key,
    }
    public Type type;
    [SerializeField] GameObject Player;
    
   

    // アイテムを取得できる距離
    float interactionDistance = 2f;
    //プレイヤーとアイテムとの距離
    float PlayerItemDistance;

    private Outline outline;

    

    void Start()
    {
        outline = item.GetComponent<Outline>();
      
    }

    void Update()
    {
        //Playerとの距離によってアウトラインの表示
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

    //タイミング　クリックしたとき
    public void OnPointerClick(PointerEventData eventData)
    {
        if (interactionDistance > PlayerItemDistance)
        {

           
            //TODO:アイテムぼっくすに格納され
            ItemBox.instance.SetItem(type);



            //gameObject.SetActive(false);

            Destroy(gameObject);

            //鍵を取得
           
        }
    }
}
