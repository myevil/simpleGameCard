using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUser : MonoBehaviour {
	public static float credit = 10000;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.HasKey("credit"))
		{
			credit = PlayerPrefs.GetFloat("credit");
		}
		else
		{
			PlayerPrefs.SetFloat("credit", credit);
		}
	}

	public static void saveCredit()
	{
		PlayerPrefs.SetFloat("credit", credit);
	}

	public static void resetCredit()
	{
		credit = 10000;
		PlayerPrefs.SetFloat("credit", credit);
	}
	
	// Update is called once per frame


}
