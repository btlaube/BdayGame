using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float numFollowers;

    public float getNumFollowers() {
        return numFollowers;
    }

    public void addFollower() {
        numFollowers++;
    }
}
