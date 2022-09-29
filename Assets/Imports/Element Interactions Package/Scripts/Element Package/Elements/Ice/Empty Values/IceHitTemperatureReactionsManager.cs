
using UnityEngine;

public class IceHitTemperatureReactionsManager : MonoBehaviour {


    [Header("Decrease Reaction Values")]
    public float IceDecreasesWoodOnTouch;
    public float IceDecreasesWaterOnTouch;
    public float IceDecreasesFireOnTouch;

    [Header("Increase Reaction Values")]
    public float IceIncreasesIce;

    [Header("Values for ICE MELTING")]
    [Tooltip("this is the final scale of the ice object that melts to water")]
    public Vector3 meltingScale;
    public float speedOfMelt;


}
