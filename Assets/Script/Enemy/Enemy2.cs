using UnityEngine.UI;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Color color;

    void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;

        color.a = 0.0f;
        gameObject.GetComponent<SpriteRenderer>().color = color;

        //???????@
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.3f, 0.1f, 0.5f);
    }

    void OnTriggerStay(Collider  other)
    {
        if(other.gameObject.tag == "CanSee")
        {
            color.a = 1.0f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            Debug.Log("hiy");
        }
        

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CanSee")
        {
            color.a = 0.0f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            Debug.Log("Hanareta");
        }
    }


}
