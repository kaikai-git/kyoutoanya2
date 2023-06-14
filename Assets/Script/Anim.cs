using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Anim : MonoBehaviour
{

	//　スタートボタンを押したら実行する
	public void StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}
}