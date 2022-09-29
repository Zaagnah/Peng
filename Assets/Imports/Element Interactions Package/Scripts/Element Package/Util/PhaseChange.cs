using System.Collections;
using UnityEngine;

public class PhaseChange : MonoBehaviour {

    float startTime;
    float iRate = 3f;
    float nextPhaseChangeTime;

    private ElementType previousElement;
    public ElementType PreviousElement
    {
        get
        {
            return previousElement;
        }
    }

    IEnumerator IFrameTimer(float timer)
    {
        
        while (Time.time < timer)
        {
            yield return new WaitForSeconds(iRate);
            this.gameObject.GetComponent<TempGauge>().AllowTempChanges(false);
            //Debug.Log("disallowed temp changes:");
        }

        this.gameObject.GetComponent<TempGauge>().AllowTempChanges(true);

        StopCoroutine(IFrameTimer(timer));


    }

    public void ChangePhase(ElementType originalEle, ElementType typeToChangeTowards)
    {
        

        SetPreviousElement(originalEle);
        this.gameObject.GetComponent<Element>().SetAsType(typeToChangeTowards);
        //reload scripts
       // Destroy(this.gameObject.GetComponent<Element>());
        //this.gameObject.AddComponent<Element>().SetAsType(typeToChangeTowards);
        this.gameObject.GetComponent<TempGauge>().AssignTemperatureValues();
        this.gameObject.GetComponent<TempGauge>().SetTempToNormal();

        iFrameTimer();

    }

  

    void SetPreviousElement(ElementType type)
    {
        previousElement = type;
    }

    public void RevertChange()
    {
        this.gameObject.GetComponent<Element>().SetAsType(previousElement);
        this.gameObject.GetComponent<TempGauge>().AssignTemperatureValues();
        this.gameObject.GetComponent<TempGauge>().SetTempToNormal();
        iFrameTimer();
    }


    private void iFrameTimer()
    {
        this.gameObject.GetComponent<TempGauge>().AllowTempChanges(false);

        startTime = Time.time;
        nextPhaseChangeTime = startTime + iRate;
        //Debug.Log(nextPhaseChangeTime + " iframe TIMER");
        StartCoroutine(IFrameTimer(nextPhaseChangeTime));
    }

}
