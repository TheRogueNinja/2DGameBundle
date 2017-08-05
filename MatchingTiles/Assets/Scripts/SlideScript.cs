using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideScript : MonoBehaviour {

	public Transform emptySlot;
	Vector3 temp;
	void OnMouseDown(){
		Debug.Log("Clicked");
		if(Vector3.Distance(transform.localPosition,emptySlot.localPosition)==1f){
			Debug.Log("here");
			temp.x = emptySlot.localPosition.x;
			temp.y = emptySlot.localPosition.y;
			emptySlot.localPosition = this.transform.localPosition;
			this.transform.localPosition.Equals(temp);
			//ytemp = transform.localPosition.y;
			//transform.localPosition.x.Equals(emptySlot.localPosition.x);
			//transform.localPosition.y.Equals(emptySlot.localPosition.y);

			
		}
	}
}
