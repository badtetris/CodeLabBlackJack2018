using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class BlackJackHand : MonoBehaviour {

	public int currentAuctionValue;
	public Text total;
	public float xOffset;
	public float yOffset;
	public GameObject handBase;
	public int handVals;
	public GameObject currentArtwork;
	public float hitMeCutOff;
	protected DeckOfCards deck;
	protected List<DeckOfCards.Card> hand;
	bool stay = false;

	protected DeckOfAuctionArt auctionDeck;
	protected List<DeckOfAuctionArt.Card> auctionItem;

	// Use this for initialization
	void Start () {
		SetupAuction ();
		SetupHand();
		Debug.Log( "Auction Item" + currentArtwork );
		Debug.Log ("Auction Value" + currentAuctionValue);

		//float hitMeCutOff = ((8/10.0f)*(currentAuctionValue));

	}


	protected virtual void SetupAuction(){
		auctionDeck = GameObject.Find("AuctionDeck").GetComponent<DeckOfAuctionArt>();
		auctionItem = new List<DeckOfAuctionArt.Card>();
		HitMeAuction();
		Debug.Log ("SetupAuction Function Ran");

		//auctionItem.GetHashCode() =currentAuctionValue;
	}

	protected virtual void SetupHand(){
		deck = GameObject.Find("MoneyDeck").GetComponent<DeckOfCards>();
		hand = new List<DeckOfCards.Card>();
		HitMe();
	}
	//
	// Update is called once per frame
	void Update () {
	}

	public void HitMe(){
		if(!stay){
			DeckOfCards.Card card = deck.DrawCard();

			GameObject cardObj = Instantiate(Resources.Load("prefab/Card")) as GameObject;

			ShowCard(card, cardObj, hand.Count);

			hand.Add(card);

			ShowValue();
		}
	}
	public void HitMeAuction(){
		if(!stay){
			DeckOfAuctionArt.Card card = auctionDeck.DrawCard();

			GameObject cardObj = Instantiate(Resources.Load("prefab/ArtCard")) as GameObject;

			ShowCard(card, cardObj, auctionItem.Count);

			auctionItem.Add(card);

			ShowValue();
		}
	}

	protected void ShowCard(DeckOfCards.Card card, GameObject cardObj, int pos){
		cardObj.name = card.ToString();

		cardObj.transform.SetParent(handBase.transform);
		cardObj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
		cardObj.GetComponent<RectTransform>().anchoredPosition = 
			new Vector2( xOffset, yOffset);

		cardObj.GetComponentInChildren<Text>().text = deck.GetNumberString(card);
		cardObj.GetComponentsInChildren<Image>()[1].sprite = deck.GetSuitSprite(card);
	}

	protected virtual void ShowValue(){
		handVals = GetHandValue();
			
		total.text = "Player: " + handVals;

		if(handVals > currentAuctionValue){
			GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerBusted();
		}
	}

	public int GetHandValue(){
		BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();

		return manager.GetHandValue(hand);
	}
}
