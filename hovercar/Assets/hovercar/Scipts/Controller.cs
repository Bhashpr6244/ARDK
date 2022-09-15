using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<GameObject> springs;
    public Rigidbody rb;
    public GameObject prom;
    public GameObject cm;

    // Start is called before the first frame update
    void Start()
    {

        rb.centerOfMass = cm.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * 400f, prom.transform.position);
        rb.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * 300f);
        foreach (GameObject spring in springs)
        {
            RaycastHit hit;

            if (Physics.Raycast(spring.transform.position, transform.TransformDirection(Vector3.down), out hit, 3F))
            {
                rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(3f - hit.distance, 2) / 3F
                * 250f, spring.transform.position);

            }
            
            rb.AddForce(Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(rb.velocity).x * 5f);

        }

    }
}
