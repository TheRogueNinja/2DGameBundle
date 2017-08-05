using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	[SerializeField]
	private Sprite bgImg;
	public Sprite[] tiles;
	public List<Sprite> xy = new List<Sprite>();
	public List<Button> btns = new List<Button>();
	bool FirstGuess,SecondGuess;
	int countGuess,countCorrectGuess,gameGuess;
	int firstGuessTileIndex, secondGuessTileIndex;
	string firstGuessTile,secondGuessTile;
	// Use this for initialization
	void Start () {
		getButtons();
		addListeners();
		addGameTileImg();
		shuffler(xy);
		gameGuess = xy.Count/2;	
	}
	void getButtons () {
		GameObject[] btntile = GameObject.FindGameObjectsWithTag("Tile");
		for(int i = 0;i<btntile.Length;i++){
			btns.Add(btntile[i].GetComponent<Button>());
			btns[i].image.sprite = bgImg;
		}
	}
	void addListeners(){
		foreach(Button tile1 in btns){
			tile1.onClick.AddListener(()=> pickTile());
		}
	}
	void addGameTileImg(){
		int looper = btns.Count;
		int j=0;

		for(int i=0;i<looper;i++){
			if(j == looper/2){
				j=0;
			}
			xy.Add(tiles[j]);
			j++;
		}
	}

	void pickTile(){
		if(!FirstGuess){
			FirstGuess = true;
			firstGuessTileIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			firstGuessTile = xy[firstGuessTileIndex].name;
			btns[firstGuessTileIndex].image.sprite = xy[firstGuessTileIndex];
		}
		else if(!SecondGuess){
			SecondGuess = true;
			secondGuessTileIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			secondGuessTile = xy[secondGuessTileIndex].name;
			btns[secondGuessTileIndex].image.sprite = xy[secondGuessTileIndex];
			countGuess++;
			StartCoroutine(CheckIfTilesMatch());
		}
	}
	IEnumerator CheckIfTilesMatch(){
		yield return new WaitForSeconds(1f);
		if(firstGuessTile == secondGuessTile){
			yield return new WaitForSeconds(.5f);
			
			btns[firstGuessTileIndex].interactable = false;
			btns[secondGuessTileIndex].interactable = false;
			
			btns[firstGuessTileIndex].image.color=new Color(0,0,0,0);
			btns[secondGuessTileIndex].image.color=new Color(0,0,0,0);
			checkIfGameEnd();
		}
		else{
			btns[firstGuessTileIndex].image.sprite = bgImg;
			btns[secondGuessTileIndex].image.sprite = bgImg;
		}
		yield return new WaitForSeconds(.5f);
		FirstGuess = SecondGuess = false;
	}
	void checkIfGameEnd(){
		countCorrectGuess++;
		if(countCorrectGuess==gameGuess){
			Debug.Log("Game Ended");
			Debug.Log("You took "+countGuess+" guesses to finish the game..");
			Invoke("SceneChange",1f);
		}
	}
	void SceneChange(){
		SceneManager.LoadScene(0);
	}
	void shuffler(List<Sprite> l){
		for(int i = 0;i<l.Count;i++){
			Sprite tmp = l[i];
			int rand = Random.Range(i,l.Count);
			l[i] = l[rand];
			l[rand] = tmp;
		}
	}
}
