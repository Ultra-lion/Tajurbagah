using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DensityController : MonoBehaviour
{
    public TextMeshPro textMeshProDensity;
    public TextMeshPro textMeshProWeightInAir;
    public TextMeshPro textMeshProWeightInWater;
    bool bobWeighted = false;
    bool bobWeightedInWater = false;

    // Start is called before the first frame update
    void Start()
    {
        //textMeshProWeightInAir.SetText("{0} g", WeightController.bobWeight);   
    }

    // Update is called once per frame
    void Update()
    {
        if((WeightController.bobWeighted || SpringBalanceController.bobWeighted) && bobWeighted == false)
        {
            if(SpringBalanceController.bobWeighted)
                textMeshProWeightInAir.SetText("Weight in Air = {0} g", SpringBalanceController.bobWeight);    
            else
                textMeshProWeightInAir.SetText("Weight in Air = {0} g", WeightController.bobWeight);
            bobWeighted = true;
        }
        if ((WeightController.bobWeightedinWater || SpringBalanceController.bobWeightedinWater) && bobWeightedInWater == false)
        {
            if (SpringBalanceController.bobWeightedinWater)
            {
                textMeshProWeightInWater.SetText("Weight in Water = {0} g", SpringBalanceController.bobWeightInWater);
                textMeshProDensity.SetText("Density = {0} g / cm^3", SpringBalanceController.density);
            }
            else
            {
                textMeshProWeightInWater.SetText("Weight in Water = {0} g", WeightController.bobWeightInWater);
                textMeshProDensity.SetText("Density = {0} g / cm^3", WeightController.density);
            }
            bobWeightedInWater = true;
        }
    }
}
