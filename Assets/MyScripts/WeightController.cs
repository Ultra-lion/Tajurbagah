using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeightController : MonoBehaviour
{
    float weight=0.0f;
    public static float bobWeight=20.0f;
    public static float bobWeightInWater = 0.0f;
    public static float density = 0.0f;
    public static bool bobInBeaker = false;
    bool BeakerBobOnScale = false;
    public TextMeshPro textMeshPro;
    public TextMeshPro textMeshProDensity;
    public static bool bobWeighted = false;
    public static bool bobWeightedinWater = false;
    bool stepdone = false;


    // Start is called before the first frame update
    void Start()
    {
        //textMeshPro.SetText("The first number is {0} and the 2nd is {1:2} and the 3rd is {3:0}.", 4, 6.345f, 3.5f);
        textMeshPro.SetText("{0} g", weight);
        GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(0, true);
        GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(1, false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.rigidbody.tag=="BeakerObj")
        {
            Debug.Log("Beaker on Weight Scale");
            if (bobInBeaker)
            {
                if (collision.rigidbody.mass == 10 && BeakerBobOnScale == false)
                {
                    bobWeightInWater = bobWeight / 2.5f;
                    collision.rigidbody.mass += ((bobWeight / 10.0f) / 2.5f);
                    density = bobWeight / (bobWeight - bobWeightInWater);
                    textMeshProDensity.SetText("{0} g", density);
                    BeakerBobOnScale = true;
                    bobWeightedinWater = true;
                }
            }
            float beakerWeight = (collision.rigidbody.mass * 10);
            weight = weight + beakerWeight;
            textMeshPro.SetText("{0} g", weight);
        }

        if (collision.rigidbody.tag == "Bob")
        {
            Debug.Log("Bob on Weight Scale");
            weight = weight + bobWeight;
            textMeshPro.SetText("{0} g", weight);
            bobWeighted = true;
            GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(1, true);
            GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(2, false);
        }
        ///
        if (collision.rigidbody.tag == "WoodenBench")
        {
            Debug.Log("Wooden Bench on Weight Scale");
            weight += 500.0f;
            textMeshPro.SetText("{0} g", weight);
        }
        if (collision.rigidbody.tag == "WeightScale")
        {
            Debug.Log("Weight Scale on Weight Scale");
            weight = weight + (collision.rigidbody.mass * 10.0f);
            textMeshPro.SetText("{0} g", weight);
        }
        if (collision.rigidbody.tag == "Clamp")
        {
            Debug.Log("Clamp on Weight Scale");
            //weight += 150.0f;
            //collision.rigidbody.mass = collision.rigidbody.mass + (bobWeight / 10);
            float clampWeight = (collision.rigidbody.mass * 10);
            if(bobInBeaker)
            {
                bobWeightInWater = bobWeight / 2.5f;
                clampWeight = clampWeight - ((bobWeight - bobWeightInWater)/2);
                bobWeightedinWater = true;
                density = bobWeight / (bobWeight - bobWeightInWater);
                GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(6, true);
                //GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(7, false);
            }
            weight = weight + clampWeight;
            textMeshPro.SetText("{0} g", weight);
            if (stepdone == false)
            {
                GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(3, true);
                GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(4, false);
                stepdone = true;
            }
        }
        ///
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exited");
        if (collision.rigidbody.tag == "Table")
        {
            weight = 0.0f;
        }
        else if(collision.rigidbody.tag == "Clamp")
        {
            //weight = weight - 150.0f;
            weight = weight - (collision.rigidbody.mass * 10);
        }
        else
        {
            weight = weight - (collision.rigidbody.mass * 10);
        }
        if(collision.rigidbody.tag=="Bob")
        {
            GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(2, true);
            GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(3, false);
        }
        if (weight <= 0.0f)
            weight = 0.0f;
        textMeshPro.SetText("{0} g", weight);
    }
}
