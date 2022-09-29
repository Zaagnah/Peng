
using UnityEngine;

public class FireReactionProperties : MonoBehaviour {

    public float FireIncreaseWood { get { return fireIncreasesWoodOnTouch; } }
    [SerializeField]
    private float fireIncreasesWoodOnTouch = 10f;

    public float FireIncreasesWater { get { return fireIncreasesWaterOnTouch; } }
    [SerializeField]
    private float fireIncreasesWaterOnTouch= 5f;

    public float FireIncreasesIceOnTouch { get { return fireIncreasesIceOnTouch; } }
    [SerializeField]
    private float fireIncreasesIceOnTouch= 3f;

    public float WoodIncreasesFire { get { return woodIncreasesFireOnTouch; } }
    [SerializeField]
    private float woodIncreasesFireOnTouch= 1f;

    public float WaterDecreasesFire { get { return waterDecreasesFireOnTouch; } }
    [SerializeField]
    private float waterDecreasesFireOnTouch= 10f;

    public float IceDecreasesFire { get { return iceDecreasesFireOnTouch; } }
    [SerializeField]
    private float iceDecreasesFireOnTouch = 10f;
}
