using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeckOfCards : MonoBehaviour {
	
	public Text cardNumUI;
	public Image cardImageUI;
	public Sprite[] cardSuits;

	public class Card{

		public enum Suit {
			CASHMONEY, 	//0
		};

		public enum Type {
			TWOHUNDREDFIFTY		= 250,
			FIVEHUNDRED			= 500,
			ONETHOUSAND			= 1000,
			TWOTHOUSAND			= 2000,
			FIVETHOUSAND		= 5000,
			TENTHOUSAND			= 10000,
			TWENTYFIVETHOUSAND	= 25000,
			FIFTYTHOUSAND		= 50000,
			SEVENTYFIVETHOUSAND = 75000,
			ONEHUNDREDTHOUSAND	= 100000,
			FIVEHUNDREDTHOUSAND	= 500000,
		};

		public Type cardNum;
		
		public Suit suit;

		public Card(Type cardNum, Suit suit){
			this.cardNum = cardNum;
			this.suit = suit;
		}

		public override string ToString(){
			return "The " + cardNum + " of " + suit;
		}

		public int GetCardHighValue(){
			int val;

			switch(cardNum){
			default:
				val = (int)cardNum;
				break;
			}

			return val;
		}
	}

	public static ShuffleBag<Card> deck;

	// Use this for initialization
	void Awake () {

		if(!IsValidDeck()){
			deck = new ShuffleBag<Card>();

			AddCardsToDeck();
		}

		Debug.Log("Cards in Money Deck: " + deck.Count);
	}

	protected virtual bool IsValidDeck(){
		return deck != null; 
	}

	protected virtual void AddCardsToDeck(){
		foreach (Card.Suit suit in Card.Suit.GetValues(typeof(Card.Suit))){
			foreach (Card.Type type in Card.Type.GetValues(typeof(Card.Type))) {
				deck.Add (new Card (type, suit));
			}

		}

	}
	
	// Update is called once per frame
	void Update () {
	}

	public virtual Card DrawCard(){
		Card nextCard = deck.Next();

		return nextCard;
	}


	public string GetNumberString(Card card){
		if(card.cardNum.GetHashCode() <= 1000001){
			return card.cardNum.GetHashCode() + "";
		}
		else {
			return card.cardNum + "";
		}
	}
		
	public Sprite GetSuitSprite(Card card){
		return cardSuits[card.suit.GetHashCode()];
	}
}
