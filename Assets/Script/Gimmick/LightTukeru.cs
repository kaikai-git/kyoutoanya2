using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTukeru : MonoBehaviour
{
    //アウトライン
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Affecteditem;
    [SerializeField] Text textScript;

    // アイテムを取得できる距離
    float interactionDistance = 2f;
    //プレイヤーとアイテムとの距離
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
                textScript.changetext("明かりをつけた");
            }
        }
        else
        {
            childObject.SetActive(false);
            LightOn = false;
            if (textScript != null)
            {
                textScript.changetext("明かりをけした");
            }
        }
    }

    //アウトラインの表示メソッド
    public void UpdateOutline()
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


}
