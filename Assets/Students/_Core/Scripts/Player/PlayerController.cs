using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FirstGridScript gridScript;
    public FollowAStarScript princessInfo;
    private float movingSpeed = 5f;
    public float grassMutiplier = 10f;
    public float rockMutiplier = 5f;
    public float waterMutiplier = 1f;
    public float forestMutiplier = 2f;
    public float lavaMutiplier = 0.1f;

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
            Debug.Log(hit.transform.GetComponent<MeshRenderer>().material);
            return hit.transform.GetComponent<MeshRenderer>().material;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            return null;
        }
    }

    public void Goal()
    {
        if (RaycastCheck() != null)
        {
            string matName = RaycastCheck().name;

            if (matName == "Coin")
            {
                print("GOAL");
            }
        }
    }


    //change speed based on material
    public void ChangeSpeed() 
    {
        if (RaycastCheck() != null)
        {
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
