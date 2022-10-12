using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {

        GetComponent<ConfigurableJoint>().connectedBody = other.transform.gameObject.GetComponent<Rigidbody>();

    }

}
