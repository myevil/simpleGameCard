using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public Text credit;
	public Slider bet;
	public Text betText;
	public static float betNumber;

	// Use this for initialization
	void Start () {
		credit.text = "Credit : " + DataUser.credit.ToString();
		bet.maxValue = DataUser.credit;
	}
	
	// Update is called once per frame
	void Update () {
		betText.text = bet.value.ToString();
	}

	public void play()
	{
		if(bet.value <= DataUser.credit && bet.value != 0)
		{
			betNumber = bet.value;
			Debug.Log(betNumber);
			SceneManager.LoadScene("SampleScene");
		}
	}

	public void reset()
	{
		DataUser.resetCredit();
		credit.text = "Credit : " + DataUser.credit.ToString();
	}

}
