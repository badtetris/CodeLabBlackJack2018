using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeckOfAuctionArt : MonoBehaviour {
	
	public Text cardNumUI;
	public Image cardImageUI;
	public Sprite[] artworkImgs;

	public class Card{

		public enum Suit {
			ARTWORK1, 	//0
			ARTWORK2, 	//0
			ARTWORK3,
			ARTWORK4,
			ARTWORK5,
			ARTWORK6,
			ARTWORK7,
			ARTWORK8,
			ARTWORK9,
			ARTWORK10,
			ARTWORK11,
			ARTWORK12,
			ARTWORK13,
			ARTWORK14,
		};

		public enum Type {
			NICEFAKE			= 11500,
			REPLICA				= 24275,
			DAMAGED				= 37500,
			COMMON				= 97000,
			DERRIVITIVE			= 112000,
			RESTORED			= 243000,
			UNEXCEPTIONAL		= 465000,
			UNPOPULARARTIST		= 625000,
			ANTIQUE				= 852000,
			PRISTINE 			= 425000,
			HISTORIC			= 3530000,
			EXQUISITE			= 4275000,
			FAMOUS				= 5750000,
			ONEOFAKIND			= 9750000,
		};

		public Type cardNum;
		
		public Suit suit;

		public int spriteIndex; 

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

		Debug.Log("Cards in Auction Deck: " + deck.Count);
	}

	protected virtual bool IsValidDeck(){
		return deck != null; 
	}

	protected virtual void AddCardsToDeck(){
			foreach (Card.Suit suit in Card.Suit.GetValues(typeof(Card.Suit))){
				int typeIndex = 0;


				foreach (Card.Type type in Card.Type.GetValues(typeof(Card.Type))){
					Card newCard = new Card(type, suit);
					newCard.spriteIndex = typeIndex;
					deck.Add(newCard);
					typeIndex++;
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
		return artworkImgs[card.suit.GetHashCode()];
	}
}
