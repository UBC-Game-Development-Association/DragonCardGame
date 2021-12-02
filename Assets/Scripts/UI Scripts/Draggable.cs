using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DefaultNamespace;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
   
	public Transform parentToReturnTo = null;
	public DeckView deck;

	//public enum cardType {Unit, Process, Conservation, AnthropogenicEvents} ;
	public CardStats stats;
	
   
   
	public void OnBeginDrag(PointerEventData eventData){
		Debug.Log("OnBeginDrag");

		//thisType = cardType.pointerEnter;
		
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent(this.transform.parent.parent);

		//Get ID of card (Type, IDNumber)
		//PointerEventData.pointerEnter.cardType = currentType

		GetComponent<CanvasGroup>().blocksRaycasts = false;
		
	}
	
	public void OnDrag(PointerEventData eventData){
		Debug.Log("OnDrag");
		
		this.transform.position = eventData.position;


		//If dropped on correct x position, call AddCard to add element

	}
	
	
	public void OnEndDrag(PointerEventData eventData){
		Debug.Log("OnEndDrag");
		
		this.transform.SetParent(parentToReturnTo);

		if (eventData.position.x < 152)
        {
			//deck.AddCard(stats);
        }

		

		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}


}
