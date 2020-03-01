using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson; //Needed for Controller stuff

#pragma warning disable CS0649  //Stop the warning about no assignment, as it will be assigned in IDE

public class Pickup : MonoBehaviour
{
    public float Speed=360.0f;

    [SerializeField]
    int Score = 10;


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


    private void OnTriggerEnter(Collider vOtherCol)
    {
        Debug.LogFormat("{1} Triggered by {0}", vOtherCol.gameObject.name,gameObject.name);
        ThirdPersonCharacter tOther = vOtherCol.GetComponent<ThirdPersonCharacter>();
        if(tOther!=null) //Check its player
        {
            DealWithPickup(tOther);   //Call pickup handler
        }
    }

    private void OnCollisionEnter(Collision vOtherCol)
    {
        Debug.LogFormat("{1} Collided with {0}", vOtherCol.gameObject.name,gameObject.name);
        ThirdPersonCharacter tOther = vOtherCol.gameObject.GetComponent<ThirdPersonCharacter>();
        if (tOther != null) //Check its player
        {
            DealWithPickup(tOther);   //Call pickup handler
        }
    }

    void DealWithPickup(ThirdPersonCharacter vPlayer)
    {
        GM.Score += Score;
        Destroy(gameObject);
    }

}
