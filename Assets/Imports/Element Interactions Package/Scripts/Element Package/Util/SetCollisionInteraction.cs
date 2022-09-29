using System.Collections;
using UnityEngine;

public class SetCollisionInteraction : MonoBehaviour {

    bool inside = false;
   /** public void OnCollisionStay(Collision collision)
    {

        // Debug.Log(" SHOULD NOW BE IN STAY");
        if (collision.gameObject.GetComponent<Element>() != null && this.gameObject.GetComponent<Element>() != null)
        {
            
            SetInteractions(collision);
            SetContactPoints(collision);
        }
      
    }**/

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Element>() != null && this.gameObject.GetComponent<Element>() != null)
        {
            if (inside)
            {
                inside = false;
                StopCoroutine(SetStuff(collision));
            }
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Element>() != null && this.gameObject.GetComponent<Element>() != null)
        {
            if (!inside)
            {
                inside = true;
                StartCoroutine(SetStuff(collision));

                //SetInteractions(collision);
                //SetContactPoints(collision);
            }

        }
    }

    IEnumerator SetStuff(Collision collision)
    {
        while (inside)
        {
            yield return new WaitForFixedUpdate();//this allows a performance increase
            SetInteractions(collision);
            SetContactPoints(collision);
        }
    }

    private void SetInteractions(Collision collision)
    {
        ElementType ElementThatWasHit = collision.gameObject.GetComponent<Element>().CurrentType;//the thing that was hit
        ElementType ElementThatDidHit = this.gameObject.GetComponent<Element>().CurrentType;//the thing hitting

        SetContactPoints(collision);

        switch (ElementThatWasHit)
        {
            case ElementType.Fire://type1. If we hit fire
                SetFire(ElementThatDidHit, collision);//then pass on what we are to the fire. 
                break;

            case ElementType.Wood:
                SetWood(ElementThatDidHit);
                break;

            case ElementType.Water:
                SetWater(ElementThatDidHit, collision);
                break;

            case ElementType.Metal:
                SetMetal(ElementThatDidHit, collision);
                break;

            case ElementType.Ice:
                SetIce(ElementThatDidHit);
                break;
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

    private void SetIce(ElementType elementThatHit)
    {
            if (this.gameObject.GetComponent<IceHitInteractions>() == null)
            {
                IceHitInteractions iceInteractions = this.gameObject.AddComponent<IceHitInteractions>() as IceHitInteractions;
                iceInteractions.HandleIceCollisions( elementThatHit);
            }
            else
            {
                this.gameObject.GetComponent<IceHitInteractions>().HandleIceCollisions( elementThatHit);

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

    private void SetWater(ElementType elementThatDidHit, Collision collision)
    {
            if (this.gameObject.GetComponent<WaterHitInteractions>() == null)
            {
                WaterHitInteractions waterInteractions = this.gameObject.AddComponent<WaterHitInteractions>() as WaterHitInteractions;
                waterInteractions.HandleWaterCollisions(elementThatDidHit, collision);
            }
            else
            {
                this.gameObject.GetComponent<WaterHitInteractions>().HandleWaterCollisions(elementThatDidHit, collision);
            }
        
    }

    private void SetFire(ElementType elementThatDidHit, Collision collision)
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

    private void SetWood( ElementType elementThatDidHit)
    {
        if (this.gameObject.GetComponent<WoodInteractions>() == null)
        {
            WoodInteractions woodInteractions = this.gameObject.AddComponent<WoodInteractions>() as WoodInteractions;
            woodInteractions.HandleWoodCollisions(elementThatDidHit);
        }else
        {
            this.gameObject.GetComponent<WoodInteractions>().HandleWoodCollisions(elementThatDidHit);
        }
    }

}
