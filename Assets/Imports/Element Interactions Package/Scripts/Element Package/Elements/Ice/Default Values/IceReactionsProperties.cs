
using UnityEngine;

public class IceReactionsProperties : MonoBehaviour {

    public float IceIncreasesIce { get { return iceIncreasesIce; } }
    float iceIncreasesIce = 1f;
    public float IceDecreasesWoodOnTouch { get { return iceDecreasesWoodOnTouch; } }
    float iceDecreasesWoodOnTouch = 1f;
    public float IceDecreasesWaterOnTouch { get { return iceDecreasesWaterOnTouch; } }
    float iceDecreasesWaterOnTouch = 1f;
    public float IceDecreasesFireOnTouch { get { return iceDecreasesFireOntouch; } }
    float iceDecreasesFireOntouch = 1f;

    public Vector3 MeltingScale { get { return meltExpansion; } }
    Vector3 meltExpansion = new Vector3(.5f, -.5f, .5f);//new scale when water turns to ice
    public float SpeedOfMelt { get { return speedOfMelt; } }
    private float speedOfMelt = 2f;
}
