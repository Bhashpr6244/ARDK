using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{

    //private GameObject parentobject;
    private void Awake()
    {


       // parentobject = gameObject.transform.parent.transform.gameObject;
                   
    }



    public void OnCollisionEnter(Collision other)
    {
         if (other.transform.gameObject.tag != "Untagged" && other.transform.gameObject.tag == gameObject.tag)
          {

            Debug.Log(gameObject.tag);

            other.transform.gameObject.GetComponent<FixedJoint>().connectedBody = transform.parent.transform.gameObject.GetComponent<Rigidbody>();
            transform.parent.transform.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            
        }

    }

    public void OnCollisionExit(Collision other)
    {

        if (other.transform.gameObject.tag == gameObject.tag) {

            Debug.Log("exit"+gameObject.tag);
            other.transform.gameObject.GetComponent<FixedJoint>().connectedBody = null;
            transform.parent.transform.gameObject.GetComponent<BoxCollider>().isTrigger = false;

        }

    }

}
