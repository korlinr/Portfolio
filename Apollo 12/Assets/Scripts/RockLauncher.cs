using UnityEngine;
using System.Collections;

public class RockLauncher : MonoBehaviour {
	public float timer;
	public float RanTime = 3;  
	public GameObject Meteor; 
	public float XStart; 
	public bool Launching =true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	if(Launching)
	{
	timer += Time.deltaTime; 
		if(timer > RanTime)
		{
			RanTime = Random.Range(1, 5); 
			timer = 0; 
			GameObject meteorCopy = (GameObject)Instantiate(Meteor, new Vector3(XStart, Random.Range(-1.5f, 5), -8), this.transform.rotation);
				if(XStart>0)
				{
				meteorCopy.rigidbody2D.AddForce(new Vector2(-0.015f, 0));
				}
				else
				{
				meteorCopy.rigidbody2D.AddForce(new Vector2(0.015f, 0));
				}
				
		}
	}	
	
	}
}
