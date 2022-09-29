
using UnityEngine;

public class SetFireSpreadValues : MonoBehaviour {

    public float CatchOnFireRate { get { return catchOnFireRate; } }
    [SerializeField]
    float catchOnFireRate;

    public float IncreasedWoodAmount { get { return increaseWoodTempAmount; } }
    [SerializeField]
    float increaseWoodTempAmount;

    public float IncreaseWaterTempAmount { get { return increaseWaterTempAmount; } }
    [SerializeField]
    float increaseWaterTempAmount;

    public float IncreaseIceTempAmount { get { return increaseIceTempAmount; } }
    [SerializeField]
    float increaseIceTempAmount;

    public Vector2 FireSpreadRandomRange { get { return fireSpreadRandomRange; } }
    [SerializeField]
    private Vector2 fireSpreadRandomRange;

    public float FireSpreadRadius { get { return fireSpreadRadius; } }
    [SerializeField]
    private float fireSpreadRadius;

    public LayerMask IgnoreLayers { get { return ignoreLayers; } }
    [SerializeField]
    private LayerMask ignoreLayers;


    public void SetValues()
    {
        if (GameObject.FindGameObjectWithTag("FireManager") == null)
        {
            if (this.gameObject.GetComponent<ConvectionProperties>() !=null)
            {
                ConvectionProperties values = this.gameObject.GetComponent<ConvectionProperties>();
                SetFireConvectValues(values);
            }
            else
            {
                ConvectionProperties values = this.gameObject.AddComponent<ConvectionProperties>() as ConvectionProperties;
                SetFireConvectValues(values);
            }
        }else
        {
            if (this.gameObject.GetComponent<ConvectionProperties>() == null)
            {
                ConvectionManager values = GameObject.FindGameObjectWithTag("FireManager").GetComponentInChildren<ConvectionManager>() as ConvectionManager;
                SetFireConvectValues(values);

            }else
            {
                ConvectionProperties values = this.gameObject.AddComponent<ConvectionProperties>() as ConvectionProperties;
                SetFireConvectValues(values);
            }
           
        }
    }

    void SetFireConvectValues(ConvectionProperties values)
    {
        catchOnFireRate = values.RateOfFireSpread;
        increaseWoodTempAmount = values.IncreasedWoodAmount;
        increaseWaterTempAmount = values.IncreaseWaterTempAmount;
        increaseIceTempAmount = values.IncreaseIceTempAmount;
        fireSpreadRandomRange = values.FireSpreadRandomRange;
        fireSpreadRadius = values.FireSpreadRadius;
        //ignoreLayers = 17;
        ignoreLayers = GetComponent<Element>().ElementLayer ;


}
    void SetFireConvectValues(ConvectionManager values)
    {
        catchOnFireRate = values.catchOnFireRate;
        increaseWoodTempAmount = values.increaseWoodTempAmount;
        increaseWaterTempAmount = values.increaseWaterTempAmount;
        increaseIceTempAmount = values.increaseIceTempAmount;
        fireSpreadRandomRange = values.FireSpreadRandomRange;
        fireSpreadRadius = values.FireSpreadRadius;
        ignoreLayers = GetComponent<Element>().ElementLayer;
    }
}
