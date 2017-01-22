using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static double score = 20;
    public Text labelScore = null;
    public int pointPerSecond = 1;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        addPoints(Time.deltaTime * pointPerSecond);
        labelScore.text = changeText();
    }

    string changeText()
    {
        return "ÌScore-" + ((int)score).ToString() + "Í";
    }

    public static void addPoints(float points) {
        score += points;
    }

}
