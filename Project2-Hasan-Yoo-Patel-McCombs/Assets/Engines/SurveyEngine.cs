using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyEngine : MonoBehaviour
{
    int experienceRating;
    int anxietyRating;
    string AnxietyLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SliderOneValue(int val)
    {
        experienceRating = val;
    }

    public void SliderTwoValue(int val)
    {
        anxietyRating = val;
    }

    public void ImprovedButtonClicked()
    {
        AnxietyLevel = "Improved";
    }

    public void WorsenedButtonClicked()
    {
        AnxietyLevel = "Worsened";
    }

    public void SubmitButtonPressed()
    {
        PlayerPrefs.SetInt("experienceRating", experienceRating);
        PlayerPrefs.SetInt("anxietyRating", anxietyRating);
        PlayerPrefs.SetString("AnxietyLevel", AnxietyLevel);
    }
}
