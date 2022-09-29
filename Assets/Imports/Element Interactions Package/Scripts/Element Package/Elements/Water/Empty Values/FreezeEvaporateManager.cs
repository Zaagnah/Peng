
using UnityEngine;

public class FreezeEvaporateManager : MonoBehaviour {


    [Header("Scaling options for freezing and evaporating")]
    [Header("use negative numbers to decrease size")]
    public Vector3 expandToIce;
    public Vector3 evaporate;
    public float speedOfEvaporation;
    public float iceExpandTime;
}
