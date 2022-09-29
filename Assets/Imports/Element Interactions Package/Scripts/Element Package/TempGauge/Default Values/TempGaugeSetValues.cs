
using UnityEngine;

public class TempGaugeSetValues : MonoBehaviour {

    public float setFreezeTemp;
    public float setBurnTemp;
    public float setMinTemp;
    public float setMaxTemp;
    public float setNextTouchRate;

    private void Start()
    {
        SetValues();
    }


    public void SetValues()
    {
        ElementType type = GetComponent<Element>().CurrentType;
        switch (type)
        {
            case ElementType.Wood:
                if (GameObject.FindGameObjectWithTag("WoodManager")  == null)
                {
                    if (this.gameObject.GetComponent<WoodProperties>() != null)
                    {
                        WoodProperties woodValues = this.gameObject.GetComponent<WoodProperties>() as WoodProperties;
                        SetWoodValues(woodValues);
                        break;
                    }
                    else
                    {
                        WoodProperties woodValues = this.gameObject.AddComponent<WoodProperties>() as WoodProperties;
                        SetWoodValues(woodValues);
                        break;
                    }
                }
                else
                {
                    if (this.gameObject.GetComponent<WoodProperties>() == null)
                    {
                        WoodManagerValues woodManagerValues = GameObject.FindGameObjectWithTag("WoodManager").GetComponent<WoodManagerValues>() as WoodManagerValues;
                        SetWoodValues(woodManagerValues);
                        //SetWoodValues();
                        break;
                    }
                    else
                    {
                        WoodProperties woodValues = this.gameObject.GetComponent<WoodProperties>() as WoodProperties;
                        SetWoodValues(woodValues);
                        break;
                    }
                }

            case ElementType.Water:
                if (GameObject.FindGameObjectWithTag("WaterManager") == null)
                {
                    if (this.gameObject.GetComponent<WaterProperties>() != null)
                    {
                        WaterProperties waterValues = this.gameObject.GetComponent<WaterProperties>() as WaterProperties;
                        SetWaterValues(waterValues);
                        break;
                    }
                    else
                    {
                        WaterProperties waterValues = this.gameObject.AddComponent<WaterProperties>() as WaterProperties;
                        SetWaterValues(waterValues);
                        break;
                    }
                }
                else
                {
                    if (this.gameObject.GetComponent<WaterProperties>() == null)
                    {
                        GameObject waterManagerValues = GameObject.FindGameObjectWithTag("WaterManager");
                        SetWaterValues(waterManagerValues);
                        break;
                    }
                    else
                    {
                        WaterProperties waterValues = this.gameObject.GetComponent<WaterProperties>() as WaterProperties;
                        SetWaterValues(waterValues);
                        break;
                    }
                }

            case ElementType.Fire:
                if (GameObject.FindGameObjectWithTag("FireManager") == null )
                {
                    if (this.gameObject.GetComponent<FireProperties>() != null)
                    {
                        FireProperties fireValues = this.gameObject.GetComponent<FireProperties>() as FireProperties;
                        SetFireValues(fireValues);
                        break;
                    }else
                    {
                        FireProperties fireValues = this.gameObject.AddComponent<FireProperties>() as FireProperties;
                        SetFireValues(fireValues);
                        break;
                    }
                }else
                {
                    if (this.gameObject.GetComponent<FireProperties>() == null)
                    {
                        GameObject fireManagerValues = GameObject.FindGameObjectWithTag("FireManager");
                        SetFireValues(fireManagerValues);
                        break;
                    }else
                    {
                        FireProperties fireValues = this.gameObject.GetComponent<FireProperties>() as FireProperties;
                        SetFireValues(fireValues);
                        break;
                    }
                }

            case ElementType.Ice:
                if (GameObject.FindGameObjectWithTag("IceManager") == null)
                {
                    if (this.gameObject.GetComponent<IceProperties>() != null)
                    {
                        IceProperties iceValues = this.gameObject.GetComponent<IceProperties>() as IceProperties;
                        SetIceValues(iceValues);
                        break;
                    }
                    else
                    {
                        IceProperties iceValues = this.gameObject.AddComponent<IceProperties>() as IceProperties;
                        SetIceValues(iceValues);
                        break;
                    }
                }
                else
                {
                    if (this.gameObject.GetComponent<IceProperties>() == null)
                    {
                        GameObject iceManagerValues = GameObject.FindGameObjectWithTag("IceManager");
                        SetIceValues(iceManagerValues);
                        break;
                    }
                    else
                    {
                        IceProperties iceValues = this.gameObject.GetComponent<IceProperties>() as IceProperties;
                        SetIceValues(iceValues);
                        break;
                    }
                }

        }
    }

