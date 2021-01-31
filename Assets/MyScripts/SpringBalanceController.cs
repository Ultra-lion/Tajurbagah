using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpringBalanceController : MonoBehaviour
{
    float weight = 0.0f;
    public static float bobWeight = 20.0f;
    public static float bobWeightInWater = 0.0f;
    public static float density = 0.0f;
    public static bool bobInBeaker = false;
    bool BeakerBobOnScale = false;
    public TextMeshPro textMeshPro;
    public TextMeshPro textMeshProDensity;
    public static bool bobWeighted = false;
    public static bool bobWeightedinWater = false;

    // Start is called before the first frame update
    void Start()
    {
        weight = bobWeight;
        textMeshPro.SetText("{0}g", weight);
        bobWeighted = true;
        //Tajurbah_Gah.StepsLabelController.UpdateStep(0,false);
        GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(0,true);
        GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(1, false);

    }

    // Update is called once per frame
    void Update()
    {
        if(WaterCollision.bobinBeaker && bobInBeaker==false)
        {
            bobWeightInWater = bobWeight / 2.5f;
            weight = bobWeightInWater;
            density = bobWeight / (bobWeight - bobWeightInWater);
            bobWeightedinWater = true;
            bobInBeaker = true;
            GameObject.Find("Steps Tab").GetComponent<Tajurbah_Gah.StepsLabelController>().UpdateStep(1, true);
        }
        else if(WaterCollision.bobinBeaker==false && bobInBeaker)
        {
            weight = bobWeight;
            bobInBeaker = false;
        }
        textMeshPro.SetText("{0}g", weight);
    }
}
