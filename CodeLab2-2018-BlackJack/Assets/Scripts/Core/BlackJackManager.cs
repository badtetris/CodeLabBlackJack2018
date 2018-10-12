using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BlackJackManager : MonoBehaviour {

	public Text statusText;
	public GameObject tryAgain;
	public string loadScene;

    public AudioClip loseBeep;
    public AudioClip winBeep;

    public AudioSource loseSound;
    public AudioSource winSound;

    public GameObject dealerSprite;
    public SpriteRenderer dealerSr;

    public Sprite sparkling707;
    public Sprite question707;
    public Sprite broken707;

    private void Start()
    {
        dealerSprite.GetComponent<SpriteRenderer>().sprite = question707;
      
    }


    public void PlayerBusted()
    {
        HidePlayerButtons();
        GameOverText("YOU BUST", Color.red);
        loseSound.clip = loseBeep;
        loseSound.Play();

        dealerSprite.GetComponent<SpriteRenderer>().sprite = sparkling707;

    }

    public void DealerBusted()
    {
        GameOverText("DEALER BUSTS!", Color.green);
        winSound.clip = winBeep;
        winSound.Play();

        dealerSprite.GetComponent<SpriteRenderer>().sprite = broken707;

    }
		
	public void PlayerWin(){
        GameOverText("YOU WIN!", Color.green);
        winSound.clip = winBeep;
        winSound.Play();

        dealerSprite.GetComponent<SpriteRenderer>().sprite = broken707;

    }
		
	public void PlayerLose(){
        GameOverText("YOU LOSE.", Color.red);
        loseSound.clip = loseBeep;
        loseSound.Play();

        dealerSprite.GetComponent<SpriteRenderer>().sprite = sparkling707;
    }


	public void BlackJack(){
		GameOverText("Black Jack!", Color.green);
		HidePlayerButtons();
	}

	public void GameOverText(string str, Color color){
		statusText.text = str;
		statusText.color = color;

		tryAgain.SetActive(true);
	}

	public void HidePlayerButtons(){
		GameObject.Find("HitButton").SetActive(false);
		GameObject.Find("StayButton").SetActive(false);
	}

	public void TryAgain(){
		SceneManager.LoadScene(loadScene);
	}

	public virtual int GetHandValue(List<DeckOfCards.Card> hand){
		int handValue = 0;

		foreach(DeckOfCards.Card handCard in hand){
			handValue += handCard.GetCardHighValue();
		}
		return handValue;
	}
}
