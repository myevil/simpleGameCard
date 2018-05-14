using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Deck : MonoBehaviour {

	public List<Sprite> cardImage = new List<Sprite>();
	public GameObject credit;
	public Image card;
	public bool hitButton;
	public bool found;
	private int randomNumber;
	private float wait;
	private int count;
	private int pickNumber;
	public GameObject gameOver;
	public Text countText;

	// Use this for initialization
	void Start () 
	{
		count = 0;
		countText.text = count.ToString();
		randomNumber = Random.Range(0,52);
		wait = Random.Range(0.5f, 2f);
		hitButton = true;
		StartCoroutine(randomCard());
	}
	
	void Update()
	{
	}

	IEnumerator randomCard()
	{
		while(hitButton)
		{
			countText.text = (count + 1).ToString();
			Debug.Log(randomNumber);
			card.GetComponent<Image>().sprite = cardImage[randomNumber];
			yield return new WaitForSeconds(wait);
			if(count == (randomNumber % 13) && hitButton == true)
			{
				hitButton = false;
				GameObject go = Instantiate(gameOver, transform, false);
				DataUser.credit -= MainMenu.betNumber;
				go.GetComponentInChildren<Text>().text = DataUser.credit.ToString();
				go.GetComponentInChildren<Button>().onClick.AddListener(backMainMenu);
			}
			if(count == 12)
			{
				count = 0;
			}
			else
			{
				count++;
			}

			randomNumber = Random.Range(0,52);
		}
	}
	public void hit()
	{
		hitButton = false;
		pickNumber = count;
		GameObject go = Instantiate(gameOver, transform, false);
		if(pickNumber == randomNumber % 13)
		{
			DataUser.credit += MainMenu.betNumber;
		}
		else
		{
			DataUser.credit -= MainMenu.betNumber;
		}
		go.GetComponentInChildren<Text>().text = DataUser.credit.ToString();
		go.GetComponentInChildren<Button>().onClick.AddListener(backMainMenu);
	}

	public void backMainMenu()
	{
		DataUser.saveCredit();
		SceneManager.LoadScene("MenuScene");
	}
	

}
