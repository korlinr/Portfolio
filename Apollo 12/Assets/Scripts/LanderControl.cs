using UnityEngine;
using System.Collections;

public class LanderControl : MonoBehaviour {


	public GameObject UIManager;
	public GameObject GroundControl;  
	public GameObject Try; 
	
	/**************************************
	 * Control
	 * ***********************************/
	 public Texture2D ButtonLeft; 
	 public Texture2D ButtonRight; 
	 
	/**************************************
	 * Movement Variables
	 * ***********************************/
	public float TrustForce = 2f ; 
	private Vector2 RightTrust = new Vector2(-1, 0.5f); 
	private Vector2 LeftTrust = new Vector2(1, 0.5f); 
	private Vector2 Uptrust = new Vector2(0, 2); 
	public float CrashThres = 1.5f;
	public GameObject RightTruster; 
	public GameObject LeftTruster; 

	/**************************************
	 * FuelBar
	 * **********************************/
	public float TrustFuel = 5;
	public GameObject FuelBar, ground; 
	/**************************************
	 * FuelBar
	 * **********************************/
	public float VelocityValue = 5;
	public GameObject VelocityBar; 
	
	/**************************************
	Bools
	**************************************/
	public bool Landed = false; 
	
	
	
	
	// Use this for initialization
	void Start () 
	{

	


	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D coll)
	{
		LeftTruster.gameObject.particleSystem.enableEmission = false;
		RightTruster.gameObject.particleSystem.enableEmission = false;
		Landed = true; 
		//GroundControl = GameObject.FindGameObjectsWithTag("Ground"); 
		new WaitForSeconds(1.5f);
		this.rigidbody2D.isKinematic = true; 
		UIManager.GetComponent<UIMan>().RemFuel = TrustFuel; 
		UIManager.GetComponent<UIMan>().LandingForce = VelocityValue;
			
		if(coll.gameObject.name == "SafeLandingColl")
		{	Debug.Log ("Bump");
			if(VelocityValue< CrashThres)
			{
				UIManager.GetComponent<UIMan>().DisplayWin();
				Debug.Log("SAFE!");
			}
			else
			{
				UIManager.GetComponent<UIMan>().DisplayLost(); 
				Debug.Log("FUCK YOU!!! YOU LOST!!!! YOU KILLED YOUR CREW!!!!");
			}
		}
		if(coll.gameObject.name  == "GroundCollider")
		{
			
				Debug.Log("Crash!");
				UIManager.GetComponent<UIMan>().DisplayLost(); 
			
		}
	}
	void Update () 
	{
		
		if(Landed == true)
		{
			Try.gameObject.SetActive(true);
			if(Input.touchCount > 0 || Input.GetKey(KeyCode.Space))
			{
				Application.LoadLevel(2);
			}
		}
		if(Landed == false)
		{
			VelocityValue = this.rigidbody2D.velocity.y;
			if(VelocityValue>0){VelocityValue = 0;}
			if(VelocityValue<0){VelocityValue = VelocityValue * -1f;}
			if(VelocityValue>CrashThres){VelocityBar.gameObject.renderer.material.color = Color.red;} else {VelocityBar.gameObject.renderer.material.color = Color.green;}
			VelocityBar.transform.localScale = new Vector3 (0.5f, VelocityValue + 0.5f, 0.5f);
			  
			if(TrustFuel>0)
			{
				Trusters();
			}
			FuelBar.transform.localScale = new Vector3 (TrustFuel/9, 0.3f, 0.3f);
			if(TrustFuel <= 0)
			{
				TrustFuel = 0; 
			}
		}
		//Debug.Log(this.rigidbody2D.velocity.y);
		else {
			GameObject[] groundParts = GameObject.FindGameObjectsWithTag("RockyGround");
			foreach(GameObject groundPart in groundParts) {
				groundPart.gameObject.GetComponent<GroundMovement>().GroundMoving = false;
			
			GameObject[] RockLaunchers = GameObject.FindGameObjectsWithTag("RockLauncher");
			foreach(GameObject RockLauncher in RockLaunchers) {
				RockLauncher.gameObject.GetComponent<RockLauncher>().Launching = false;
				}
				
		}
	}
	}
	void TrusterFuelTank()
	{
		TrustFuel -= 1*Time.deltaTime;
	}
	void Trusters()
	{	
	//if(Application.isEditor)
	//{
	if(Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody2D.AddForce(RightTrust * TrustForce);
			RightTruster.gameObject.particleSystem.enableEmission = true;  
			TrusterFuelTank(); 
		}
	else{RightTruster.gameObject.particleSystem.enableEmission = false; }
		
	if(Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2D.AddForce(LeftTrust * TrustForce);
			LeftTruster.gameObject.particleSystem.enableEmission = true; 
			TrusterFuelTank();
		}
	else{LeftTruster.gameObject.particleSystem.enableEmission = false; }
	//}
	/*else{
		if(Landed == false)
		{
		if(Input.touchCount > 0 && Input.GetTouch(0).position.x >  Screen.width/2)
		{	if(Input.touchCount > 1)
			{
				rigidbody2D.AddForce(RightTrust * TrustForce);
				RightTruster.gameObject.particleSystem.enableEmission = true;  
				TrusterFuelTank(); 
				rigidbody2D.AddForce(LeftTrust * TrustForce);
				LeftTruster.gameObject.particleSystem.enableEmission = true; 
				TrusterFuelTank(); 
			}
				else
				{
				rigidbody2D.AddForce(RightTrust * TrustForce);
				RightTruster.gameObject.particleSystem.enableEmission = true;  
				TrusterFuelTank(); 
				}
			}
		else{RightTruster.gameObject.particleSystem.enableEmission = false;}
		if(Input.touchCount > 0  && Input.GetTouch(0).position.x < Screen.width/2)
			{
			if(Input.touchCount > 1)
			{
				rigidbody2D.AddForce(RightTrust * TrustForce);
				RightTruster.gameObject.particleSystem.enableEmission = true;  
				TrusterFuelTank(); 
				rigidbody2D.AddForce(LeftTrust * TrustForce);
				LeftTruster.gameObject.particleSystem.enableEmission = true; 
				TrusterFuelTank(); 
			}
				else
				{
				rigidbody2D.AddForce(LeftTrust * TrustForce);
				LeftTruster.gameObject.particleSystem.enableEmission = true; 
				TrusterFuelTank();
				} 
		}
			else{LeftTruster.gameObject.particleSystem.enableEmission = false; }
			
			}
		}*/
	}
	
	public void TrustRight() {
		Debug.Log ("ThrustRight");
	}

}
