using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interfaces  
{

  

   public float RandomSpeed()
   {
        return Random.Range(5, 12);
   }


    public float RandomPlayerGravity()
    {

        return Random.Range(1, 10);
        
    }
  


}

