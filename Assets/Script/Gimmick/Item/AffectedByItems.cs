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

    // アイテムを取得できる距離
    float interactionDistance = 2f;
    //プレイヤーとアイテムとの距離
    float PlayerItemDistance;

    //鍵ドアの開くアニメーションと効果音
    private Animator kagidore;

    private AudioSource audioSourcedore;


    public float delayInSeconds = 0.7f; // 遅延させる秒数
    private Outline outline;

    AudioSource audioSource;
    void Start()
    {
        outline = Affecteditem.GetComponent<Outline>();
        kagidore = Kagidore.GetComponent<Animator>();
        //鍵がかかっている音
        audioSource = GetComponent<AudioSource>();

        audioSourcedore = Kagidore.GetComponent<AudioSource>();
    }
    void Update()
    {
        UpdateOutline();
       
    }
    //タイミングはクリックしたとき
    public void OnPointerClick(PointerEventData eventData)
    {
        
        
        bool HasItemKey = ItemBox.instance.CanUseItem(Item.Type.Key);//アイテムボックスに鍵があるかどうか => ItemとItemBoxを作る必要がある
        if (HasItemKey == true)//playerが葉っぱを持っていたら
        {
            if (textScript != null)
            {
                textScript.changetext("鍵がはずれた");

               

            }
            //処理消える
            gameObject.SetActive(false);

            //鍵ドアの開くアニメーション
            kagidore.SetTrigger("Open");


            // 指定秒数遅らせて音を再生
            Invoke("PlayDoorSound", delayInSeconds);


            //アイテムを使う
            ItemBox.instance.UseItem(Item.Type.Key);
            Debug.Log("会場");
        }
        else
        {
           
            if (textScript != null)
            {
                //鍵のかかっている音

                audioSource.Play();

                textScript.changetext("鍵がかかっているようだ");
            }
        }
    }


    private void PlayDoorSound()
    {
        // 扉の開く音再生
        audioSourcedore.Play();
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
