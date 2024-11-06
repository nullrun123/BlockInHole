using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
       public static LevelManager levelManager;
    private int step;
    public int stepToCreateMoreLanes = 12;
    private int currentStep;
    public Text stepText;
    // Update is called once per frame
     void Awake()
    {
        levelManager = this;
    }

    public void SetStep()
    {
        step++;
        stepText.text = step.ToString();
        currentStep++;
        if(currentStep > stepToCreateMoreLanes)
        {
            currentStep = 0;
            
        }
    }
}
