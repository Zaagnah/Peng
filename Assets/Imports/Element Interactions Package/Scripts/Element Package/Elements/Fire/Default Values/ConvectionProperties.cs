
using UnityEngine;

public class ConvectionProperties : MonoBehaviour {

    public float RateOfFireSpread { get { return catchOnFireRate; } }
    [SerializeField]
    private float catchOnFireRate = 3f;

    public float HeatAddedWhileBurning { get { return heatAmount; } }
    [SerializeField]
    float heatAmount = 1f;

    public float BurnRate { get { return burnRate; } }
    [SerializeField]
    float burnRate = 1.5f;

    public float IncreasedWoodAmount { get { return increaseWoodTempAmount; } }
    [SerializeField]
    float increaseWoodTempAmount = 3f;

    public float IncreaseWaterTempAmount { get { return increaseWaterTempAmount; } }
    [SerializeField]
    float increaseWaterTempAmount = 1f;

    public float IncreaseIceTempAmount { get { return increaseIceTempAmount; } }
    [SerializeField]
    float increaseIceTempAmount = 1f;

    public Vector2 FireSpreadRandomRange { get { return fireSpreadRandomRange; } }
    [SerializeField]
    private Vector2 fireSpreadRandomRange = new Vector2(3, 6);

    public float FireSpreadRadius { get { return fireSpreadRadius; } }
    [SerializeField]
    private float fireSpreadRadius = 2;

    public LayerMask IgnoreLayers { get { return ignoreLayers; } }
    [SerializeField]

    private LayerMask ignoreLayers = 17;
}
