﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour {

	[SerializeField]
	private Transform field;
	[SerializeField]
	private GameObject tiles;
	void Awake(){
		for(int i = 0;i<8;i++){
			GameObject btn = Instantiate(tiles);
			btn.name = ""+i;
			btn.transform.SetParent(field,false);
		}
	}
}
