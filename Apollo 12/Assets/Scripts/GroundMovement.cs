using UnityEngine;
using System.Collections;

public class GroundMovement : MonoBehaviour {
	
	public bool GroundMoving = false; 
	public float GroundSpeed = 0.1f; 
	public float GroundPos; 
	public GameObject GroundPrefab; 
	public GameObject FlatPrefab; 
	public bool CreatedGround = false;
	public int FlatRatio = 65; 
	
	// Use this for initialization
	void Start () {
	
	GroundPos = this.transform.position.x; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GroundMoving){MovingGround();}
		if(this.transform.position.x >= -8f && CreatedGround == false)
		{
			int Groundomizer = Random.Range(1, 100); 
			if(Groundomizer > FlatRatio)
			{
				Instantiate(FlatPrefab, new Vector3(this.transform.position.x-4.1f, -2.8f, -9), this.transform.rotation);
				CreatedGround = true; 
			}
			else
			{
			Instantiate(GroundPrefab, new Vector3(this.transform.position.x-4.1f, -2.8f, -9), this.transform.rotation);
			CreatedGround = true; 
			}
		}
		if(this.transform.position.x >= 10f && CreatedGround == true)
		{
			Destroy(this.gameObject);
		}
	}
	public void MovingGround()
	{
		transform.Translate(new Vector2(GroundSpeed, 0)); 
		
	}
}
