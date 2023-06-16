using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{

	//　スタートボタンを押したら実行する
	public void StartGame()
	{
		SceneManager.LoadScene("Animation");
	}
	public void ReStartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}

}