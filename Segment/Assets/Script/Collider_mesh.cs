using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cuttermesh;
using Niantic.ARDK.Extensions;
public class Collider_mesh : MonoBehaviour
{
	public GameObject rootobject;


    

    void OnTriggerEnter(Collider other)
    {


        Vector3 pos = other.ClosestPoint(transform.position);
        pos -= rootobject.transform.position;

        rootobject.transform.GetChild(1).gameObject.transform.position = new Vector3(pos.x,0,pos.z);

        if (rootobject.transform.GetChild(0).gameObject.transform.localScale.y == 2F)
        {


            if (other.transform.parent.transform.position.y > -0.8f)
            {

                rootobject.transform.GetChild(1).gameObject.GetComponent<Blade>().OnCuttermesh(other.gameObject);

            }
           else if (rootobject.transform.position.y < other.transform.parent.gameObject.transform.position.y)
            {

                ARPlaneManager.instant.RemoveAnchor(rootobject.gameObject.GetComponent<PlanefindingGrid>().tempAnchor);

            }
          
            
        }

    } 
    
}

