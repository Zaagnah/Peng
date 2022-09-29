using System.Collections;
using UnityEngine;

public class WaterHitInteractions : MonoBehaviour
{
    #region experimental
    Collider _other; 

    float equilibriumTime = 10f;
    bool equalize = false;
    #endregion

    private float waterDecreasesFire;
    private float waterIncreasesIce;
    

    private void Awake()
    {
        AssignValues();
            
    }

    void AssignValues()
    {
        //do assigning.
        if (GameObject.FindGameObjectWithTag("WaterManager") == null)
        {
            waterDecreasesFire = 1f;
            waterIncreasesIce = .5f;
        }else
        {
            waterDecreasesFire = GameObject.FindGameObjectWithTag("WaterManager").GetComponentInChildren<WaterHitTemperatureReactionsManager>().WaterDecreasesFire;
            waterIncreasesIce = GameObject.FindGameObjectWithTag("WaterManager").GetComponentInChildren<WaterHitTemperatureReactionsManager>().waterIncreasesIce;
        }
            

        
    }

    #region experimental
    
    IEnumerator Equilibrium(Collision collision)
    {
        Debug.Log("Entered Coroutine " + this.gameObject.name);
        float thisTemp = GetComponent<TempGauge>().CurrentTemp;
        float otherTemp = collision.collider.GetComponent<TempGauge>().CurrentTemp;

        float averageTemp = (thisTemp + otherTemp) / 2;
        float lerpTowards = averageTemp;

        float i = 0;
        float rate = 1 / equilibriumTime;
        while (i < 0)
        {
            Debug.Log("Entered while loop");
            i += Time.deltaTime * rate;
            float setThisTemp = Mathf.Lerp(thisTemp, averageTemp, equilibriumTime);//set these as coroutines
            float setOtherTemp = Mathf.Lerp(otherTemp, averageTemp, equilibriumTime);

            if (setThisTemp == averageTemp && setOtherTemp == averageTemp)
            {
                StopCoroutine(Equilibrium(collision));
                break;
            }

            GetComponent<TempGauge>().SetCurrentTemp(setThisTemp);
            collision.collider.GetComponent<TempGauge>().SetCurrentTemp(setOtherTemp);
            yield return null;
        }
        Debug.Log("Exited While loop");

    }
    IEnumerator Equilibrium(Collider other)
    {
        Debug.Log("Entered Coroutine " + this.gameObject.name);
        float thisTemp = GetComponent<TempGauge>().CurrentTemp;
        float otherTemp = other.GetComponent<TempGauge>().CurrentTemp;

        float averageTemp = (thisTemp + otherTemp) / 2;
        float lerpTowards = averageTemp;

        float i = 0;
        float rate = 1 / equilibriumTime;
        while (i < 0)
        {
            
            Debug.Log("Entered while loop");
            i += Time.deltaTime * rate;
            float setThisTemp = Mathf.Lerp(thisTemp, averageTemp, equilibriumTime);//set these as coroutines
         
            float setOtherTemp = Mathf.Lerp(otherTemp, averageTemp, equilibriumTime);

            if (setThisTemp == averageTemp && setOtherTemp == averageTemp)
            {
                StopCoroutine(Equilibrium(other));
                break;
            }

            GetComponent<TempGauge>().SetCurrentTemp(setThisTemp);
            other.GetComponent<TempGauge>().SetCurrentTemp(setOtherTemp);
            yield return null;
        }
        Debug.Log("Exited While loop");

    }
    #endregion
    
    public void HandleWaterCollisions(ElementType elementThatHit, Collision collision)
    {
        if (this.gameObject.GetComponent<TempGauge>() != null)
        {
            if (collision.collider.GetComponent<TempGauge>() != null)
            {
              //  if (!equalize)
             //   {
             //       StartCoroutine(Equilibrium(collision));
                    
              //  }
            }

        }
    }

    public void HandleWaterCollisions(ElementType elementThatHit, Collider other)
    {
        if (this.gameObject.GetComponent<TempGauge>() != null)
        {
            if (other.GetComponent<TempGauge>() !=null)
            {
                #region experimental
                // _other = other;
                //  if (!equalize)
                // {
                //      StartEquilibrium(_other);
                // }
                #endregion
            }
        }
           


            if (elementThatHit == ElementType.Fire)//if water hit fire
            {
                this.gameObject.GetComponent<TempGauge>().DecreaseTemp(waterDecreasesFire);//fire loses temp
                
            }

            if (elementThatHit == ElementType.Wood)//if water hit wood
            {
                //make wood soggy
            }
            if (elementThatHit == ElementType.Ice)
        {
            //do some equalizing effect 
        }
        }
      
    public void StartEquilibrium(Collider other)
    {
        equalize = true;
        StartCoroutine(Equilibrium(other));

    }
    public void StopEquilibrium()
    {
        equalize = false;
        StopCoroutine(Equilibrium(_other));
    }
}



