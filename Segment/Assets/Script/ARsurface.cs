using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.ARDK.Extensions;
using UnityEngine.UI;



public class ARsurface : MonoBehaviour
{

    public Text txtcollider;
    public static ARsurface instance;
    public GameObject colliderprefabs;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {

            instance = this;
       
        }
        else {

            Destroy(gameObject);
        
        }
        
    }

    public void regidbody()
    {
       // colliderprefabs.GetComponent<Rigidbody>().isKinematic = false;

    }
    // Update is called once per frame

    void  Update()
    {
      // StartCoroutine(checkcollider());
    }

    public void  checkcollider()
    {
           
           
            foreach (var plane in ARPlaneManager.instant.temparraylist)
            {
              
                //  StartCoroutine(plane.transform.GetChild(1).gameObject.GetComponent<Blade>());              
               
                    // if (plane.transform.position.x == ARPlaneManager.instant.temparraylist[i].transform.position.x
                    //      && ARPlaneManager.instant.temparraylist[i].transform.position.y < plane.transform.position.y)
                   
                   /// if (plane.GetComponent<PlanefindingGrid>().tempAnchor.Alignment.ToString().Equals("Horizontal") 
              //  && plane.active)
                   // {

                     //   var planprefabs = Instantiate(colliderprefabs, new Vector3( plane.transform.position.x, plane.transform.position.y - 0.1f, plane.transform.position.z),Quaternion.identity);                     
                      //  planprefabs.AddComponent<Collider_mesh>().rootobject=plane;
                         
                   // }                
              
            }

    }

}
