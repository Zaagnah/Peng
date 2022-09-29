
using UnityEngine;

public class TempGaugeBurnStuff : MonoBehaviour
{
    public void DoBurnStuff(ElementType type)
    {

        switch (type)
        {
            case ElementType.Fire:
                FireIgnite();
                break;

            case ElementType.Wood:
                WoodSetFire();
                break;

            case ElementType.Water:
                WaterCompletelyEvaporate();
                break;

            case ElementType.Metal:
                //
                break;

            case ElementType.Ice:
                IceMelt();
                break;
        }
    }

    void WaterCompletelyEvaporate()
    {
        if (this.gameObject.GetComponent<TempGaugeWaterResults>() == null)
        {
            this.gameObject.AddComponent<TempGaugeWaterResults>().Evaporate();

        }else
        {
            this.gameObject.GetComponent<TempGaugeWaterResults>().Evaporate();
        }


    }
    void IceMelt()
    {
        if (this.gameObject.GetComponent<TempGaugeIceResults>() == null)
        {
            this.gameObject.AddComponent<TempGaugeIceResults>().MeltIce();
        }else
        {
            this.gameObject.GetComponent<TempGaugeIceResults>().MeltIce();
        }
    }
    void FireIgnite()
    {

        if (this.gameObject.GetComponent<TempGaugeFireResults>() == null)
        {
            this.gameObject.AddComponent<TempGaugeFireResults>().IgniteFire();
        }
        else
        {
            this.gameObject.GetComponent<TempGaugeFireResults>().IgniteFire();
        }
    }
    private void WoodSetFire()
    {
        if (this.gameObject.GetComponent<TempGaugeWoodResults>() == null)
        {
            this.gameObject.AddComponent<TempGaugeWoodResults>().WoodSetFire();

        }
        else
        {
            this.gameObject.GetComponent<TempGaugeWoodResults>().WoodSetFire();
        }

    }
}
