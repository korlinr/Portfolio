using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMan : MonoBehaviour {


	public GameObject LoseScreen; 
	public GameObject WinScreen; 
	public float Timer;
	public bool DonePlaying; 
	public float RemFuel;
	public float LandingForce;  
	public Sprite[] facts; 

	
	// Use this for initialization
	void Start () {
		Timer = 0; 
		DonePlaying = false;  
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(DonePlaying == false){Timer += 1*Time.deltaTime;} 
		//Debug.Log("Time  " + Timer); 
	}
	
	public void DisplayWin()
	{
		Debug.Log("Won");
		int Factomizer = Random.Range(0, facts.Length); 
		WinScreen.gameObject.SetActive(true);
		WinScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = facts[Factomizer]; 
		DonePlaying = true; 
		float FinalScore = Score(Timer, RemFuel, LandingForce); 
		Debug.Log("You Scored  " + FinalScore); 
	}
	public void DisplayLost()
	{
		Debug.Log("Lost");
		LoseScreen.gameObject.SetActive(true);
		DonePlaying = true;
	}
	public float Score(float ScoreTime,float ScoreFuel, float SoftLanding)
	{
		ScoreTime = 1000 / ScoreTime;  
		float TotalScore; 
		TotalScore = (ScoreFuel * ScoreTime) / SoftLanding;
		return TotalScore;  
	}
}
