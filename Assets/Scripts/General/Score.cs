using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    static double score = 0; 
    public Text labelScore = null; 
    public int pointPerSecond = 1; 
      
    void Update() {

        addPoints(Time.deltaTime * pointPerSecond); // add percet of points by time
        labelScore.text = getTemplateUpdated(); 
    }

    /// <summary>
    /// Template for text Score
    /// </summary>
    /// <returns>Temple String of Score</returns>
    string getTemplateUpdated()
    {
        return "ÌScore-" + ((int)score).ToString() + "Í";
    }

    /// <summary>
    /// Method to add Points to the Score this must call by whatever action to add points
    /// </summary>
    /// <param name="points"></param>
    public static void addPoints(float points) {
        score += points;
    }

}
