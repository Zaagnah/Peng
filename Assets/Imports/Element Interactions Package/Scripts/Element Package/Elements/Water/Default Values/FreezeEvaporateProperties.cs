
using UnityEngine;

public class FreezeEvaporateProperties : MonoBehaviour {


    public Vector3 ExpandToIce { get { return expandToIce; } }
    Vector3 expandToIce = new Vector3(-.5f, .5f, -.5f);

    public Vector3 Evaporate { get { return evaporate; } }
    Vector3 evaporate = new Vector3(-.5f, -.5f, -.5f);

    public float SpeedOfEvaporation { get { return speedOfEvaporation; } }
    float speedOfEvaporation = 1f;

    public float IceExpandTime { get { return iceExpandTime; } } 
    float iceExpandTime = .5f;
}
