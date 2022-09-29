
using UnityEngine;

public class FireSpreadTimer : MonoBehaviour {

    [SerializeField]
    float increaseWoodTempAmount;
    [SerializeField]
    float increaseWaterTempAmount;
    [SerializeField]
    float increaseIceTempAmount;

    [SerializeField]
    private LayerMask ignoreLayers; //= LayerMask.NameToLayer("Elements)");
    [SerializeField]
    private float fireSpreadRadius;
    [SerializeField]
    private Vector2 fireSpreadRandomRange;




    SetFireSpreadValues getValues;//code this in for a manager too
    bool startSpread;
    float fireSpreadRate;
    float nextFireSpread;
    CatchFire catchFire;//nec?

    void Start()
    {
        AssignValues();

        if (this.gameObject.GetComponent<CatchFire>() == null)
        {
            catchFire = this.gameObject.AddComponent <CatchFire>();
        }else
        {
            catchFire = GetComponent<CatchFire>();
        }
        //catchFire = GetComponentInParent<CatchFire>();
        GetNextFireSpreadRate();
        SetNextFireSpread();
    }

    void AssignValues()
    {
        if (this.gameObject.GetComponent<SetFireSpreadValues>() != null)
        {
            getValues = this.gameObject.GetComponent<SetFireSpreadValues>();
        }
        else
        {
            getValues = this.gameObject.AddComponent<SetFireSpreadValues>();
        }
        
        getValues.SetValues();
        GetConvectionValues(getValues);
    }
    void GetConvectionValues(SetFireSpreadValues values)
    {
        increaseWoodTempAmount = values.IncreasedWoodAmount;
        increaseWaterTempAmount = values.IncreaseWaterTempAmount;
        increaseIceTempAmount = values.IncreaseIceTempAmount;
        fireSpreadRadius = values.FireSpreadRadius;
        fireSpreadRandomRange = values.FireSpreadRandomRange;
        ignoreLayers = GetComponent<Element>().ElementLayer;
}

    void Update () {
        if (Time.time > nextFireSpread)
        {
            NextSpread();

        }else
        {
            startSpread = false;
        }
    }

    private void NextSpread()
    {
        
            startSpread = true;
        
            DoFireRangedSpread();
        GetNextFireSpreadRate();
        SetNextFireSpread();

    }

    private void GetNextFireSpreadRate()
    {
        fireSpreadRate = Random.Range(fireSpreadRandomRange.x, fireSpreadRandomRange.y);
    }
    private void SetNextFireSpread()
    {
        nextFireSpread = Time.time + fireSpreadRate;

    }

    private void DoFireRangedSpread()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, fireSpreadRadius, ignoreLayers);

        foreach (var collider in hitColliders)
        {
            if (collider.GetComponent<Element>() != null)
            {
                ElementType element = collider.gameObject.GetComponent<Element>().CurrentType;

                Vector3 contact = collider.ClosestPoint(this.gameObject.transform.position);
                //Debug.Log(contact + " this is where it should ignite");

                if (collider.gameObject.GetComponent<GetContactPoint>() == null)
                {
                    collider.gameObject.AddComponent<GetContactPoint>().SetContactPoint(contact, collider.transform.rotation);
                    // Debug.Log(this.gameObject.name + " this is where it should ignite " + contact);
                }
                else
                {
                    collider.gameObject.GetComponent<GetContactPoint>().SetContactPoint(contact, collider.transform.rotation);
                }

                IncreaseTempsOfNearbyElements(collider, element);

            }else
            {
                break;
            }
                
        }    
    }

    private void IncreaseTempsOfNearbyElements(Collider collider, ElementType element)
    {
        if (element == ElementType.Wood)
        {
            TempGauge woodObj = collider.gameObject.GetComponent<TempGauge>();
            woodObj.IncreaseTemp(increaseWoodTempAmount);

        }
        if (element == ElementType.Water)
        {
            TempGauge waterObj = collider.gameObject.GetComponent<TempGauge>();
            waterObj.IncreaseTemp(increaseWaterTempAmount);
        }
        if (element == ElementType.Ice)
        {
            TempGauge iceObj = collider.gameObject.GetComponent<TempGauge>();
            iceObj.IncreaseTemp(increaseIceTempAmount);
        }
    }

    private void SetContactPoints(Collision collision)
    {
        if (GetComponent<GetContactPoint>() == null)
        {
            this.gameObject.AddComponent<GetContactPoint>().SetFirstContactPoint(collision);

        }
        else
        {
            this.gameObject.GetComponent<GetContactPoint>().SetFirstContactPoint(collision);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, fireSpreadRadius);
    }

}
