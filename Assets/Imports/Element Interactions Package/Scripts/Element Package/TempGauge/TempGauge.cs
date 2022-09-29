
using UnityEngine;

[RequireComponent(typeof(TempGaugeSetValues))]
public class TempGauge : MonoBehaviour {

    TempGaugeSetValues getValues;
    Renderer rend;

    public float CurrentTemp { get { return currentTemp; } }
    [SerializeField]
    private float currentTemp = 0;//starts at 0 for normal temp, it's a relative temp scale

    private float freezeTemp;
    private float burnTemp;
    private float minTemp;
    private float maxTemp;
    private float startingTemp;

    private bool onFire = false;
    public bool OnFire
    {
        get
        {
            return onFire;
        }
    }
    [SerializeField]
    private bool canChangeTemp = true;
    public bool CanChangeTemp { get { return canChangeTemp; } }
    private float nextTouchIncrease;
    private float nextTouchDecrease;
    private float nextTouchRate;


    void Start()
    {
        AssignTemperatureValues();

        startingTemp = currentTemp;
        nextTouchIncrease = Time.time;
        nextTouchDecrease = Time.time;

    }

    public void AssignTemperatureValues()
    {
        if (this.gameObject.GetComponent<TempGaugeSetValues>() == null)
        {
          
            getValues = this.gameObject.AddComponent<TempGaugeSetValues>();
        }
        else
        {
            getValues = this.gameObject.GetComponent<TempGaugeSetValues>();
        }
        getValues.SetValues();
        GetTempValues(getValues);
    }

    void GetTempValues(TempGaugeSetValues values)
    {
        freezeTemp = values.setFreezeTemp;
        burnTemp = values.setBurnTemp;
        minTemp = values.setMinTemp;
        maxTemp = values.setMaxTemp;
        nextTouchRate = values.setNextTouchRate;
}


    public void SetTempToNormal()
    {
        currentTemp = startingTemp;
     
    }

    public void IncreaseTemp(float amount)
    {
        if (Time.time >  nextTouchIncrease && canChangeTemp)
        {
            currentTemp += amount;
            ClampWoodTemp();
            CheckTemp(currentTemp);
            nextTouchIncrease = Time.time + nextTouchRate;
        }
   
    }
    public void DecreaseTemp(float amount)
    {
        if ( Time.time > nextTouchDecrease && canChangeTemp)
        {
            currentTemp -= amount;
            ClampWoodTemp();
            CheckTemp(currentTemp);
            nextTouchDecrease = Time.time + nextTouchRate;
        }

    }

     void CheckTemp(float currentTemp)
    {
        ElementType type = this.gameObject.GetComponent<Element>().CurrentType;

        if (currentTemp <= freezeTemp)
        {
           // Debug.Log(this.gameObject.name + " do freeze stuff");
            DoFreezeStuff(type);
        }

        if ( currentTemp > freezeTemp && currentTemp <= burnTemp)
        {
           // Debug.Log(this.gameObject.name + " do normal stuff");
            DoNormalStuff(type);

            if (currentTemp > freezeTemp && currentTemp < startingTemp)//between freeze and starting
            {
                if (this.gameObject.GetComponent<ColorTinter>() != null)
                {
                    ColorTinter colorTinter = this.gameObject.GetComponent<ColorTinter>();
                    colorTinter.SetColorTintCold(currentTemp, freezeTemp);
                }
                   
            }else if(currentTemp > startingTemp && currentTemp < burnTemp)
            {
                ColorTinter colorTinter = this.gameObject.GetComponent<ColorTinter>();
                colorTinter.SetColorTintHot(currentTemp, burnTemp);
            }
        }

        if (currentTemp > burnTemp)
        {
           // Debug.Log(this.gameObject.name + " do fire stuff");
            DoBurnStuff(type);

        }
    }
  

    private void DoFreezeStuff(ElementType type)
    {
        if (this.gameObject.GetComponent<TempGaugeFreezeStuff>() == null)
        {
            this.gameObject.AddComponent<TempGaugeFreezeStuff>().DoFreezeStuff(type);

        }else
        {
            this.gameObject.GetComponent<TempGaugeFreezeStuff>().DoFreezeStuff(type);
        }

       
    }

    private void DoNormalStuff(ElementType type)
    {
        if (this.gameObject.GetComponent<TempGaugeNormalStuff>() == null)
        {
            this.gameObject.AddComponent<TempGaugeNormalStuff>().DoNormalStuff(type);

        }
        else
        {
            this.gameObject.GetComponent<TempGaugeNormalStuff>().DoNormalStuff(type);
        }
    }

    private void DoBurnStuff(ElementType type)
    {

        if (this.gameObject.GetComponent<TempGaugeBurnStuff>() == null)
        {
            this.gameObject.AddComponent<TempGaugeBurnStuff>().DoBurnStuff(type);

        }
        else
        {
            this.gameObject.GetComponent<TempGaugeBurnStuff>().DoBurnStuff(type);
        }

    }

   
    void ClampWoodTemp()
    {
        currentTemp = Mathf.Clamp(currentTemp, minTemp, maxTemp);
    }
    
    public void AllowTempChanges(bool iFrames)
    {
        canChangeTemp = iFrames;
    }
    public void DisallowTempChanges()
    {
        canChangeTemp = false;
    }

    public void SetCurrentTemp(float newTemp)
    {
        currentTemp = newTemp;
        CheckTemp(currentTemp);
    }
}
