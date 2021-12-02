using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropZone : MonoBehaviour, IDropHandler , IPointerEnterHandler, IPointerExitHandler {


//	public Draggable.cardType thisType = cardType.Units;

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
			
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
			
	}


	public void OnDrop(PointerEventData eventData) {
		
		Debug.Log (eventData.pointerDrag.name + "was dropped on " + gameObject.name);
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d!= null) {
//			if(thisType == d.thisType ){
				
				
				d.parentToReturnTo = this.transform;
			//}
		}
		
	}

   
}
