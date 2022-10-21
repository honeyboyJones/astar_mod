using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Text outOfTrack;
    public FirstGridScript gridScript;
    public FollowAStarScript princessInfo;
    //adjust the value to control the difficulty
    private float movingSpeed = 5f;
    public float grassMutiplier = 10f;
    public float rockMutiplier = 5f;
    public float waterMutiplier = 1f;
    public float forestMutiplier = 2f;
    public float lavaMutiplier = 0.1f;
    public float pathMutiplier = 2f;
    public float interMultiplier = 10f;
    // Start is called before the first frame update
    void Start()
    {
        gridScript = FindObjectOfType<FirstGridScript>();
        princessInfo = FindObjectOfType<FollowAStarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MovingInput();
        RaycastCheck();
        ChangeSpeed();
    }

    public void test() 
    {
        transform.position = princessInfo.startPos.gameObject.GetComponent<Transform>().position;

    }

    //for checking the block player is walking on
    public Material RaycastCheck() 
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity ))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            outOfTrack.enabled = false;
            return hit.transform.GetComponent<MeshRenderer>().material;
        }
        //if not hit anything, player is out of track
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            interMultiplier = 0.1f;
            outOfTrack.enabled = true;
            return null;
        }
    }

    


    //change speed based on material
    public void ChangeSpeed() 
    {
        if (RaycastCheck() != null)
        {
            //use material to get the block type player is now on
            string matName = RaycastCheck().name;
            switch (matName) 
            {
                case "Grass (Instance)":
                    interMultiplier = grassMutiplier;
                    break;
                case "Water (Instance)":
                    interMultiplier = waterMutiplier;
                    break;
                case "Forest (Instance)":
                    interMultiplier = forestMutiplier;
                    break;
                case "Rock (Instance)":
                    interMultiplier = rockMutiplier;
                    break;
                case "Lava (Instance)":
                    interMultiplier = lavaMutiplier;
                    break;
                case "Path (Instance)":
                    interMultiplier = pathMutiplier;
                    break;
            }
        }
       
    }


    //define the input for players to move the character
    public void MovingInput() 
    {
        Vector3 posNow;
        posNow = transform.position;
        float adjustedSpeed = movingSpeed * interMultiplier;
        if (Input.GetKey(KeyCode.W))
        {
            //move up
            posNow.y += adjustedSpeed * Time.deltaTime;
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Move down
            posNow.y -= adjustedSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Move left
            posNow.x -= adjustedSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            //Move right
            posNow.x += adjustedSpeed * Time.deltaTime;
        }

        transform.position = posNow;//set the pos of player
    }

    
}
