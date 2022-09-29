
using UnityEngine;

public class TempGaugeFreezeStuff : MonoBehaviour {

    public void DoFreezeStuff(ElementType type)
    {
        switch (type)
        {
            case ElementType.Fire:
                FireExtinguished();
                break;

            case ElementType.Wood:
                //
                break;

            case ElementType.Water:
                WaterTurnedToIce();
                break;

            case ElementType.Metal:
                //
                break;

            case ElementType.Ice:
                //
                break;
        }
    }

    void WaterTurnedToIce()
    {
        if (this.gameObject.GetComponent<TempGaugeWaterResults>() == null)
        {
            this.gameObject.AddComponent<TempGaugeWaterResults>().MakeIce();
        }
        else
        {
            this.gameObject.GetComponent<TempGaugeWaterResults>().MakeIce();
        }
        
    }
        
    void FireExtinguished()
    {
        //Debug.Log("Running Extinguished Code");
        if (this.gameObject.GetComponent<TempGaugeFireResults>() == null)
        {
            this.gameObject.AddComponent<TempGaugeFireResults>().ExtinguishFire();
        }
        else
        {
            this.gameObject.GetComponent<TempGaugeFireResults>().ExtinguishFire();
        }
    }
}
