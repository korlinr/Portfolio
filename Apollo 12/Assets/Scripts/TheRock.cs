using UnityEngine;
using System.Collections;

public class TheRock : MonoBehaviour {
	float timer;
	public GameObject Lander;
	// Use this for initialization
	void Start () {
	Lander = GameObject.Find("Lander"); 
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Lander.GetComponent<LanderControl>().Landed == true){Destroy(this.gameObject);}
		timer += Time.deltaTime; 
		if(timer>6){Destroy(this.gameObject);}
	}
}
