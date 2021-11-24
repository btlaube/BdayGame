using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Text score;
    public float numFollowers;
    private float scoreCount = 0f;

    public float getNumFollowers() {
        return numFollowers;
    }

    public void addFollower() {
        numFollowers++;
        scoreCount++;
        score.text = "Letters: " + scoreCount + "/12";
    }

    public void setFollowers(int numFollowers) {
        this.numFollowers = numFollowers;
    }

}
