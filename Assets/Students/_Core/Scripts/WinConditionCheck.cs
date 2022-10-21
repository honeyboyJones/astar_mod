using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConditionCheck : MonoBehaviour
{
    public bool isPrincessArrived;
    public bool isPlayerArrived;
    public Text playerWin;
    public Text PrincessWin;

    // Start is called before the first frame update
    void Start()
    {
        playerWin.enabled = false;
        PrincessWin.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //use collision to determine if arrive at the goal pos
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) 
        {
            //player arrived
            isPlayerArrived = true;

            //player arrived before the princess
            if (!isPrincessArrived) 
            {
                //player wins
                Debug.Log("playerwins");
                playerWin.enabled = true;
            }
        }
        if (other.CompareTag("Princess"))
        {
            //pincess arrived
            isPrincessArrived = true;

            //princess arrived before the player
            if (!isPlayerArrived) 
            {
                //princess wins
                PrincessWin.enabled = true;
            }
        }
    }
}
