using UnityEngine;
using System.Collections;

public class LauncherScript : MonoBehaviour {
	
	/**********************************************************
	QTE's 
	*********************************************************/
	public float BurnRate = 1;
	public float QTimer1 = 0;
	public float IdTime1 = 25;  
	
	/***********************************************************
	Scores
	***********************************************************/
	public float Score1; 
	
	/***********************************************************
	Bools
	**********************************************************/
	public bool Event1 = false;
	public bool Event2 = false;  
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Event1 == true)
		{
			QTimer1 += BurnRate * Time.deltaTime;
			if(Input.GetKeyDown(KeyCode.Space))
			{
			Score1 = QuickTimeEvent(QTimer1, IdTime1, BurnRate, Score1);
			Debug.Log("Time  " + QTimer1);
			Debug.Log("Score  " + Score1);
			Event1 = false; 
			Event2 = true;
			}
		}
		 
	}
	float QuickTimeEvent(float timer, float idtime,float burnrate, float score)
	{
			score =  (idtime - timer);
			if(score<0)
			{
				score = score *-1; 
			}
			score = 100 - score;
			return score; 

	}
}
