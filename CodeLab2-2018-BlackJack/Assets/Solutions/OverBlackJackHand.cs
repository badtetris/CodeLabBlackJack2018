using UnityEngine;
using System.Collections;

public class OverBlackJackHand : BlackJackHand {

	protected override void SetupHand(){
		base.SetupHand();

		if(GetHandValue() >= currentAuctionValue){
			BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();

			manager.BlackJack();
		}
	}
		
}
