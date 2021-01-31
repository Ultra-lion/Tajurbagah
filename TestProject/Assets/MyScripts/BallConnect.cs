using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bob")
        {
            Debug.Log("Bob on Spring");
            other.gameObject.AddComponent<FixedJoint>();
            other.gameObject.GetComponent<FixedJoint>().connectedBody = GetComponent<Rigidbody>();
            //other.attachedRigidbody.position = transform.position;

        }
    }
}
