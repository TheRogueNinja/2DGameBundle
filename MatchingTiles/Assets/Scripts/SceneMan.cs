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
	void OnMouseOver(){
		anim.Play("TileFlip");
		anim.Play("TileFlip");
	}
}
