
using UnityEngine;

public class ConvectionManager : MonoBehaviour {
    [Header("Rate at which fires catch")]
    public float catchOnFireRate;



   [Header("Convection Heat")]
    public float increaseWoodTempAmount;
    public float increaseWaterTempAmount;
    public float increaseIceTempAmount;


    [Header("Fire Spreading Properties")]
    [Tooltip("Range Between Seconds")]
    public Vector2 FireSpreadRandomRange;
    public float FireSpreadRadius;
    //[Tooltip("Check Mark means it checks that layer. Elements is a must")]
    //public LayerMask IgnoreLayers;

   
}
