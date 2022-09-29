
using UnityEngine;

public class FireHitTemperatureReactionsManager : MonoBehaviour {

    [Header("These are ON TOUCH Values")]
    [Header("Increase Amounts")]
    public float fireIncreasesWoodOnTouch;// = 10f;
    public float fireIncreasesWaterOnTouch;// = 5f;
    public float fireIncreasesIceOnTouch;// = 3f;
    public float woodIncreasesFireOnTouch { get { return GameObject.FindGameObjectWithTag("WoodManager").GetComponentInChildren<WoodHitTemperatureReactionsManager>().WoodIncreasesFire; } }// = 1f;

    //[Header("Decrease Amounts")]
    public float waterDecreasesFireOnTouch
    { get { return GameObject.FindGameObjectWithTag("WaterManager").GetComponentInChildren<WaterHitTemperatureReactionsManager>().WaterDecreasesFire; } }// = 10f;
    public float iceDecreasesFireOnTouch
    { get { return GameObject.FindGameObjectWithTag("IceManager").GetComponentInChildren<IceHitTemperatureReactionsManager>().IceDecreasesFireOnTouch; } }


}
