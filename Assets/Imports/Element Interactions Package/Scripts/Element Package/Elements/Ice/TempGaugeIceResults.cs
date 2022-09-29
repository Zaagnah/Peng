using System.Collections;
using UnityEngine;

public class TempGaugeIceResults : MonoBehaviour {

    PhaseChange phaseChange;

    Vector3 MeltExpansion;
    private float speedOfMelt;

    Vector3 newScale;
    Vector3 currentScale;
    private float startTime;
    private float endTime;
    private float timeRate;
    bool melt = false;

    #region Assign Values
    private void Awake()
    {
        AssignValues();

    }
    void AssignValues()
    {
        if (GameObject.FindGameObjectWithTag("IceManager") == null)
        {
            if (this.gameObject.GetComponent<IceReactionsProperties>() !=null)
            {
                IceReactionsProperties values = this.gameObject.GetComponent<IceReactionsProperties>();
                SetValues(values);
            }
            else
            {
                IceReactionsProperties values = this.gameObject.GetComponent<IceReactionsProperties>() as IceReactionsProperties;
                SetValues(values);
            }
        }
        else
        {
            if (this.gameObject.GetComponent<IceReactionsProperties>() == null)
            {
                IceHitTemperatureReactionsManager values = GameObject.FindGameObjectWithTag("IceManager").GetComponentInChildren<IceHitTemperatureReactionsManager>() as IceHitTemperatureReactionsManager;
                SetValues(values);
            }else
            {
                IceReactionsProperties values = this.gameObject.GetComponent<IceReactionsProperties>() as IceReactionsProperties;
                SetValues(values);
            }
        }
    }

    void SetValues(IceReactionsProperties values)
    {
        MeltExpansion = values.MeltingScale;
        speedOfMelt = values.SpeedOfMelt;
}
    void SetValues (IceHitTemperatureReactionsManager values)
    {
        Debug.Log("using Ice Hit Temp Reaction Manager");
        MeltExpansion = values.meltingScale;
        speedOfMelt = values.speedOfMelt;
        Debug.Log(values.meltingScale + " is scale and " + values.speedOfMelt + " is speed");
    }
    #endregion
    public void ReturnToIce()
    {
        if (this.gameObject.GetComponent<PhaseChange>() == null)
        {
            phaseChange = this.gameObject.AddComponent<PhaseChange>();
        }
        else
        {
            phaseChange = this.gameObject.GetComponent<PhaseChange>();
        }
        phaseChange.RevertChange();
        this.gameObject.GetComponent<Element>().SetOriginalScale();

        ApplyTexturesAndPhysicsMats(ElementType.Ice);

    }

    public void MeltIce()
    {

        if (this.gameObject.GetComponent<PhaseChange>() == null)
        {
            phaseChange = this.gameObject.AddComponent<PhaseChange>();
        }
        else
        {
            phaseChange = this.gameObject.GetComponent<PhaseChange>();
        }

        ElementType original = GetComponent<Element>().CurrentType;
        phaseChange.ChangePhase(original, ElementType.Water);

        ApplyTexturesAndPhysicsMats(ElementType.Water);


        if (this.gameObject.GetComponent<Element>().OriginalType == ElementType.Water)
        {
            newScale = this.gameObject.GetComponent<Element>().OriginalScale;

        }
        else
        {
            currentScale = transform.localScale;
            newScale = currentScale + MeltExpansion;
        }
        StartTimer();
        StartCoroutine(Melt(newScale));

    }

    IEnumerator Melt(Vector3 scale)
    {


        while (Time.time <= endTime)
        {
            yield return new WaitForEndOfFrame();
            //Debug.Log("In Loop");
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, scale, speedOfMelt * Time.deltaTime);

        }
        if (Time.time > endTime)
        {
            //Debug.Log("Left Loop");
            StopMelt(scale);
        }
    }

    void StartTimer()
    {
        if (!melt)
        {
            startTime = Time.time;
            timeRate = speedOfMelt + 1f;
            endTime = startTime + timeRate;
            melt = true;
        }

    }

    void StopMelt(Vector3 scale)
    {
        StopCoroutine(Melt(scale));
        melt = false;
    }

    private void ApplyTexturesAndPhysicsMats(ElementType type)
    {
        if (this.gameObject.GetComponent<Renderer>() != null)
        {
            Renderer rend = this.gameObject.GetComponent<Renderer>();

            if (type == ElementType.Water)
            {
                EffectsManager.Instance.AddWaterTexture(rend);
            }else if (type == ElementType.Ice)
            {
                EffectsManager.Instance.AddIceTexture(rend);
            }

        }
            else if (this.gameObject.GetComponentInChildren<Renderer>() != null)
            {
            Renderer rend = this.gameObject.GetComponentInChildren<Renderer>();

            if (type == ElementType.Water)
            {
                EffectsManager.Instance.AddWaterTexture(rend);
            }else if (type == ElementType.Ice)
            {
                EffectsManager.Instance.AddWaterTexture(rend);
            }
        }

        if (this.gameObject.GetComponent<Collider>() !=null)
        {
            Collider collider = this.gameObject.GetComponent<Collider>();
            
            if (type == ElementType.Water)
            {
               // EffectsManager.Instance.AddPhysicsWater(collider);

            }else if (type == ElementType.Ice)
            {
                //EffectsManager.Instance.AddPhysicsIce(collider);
            }
        }
    }
}
