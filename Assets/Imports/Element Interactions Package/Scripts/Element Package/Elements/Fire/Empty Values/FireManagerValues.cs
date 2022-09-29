
using UnityEngine;

public class FireManagerValues : MonoBehaviour {


    [Header("These are RELATIVE Values")]
    [Header("A Temp of 0 is the starting Temp of all elements")]

    [Header("These are triggers for events")]
    public float freezeTemp;
    public float burnTemp;

    [Header("These are properties for clamping")]
    public float minTemp;
    public float maxTemp;
    public float nextTouchRate;

}
