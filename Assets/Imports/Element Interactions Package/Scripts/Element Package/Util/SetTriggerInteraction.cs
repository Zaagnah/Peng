using System.Collections;
using UnityEngine;

public class SetTriggerInteraction : MonoBehaviour {


    /** public void OnTriggerStay(Collider other)
     {
         if (other.gameObject.GetComponent<Element>() != null && this.gameObject.GetComponent<Element>() != null)
         {
             
             SetInteractions(other);
             SetContactPoints();
         }
       
     }**/

    bool inside = false;
    public void OnTriggerEnter(Collider other)
    {
        if (!inside)
        {
            if (other.gameObject.GetComponent<Element>() != null && this.gameObject.GetComponent<Element>() != null)
            {
                inside = true;
                StartCoroutine(SetStuff(other));
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (inside)
        {
            inside = false;
            StopCoroutine(SetStuff(other));
        }
    }
    IEnumerator SetStuff(Collider other)
    {
        while (inside)
        {
            yield return new WaitForSeconds(.1f);//this allows a performance increase
            SetInteractions(other);
            SetContactPoints();
        }
    }


    private void SetInteractions(Collider other)
    {
        ElementType ElementThatWasHit = other.gameObject.GetComponent<Element>().CurrentType;//the thing that was hit
        ElementType ElementThatDidHit = this.gameObject.GetComponent<Element>().CurrentType;//the thing hitting

        

        switch (ElementThatWasHit)
        {
            case ElementType.Fire://type1. If we hit fire
                SetFire(ElementThatDidHit, other);//then pass on what we are to the fire. 
                break;

            case ElementType.Wood:
                SetWood(ElementThatDidHit);
                break;

            case ElementType.Water:
                SetWater(ElementThatDidHit, other);
                break;

            case ElementType.Metal:
                SetMetal(ElementThatDidHit);
                break;

            case ElementType.Ice:
                SetIce(ElementThatDidHit);
                break;
        }
    }


    private void SetContactPoints()
    {
        if (GetComponent<GetContactPoint>() == null)
        {
            this.gameObject.AddComponent<GetContactPoint>().SetFirstContactPoint();
           // other.gameObject.AddComponent<GetContactPoint>().SetContactPoint(transform.position, Quaternion.identity);

        }
        else
        {
           // other.gameObject.GetComponent<GetContactPoint>().SetContactPoint(transform.position, Quaternion.identity);
            this.gameObject.GetComponent<GetContactPoint>().SetFirstContactPoint();
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
            iceInteractions.HandleIceCollisions(elementThatHit);
        }
        else
        {
            this.gameObject.GetComponent<IceHitInteractions>().HandleIceCollisions(elementThatHit);

        }
    }
    private void SetMetal(ElementType elementThatDidHit)
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
    private void SetWater(ElementType elementThatDidHit, Collider other)
    {
        if (this.gameObject.GetComponent<WaterHitInteractions>() == null)
        {
            WaterHitInteractions waterInteractions = this.gameObject.AddComponent<WaterHitInteractions>() as WaterHitInteractions;
            waterInteractions.HandleWaterCollisions(elementThatDidHit, other);
        }
        else
        {
            this.gameObject.GetComponent<WaterHitInteractions>().HandleWaterCollisions(elementThatDidHit, other);
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
    private void SetFire(ElementType elementThatDidHit, Collider other)
    {
        if (this.gameObject.GetComponent<FireHitInteractions>() == null)
        {
            FireHitInteractions fireInteractions = this.gameObject.AddComponent<FireHitInteractions>() as FireHitInteractions;
            fireInteractions.HandleFireCollisions(elementThatDidHit, other);
        }
        else
        {
            this.gameObject.GetComponent<FireHitInteractions>().HandleFireCollisions(elementThatDidHit, other);
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
    }

}
