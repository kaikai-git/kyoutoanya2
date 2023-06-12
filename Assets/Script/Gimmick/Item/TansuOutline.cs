using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TansuOutline : MonoBehaviour
{
    private Outline outline;


    // アイテムを取得できる距離
    float interactionDistance = 2f;
    //プレイヤーとアイテムとの距離
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
