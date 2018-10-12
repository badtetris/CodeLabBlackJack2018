using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BlackJackManager : MonoBehaviour {

	public Text statusText;
	public GameObject tryAgain;
	public string loadScene;

	public void PlayerBusted(){
		HidePlayerButtons();
		GameOverText("YOU BUST!", Color.red);
        DealerScore.scoreValue++;
	}

	public void DealerBusted(){
		GameOverText("DEALER BUSTS!", Color.green);
        ScoreCounter.scoreValue++;
    }
		
	public void PlayerWin(){
		GameOverText("YOU WIN!", Color.green);
        ScoreCounter.scoreValue++;
    }
		
	public void PlayerLose(){
		GameOverText("YOU LOSE.", Color.red);
        DealerScore.scoreValue++;

    }


	public void BlackJack(){
		GameOverText("Black Jack!", Color.green);
		HidePlayerButtons();
        ScoreCounter.scoreValue += 3;
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