    void SetIceValues(IceProperties iceValues)
    {
        setFreezeTemp = iceValues.freezeTemp;
        setBurnTemp = iceValues.burnTemp;
        setMinTemp = iceValues.minTemp;
        setMaxTemp = iceValues.maxTemp;
        setNextTouchRate = iceValues.nextTouchRate;
    }
    void SetIceValues(GameObject iceManagerValues)
    {
        setFreezeTemp = iceManagerValues.GetComponent<IceManagerValues>().freezeTemp;
        setBurnTemp = iceManagerValues.GetComponent<IceManagerValues>().burnTemp;
        setMinTemp = iceManagerValues.GetComponent<IceManagerValues>().minTemp;
        setMaxTemp = iceManagerValues.GetComponent<IceManagerValues>().maxTemp;
        setNextTouchRate = iceManagerValues.GetComponent<IceManagerValues>().nextTouchRate;
    }

    void SetFireValues(FireProperties fireValues)
    {
        setFreezeTemp = fireValues.FreezeTemp;
        setBurnTemp = fireValues.BurnTemp;
        setMinTemp = fireValues.MinTemp;
        setMaxTemp = fireValues.MaxTemp;
        setNextTouchRate = fireValues.NextTouchRate;
    }
    void SetFireValues(GameObject fireManagerValues)
    {
      
        setFreezeTemp = fireManagerValues.GetComponent<FireManagerValues>().freezeTemp;
        setBurnTemp = fireManagerValues.GetComponent<FireManagerValues>().burnTemp;
        setMinTemp = fireManagerValues.GetComponent<FireManagerValues>().minTemp;
        setMaxTemp = fireManagerValues.GetComponent<FireManagerValues>().maxTemp;
        setNextTouchRate = fireManagerValues.GetComponent<FireManagerValues>().nextTouchRate;
    }

    void SetWoodValues(WoodProperties woodValues)
    {
        setFreezeTemp = woodValues.freezeTemp;
        setBurnTemp = woodValues.burnTemp;
        setMinTemp = woodValues.minTemp;
        setMaxTemp = woodValues.maxTemp;
        setNextTouchRate = woodValues.nextTouchRate;
    }
    void SetWoodValues(WoodManagerValues woodManagerValues )
    {
        setFreezeTemp = woodManagerValues.freezeTemp;
        setBurnTemp = woodManagerValues.burnTemp;
        setMinTemp = woodManagerValues.minTemp;
        setMaxTemp = woodManagerValues.maxTemp;
        setNextTouchRate = woodManagerValues.nextTouchRate;
    }

    void SetWaterValues(GameObject waterValues)
    {
        setFreezeTemp = waterValues.GetComponent<WaterManagerValues>().freezeTemp;
        setBurnTemp = waterValues.GetComponent<WaterManagerValues>().burnTemp;
        setMinTemp = waterValues.GetComponent<WaterManagerValues>().minTemp;
        setMaxTemp = waterValues.GetComponent<WaterManagerValues>().maxTemp;
        setNextTouchRate = waterValues.GetComponent<WaterManagerValues>().nextTouchRate;


    }
    void SetWaterValues(WaterProperties waterProperties)
    {
        setFreezeTemp = waterProperties.freezeTemp;
        setBurnTemp = waterProperties.burnTemp;
        setMinTemp = waterProperties.minTemp;
        setMaxTemp = waterProperties.maxTemp;
        setNextTouchRate = waterProperties.nextTouchRate;
    }



}
