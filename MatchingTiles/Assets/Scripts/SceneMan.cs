using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {
	[SerializeField]
	private GameObject Tile;
	[SerializeField]
	private GameObject Slide;
	
	public Animator anim;
	public void loadMatchTiles(){
		SceneManager.LoadScene(1);
	}
	public void loadSlideTiles(){
		SceneManager.LoadScene(2);
	}
	void Update(){
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
