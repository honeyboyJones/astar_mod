using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowAStarScript : MonoBehaviour {

	//ref of player
	public PlayerController player;

	protected bool move = false;

	protected Path path;
	public AStarScript astar;
	public Step startPos;
	public Step destPos;

	protected int currentStep = 1;

	protected float lerpPer = 0;
	
	protected float startTime;
	protected float travelStartTime;

	// Use this for initialization
	protected virtual void Start () {

		//get player instance in the scene
		player = FindObjectOfType<PlayerController>();


		path = astar.path;
		startPos = path.Get(0);
		destPos  = path.Get(currentStep);

		transform.position = startPos.gameObject.transform.position;

		//set the player to the same pos as the princess
		player.gameObject.GetComponent<Transform>().position = startPos.gameObject.GetComponent<Transform>().position + new Vector3(0,0,-1);


//		Debug.Log(path.nodeInspected/100f);

		Invoke("StartMove", path.nodeInspected/100f);

		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		if(move){
			lerpPer += Time.deltaTime/destPos.moveCost;

			transform.position = Vector3.Lerp(startPos.gameObject.transform.position, 
			                                  destPos.gameObject.transform.position, 
			                                  lerpPer);

			if(lerpPer >= 1){
				lerpPer = 0;

				currentStep++;

				if(currentStep >= path.steps){
					currentStep = 0;
					move = false;
					Debug.Log(path.pathName + " got to the goal in: " + (Time.realtimeSinceStartup - startTime));
					Debug.Log(path.pathName + " travel time: " + (Time.realtimeSinceStartup - travelStartTime));
				} 

				startPos = destPos;
				destPos = path.Get(currentStep);
			}
		}
	}

	protected virtual void StartMove(){
		move = true;
		travelStartTime = Time.realtimeSinceStartup;
	}
}

