using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerController : MonoBehaviour
{
    public static bool bobInBeaker = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().mass = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(bobInBeaker)
        {
            WeightController.bobInBeaker = true;
           // GetComponent<Rigidbody>().mass = GetComponent<Rigidbody>().mass + (WeightController.bobWeight/10.0f);
        }
        bobInBeaker = false;
    }

    private void OnDestroy()
    {
        WeightController.bobInBeaker = false;
        GetComponent<Rigidbody>().mass = 10;
        bobInBeaker = false;

    }

}
