using UnityEngine;
using System.Collections;

public class BlackJackDeck: DeckOfCards {

	protected override bool IsValidDeck(){
		return deck != null && deck.Count > 2;
	}

	protected override void AddCardsToDeck(){
		base.AddCardsToDeck();
//		base.AddCardsToDeck();
//		base.AddCardsToDeck();
//		base.AddCardsToDeck();
	}

	public override Card DrawCard(){
		Card nextCard = deck.Next();

		deck.Remove(nextCard);

		return nextCard;
	}

}
