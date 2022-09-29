
using UnityEngine;

public class IceHitInteractions : MonoBehaviour {

    float iceDecreasesWoodOnTouch;
    float iceDecreasesWaterOnTouch;
    float iceDecreasesFireOntouch;

    float iceIncreasesIce;

    #region assign values
    private void Start()
    {
        AssignValues();
        
    }

    void AssignValues()
    {
        if (GameObject.FindGameObjectWithTag("IceManager") != null)
        {
            if (this.gameObject.GetComponent<IceReactionsProperties>() != null)
            {
                IceReactionsProperties values = this.gameObject.GetComponent<IceReactionsProperties>();
                SetValues(values);
            }else
            {
                IceHitTemperatureReactionsManager values = GameObject.FindGameObjectWithTag("IceManager").GetComponentInChildren<IceHitTemperatureReactionsManager>() as IceHitTemperatureReactionsManager;
                SetValues(values);
            }
        }else
        {
            if (this.gameObject.GetComponent<IceReactionsProperties>() !=null)
            {
                IceReactionsProperties values = this.gameObject.GetComponent<IceReactionsProperties>();
                SetValues(values);
            }
            else{
                IceReactionsProperties values = this.gameObject.AddComponent<IceReactionsProperties>() as IceReactionsProperties;
                SetValues(values);
            }
        }
        
    }

    void SetValues(IceHitTemperatureReactionsManager values)
    {
        //Debug.Log("using ice manager");
        iceIncreasesIce = values.IceIncreasesIce;

        iceDecreasesWoodOnTouch = values.IceDecreasesWoodOnTouch;
        iceDecreasesWaterOnTouch = values.IceDecreasesWaterOnTouch;
        iceDecreasesFireOntouch = values.IceDecreasesFireOnTouch;
    }
    void SetValues(IceReactionsProperties values)
    {
        iceIncreasesIce = values.IceIncreasesIce;
        iceDecreasesWoodOnTouch = values.IceDecreasesWoodOnTouch;
        iceDecreasesWaterOnTouch = values.IceDecreasesWaterOnTouch;
        iceDecreasesFireOntouch = values.IceDecreasesFireOnTouch;
    }

    #endregion
    public void HandleIceCollisions(ElementType elementThatHit)
    {
        if (elementThatHit == ElementType.Wood)//ice hit wood
        {
            
            this.gameObject.GetComponent<TempGauge>().DecreaseTemp(iceDecreasesWoodOnTouch);//increase wood temp
        }
        if (elementThatHit == ElementType.Water)
        {
            this.gameObject.GetComponent<TempGauge>().DecreaseTemp(iceDecreasesWaterOnTouch);
        }
        if (elementThatHit == ElementType.Fire)
        {
            this.gameObject.GetComponent<TempGauge>().DecreaseTemp(iceDecreasesFireOntouch);
        }
        if (elementThatHit == ElementType.Ice)
        {
            this.gameObject.GetComponent<TempGauge>().IncreaseTemp(iceIncreasesIce);
        }
    }
}
