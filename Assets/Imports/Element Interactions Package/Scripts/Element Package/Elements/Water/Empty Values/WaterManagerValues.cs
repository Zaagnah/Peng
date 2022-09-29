
using UnityEngine;

public class WaterManagerValues : MonoBehaviour {
    [Header("These are RELATIVE Values")]
    [Header("A Temp of 0 is the starting Temp of all elements")]

    [Header("These are triggers for events")]
    public float freezeTemp;
    public float burnTemp;

    [Header("These are properties for clamping")]
    public float minTemp;
    public float maxTemp;
    public float nextTouchRate;

    /**
    [Header("Scaling options for freezing and evaporating")]
    [Tooltip("1, 1, 1 is the original scale")]
    public Vector3 ExpandToIce;
    public Vector3 evaporate;
    public float speedOfEvaporation;**/
}
