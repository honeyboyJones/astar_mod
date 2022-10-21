using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject toad;
    
    void OnTriggerEnter(Collider player)
    {
        //player wins
        //princess loses
        
        print("YOU WIN");
        
        //messageText.text = "YOU WIN";
    }

    // void OnTriggerEnter(Collider princess)
    // {
    //     //princess wins
    //     //player loses
    //     
    //     messageText.text = "YOU LOSE";
    // }
}
