
using UnityEngine;

public class TempGaugeNormalStuff : MonoBehaviour
{
    ColorTinter theTintController;
    Renderer rend;
    ElementType _type;

    private void Awake()
    {
        //CheckColorTinter();
        CheckRenderer();
    }

    private void CheckRenderer()
    {
        if (this.gameObject.GetComponent<Renderer>() != null)
        {
            rend = this.gameObject.GetComponent<Renderer>();
        }
        else if (this.gameObject.GetComponentInChildren<Renderer>() != null)
        {
            rend = this.gameObject.GetComponentInChildren<Renderer>();
        }
        else
        {
            Debug.Log(this.gameObject.name + " does not have a renderer...");
        }
    }

    private void CheckColorTinter()
    {
        if (this.gameObject.GetComponent<ColorTinter>() != null)
        {
            theTintController = this.gameObject.GetComponent<ColorTinter>();
        }
        else
        {
            theTintController = this.gameObject.AddComponent<ColorTinter>();
        }
    }



    public void DoNormalStuff(ElementType type)//type is current gameobject
    {
        _type = type;
        CheckColorTinter();


        switch (type)
        {
            case ElementType.Fire:
                //FireIgnite();
                break;

            case ElementType.Wood:
                //WoodSetFire();
                break;

            case ElementType.Water:
                //
                break;

            case ElementType.Metal:
                //
                break;

            case ElementType.Ice:
                //
                break;
        }
    }

    private void WoodSetFire()
    {
        // Debug.Log("wood set fire");
        if (this.gameObject.GetComponent<TempGaugeWoodResults>() == null)
        {
            this.gameObject.AddComponent<TempGaugeWoodResults>().WoodSetFire();

        }
        else
        {
            this.gameObject.GetComponent<TempGaugeWoodResults>().WoodSetFire();
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
}
