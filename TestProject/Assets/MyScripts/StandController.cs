using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "BeakerObj")
        {
            Debug.Log("Beaker on stand");
            GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(5, true);
            GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(6, false);
        }
    }
}
