using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZHueristic : HueristicScript
{
    public GridScript gridScript;

    //parameter to define a straight line
    public float k =-1f;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
        gridScript = FindObjectOfType<GridScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override float Hueristic(int x, int y, Vector3 start, Vector3 goal, GridScript gridScript)
    {
        GameObject[,] pos;
        pos = gridScript.GetGrid();
        float cost = gridScript.GetMovementCost(pos[x, y]);


        //cal the return value based on importance of cost
        float hueVal = k * cost ;



        return hueVal;
    }
    
    


}
