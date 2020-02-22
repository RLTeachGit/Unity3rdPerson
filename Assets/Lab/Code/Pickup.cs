using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable CS0649  //Stop the warning about no assignment, as it will be assigned in IDE

public class Pickup : MonoBehaviour
{
    public float Speed=360.0f;
    
    // Add RB & set it to Kinematic
    void Start()
    {
        Rigidbody tRB=gameObject.AddComponent<Rigidbody>();
        Debug.Assert(tRB != null, "Cannot attach RB, may be duplicate, so remove any added in IDE");
        tRB.isKinematic = true; //Make it non physics

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Speed * Time.deltaTime, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("{1} Triggered by {0}", other.gameObject.name,gameObject.name);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("{1} Collided with {0}", collision.gameObject.name,gameObject.name);
    }

}
