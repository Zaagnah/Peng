
using UnityEngine;

public class InteractionTriggers : MonoBehaviour {

   /** public void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Element>() != null && this.gameObject.GetComponent<Element>() != null)
        {
            SetInteractions(other);
            SetContactPoints(other);
        }
        else
        {
            return;
        }
    }

    private void SetInteractions(Collider other)
    {
        ElementType ElementThatWasHit = other.gameObject.GetComponent<Element>().Type;//the thing that was hit
        ElementType ElementThatDidHit = this.gameObject.GetComponent<Element>().Type;//the thing hitting

        SetContactPoints(other);

        switch (ElementThatWasHit)
        {
            case ElementType.Fire://type1. If we hit fire
                SetFire(ElementThatDidHit, other);//then pass on what we are to the fire. 
                break;

            case ElementType.Wood:
               // SetWood(ElementThatDidHit);
                break;

            case ElementType.Water:
              //  SetWater(ElementThatDidHit);
                break;

            case ElementType.Metal:
              //  SetMetal(ElementThatDidHit);
                break;

            case ElementType.Ice:
               // SetIce(ElementThatDidHit, collision);
                break;
        }
    }

    private void SetContactPoints(Collider other)
    {
        if (GetComponent<GetContactPoint>() == null)
        {
            //this.gameObject.AddComponent<GetContactPoint>().SetFirstContactPoint(other);

        }
        else
        {
           // this.gameObject.GetComponent<GetContactPoint>().SetFirstContactPoint(other);
        }
    }

    private void SetIce(ElementType elementThatHit, Collision collision)
    {
        if (this.gameObject.GetComponent<IceHitInteractions>() == null)
        {
            IceHitInteractions iceInteractions = this.gameObject.AddComponent<IceHitInteractions>() as IceHitInteractions;
            iceInteractions.HandleIceCollisions(elementThatHit, collision);
        }
        else
        {
            this.gameObject.GetComponent<IceHitInteractions>().HandleIceCollisions(elementThatHit, collision);

        }
    }

    private void SetMetal(ElementType elementThatDidHit, Collision collision)
    {

        if (this.gameObject.GetComponent<MetalInteractions>() == null)
        {
            MetalInteractions metalInteractions = this.gameObject.AddComponent<MetalInteractions>() as MetalInteractions;
            metalInteractions.HandleMetalCollisions(elementThatDidHit);
        }
        else
        {
            this.gameObject.GetComponent<MetalInteractions>().HandleMetalCollisions(elementThatDidHit);

        }
    }

    private void SetWater(ElementType elementThatDidHit)
    {
        if (this.gameObject.GetComponent<WaterHitInteractions>() == null)
        {
            WaterHitInteractions waterInteractions = this.gameObject.AddComponent<WaterHitInteractions>() as WaterHitInteractions;
            waterInteractions.HandleWaterCollisions(elementThatDidHit);
        }
        else
        {
            this.gameObject.GetComponent<WaterHitInteractions>().HandleWaterCollisions(elementThatDidHit);
        }

    }

    private void SetFire(ElementType elementThatDidHit, Collider other)
    {
        if (this.gameObject.GetComponent<FireHitInteractions>() == null)
        {
            FireHitInteractions fireInteractions = this.gameObject.AddComponent<FireHitInteractions>() as FireHitInteractions;
            fireInteractions.HandleFireCollisions(elementThatDidHit, collision);
        }
        else
        {
            this.gameObject.GetComponent<FireHitInteractions>().HandleFireCollisions(elementThatDidHit, collision);
        }
    }

    private void SetWood(ElementType elementThatDidHit)
    {
        if (this.gameObject.GetComponent<WoodInteractions>() == null)
        {
            WoodInteractions woodInteractions = this.gameObject.AddComponent<WoodInteractions>() as WoodInteractions;
            woodInteractions.HandleWoodCollisions(elementThatDidHit);
        }
        else
        {
            this.gameObject.GetComponent<WoodInteractions>().HandleWoodCollisions(elementThatDidHit);
        }
    }**/
}
