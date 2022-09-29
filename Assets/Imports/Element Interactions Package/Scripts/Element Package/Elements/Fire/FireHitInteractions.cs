
using UnityEngine;

public class FireHitInteractions : MonoBehaviour
{
    SetFireHitReactionValues getValues;

    private float fireIncreasesWoodOnTouch;// = 10f;
    private float fireIncreasesWaterOnTouch;// = 5f;
    private float fireIncreasesIceOnTouch;// = 3f;
    private float woodIncreasesFireOnTouch;// = 1f;
    private float waterDecreasesFireOnTouch;// = 10f;
    private float iceDecreasesFireOnTouch;// = 10f;


    private void Start()
    {
        AssignFireHitReactionValues();
    }

    void AssignFireHitReactionValues()
    {
        if (this.gameObject.GetComponent<SetFireHitReactionValues>() == null)
        {

            getValues = this.gameObject.AddComponent<SetFireHitReactionValues>();
        }
        else
        {
            getValues = this.gameObject.GetComponent<SetFireHitReactionValues>();
        }
        getValues.SetValues();
        GetReactionValues(getValues);
    }

    void GetReactionValues(SetFireHitReactionValues values)
    {
        fireIncreasesWoodOnTouch = values.FireIncreaseWood;
        fireIncreasesWaterOnTouch = values.FireIncreasesWater;
        fireIncreasesIceOnTouch = values.FireIncreasesIceOnTouch;
        woodIncreasesFireOnTouch = values.WoodIncreasesFire;
        iceDecreasesFireOnTouch = values.IceDecreasesFire;
    }


    public void HandleFireCollisions(ElementType elementThatHit, Collider other)
    {
        if (this.gameObject.GetComponent<TempGauge>() != null)
        {
            if (elementThatHit == ElementType.Fire)
            {
                return;
            }
            if (elementThatHit == ElementType.Wood)//if wood hit fire
            {
                other.GetComponent<TempGauge>().IncreaseTemp(woodIncreasesFireOnTouch);
                this.gameObject.GetComponent<TempGauge>().IncreaseTemp(fireIncreasesWoodOnTouch);//increase wood temp
            }

            if (elementThatHit == ElementType.Water)//if water hit fire
            {
                other.gameObject.GetComponent<TempGauge>().DecreaseTemp(waterDecreasesFireOnTouch);
                this.gameObject.GetComponent<TempGauge>().IncreaseTemp(fireIncreasesWaterOnTouch);

            }

            if (elementThatHit == ElementType.Ice)//if ice hit fire
            {
                other.gameObject.GetComponent<TempGauge>().DecreaseTemp(iceDecreasesFireOnTouch);
                this.gameObject.GetComponent<TempGauge>().IncreaseTemp(fireIncreasesIceOnTouch);
                //Debug.Log("Hit Ice");

            }
        }
        else
        {
            Debug.Log(this.gameObject.name + " needs an ELEMENT Ice, Water, or Fire to interact");
        }
    }
    public void HandleFireCollisions(ElementType elementThatHit, Collision collision)
    {
        if (this.gameObject.GetComponent<TempGauge>() != null)
        {
            if (elementThatHit == ElementType.Fire)
            {
                return;
            }
            if (elementThatHit == ElementType.Wood)//if wood hit fire
            {
                collision.collider.gameObject.GetComponent<TempGauge>().IncreaseTemp(woodIncreasesFireOnTouch);
                this.gameObject.GetComponent<TempGauge>().IncreaseTemp(fireIncreasesWoodOnTouch);//increase wood temp
            }

            if (elementThatHit == ElementType.Water)//if water hit fire
            {
                collision.collider.gameObject.GetComponent<TempGauge>().DecreaseTemp(waterDecreasesFireOnTouch);
                this.gameObject.GetComponent<TempGauge>().IncreaseTemp(fireIncreasesWaterOnTouch);
                
            }

            if (elementThatHit == ElementType.Ice)//if ice hit fire
            {
                collision.collider.gameObject.GetComponent<TempGauge>().DecreaseTemp(iceDecreasesFireOnTouch);
                this.gameObject.GetComponent<TempGauge>().IncreaseTemp(fireIncreasesIceOnTouch);
                //Debug.Log("Hit Ice");

            }
        }
        else
        {
            Debug.Log(this.gameObject.name + " needs an ELEMENT Ice, Water, or Fire to interact");
        }
    }
}


