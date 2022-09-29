using System.Collections;
using UnityEngine;

public class TempGaugeWaterResults : MonoBehaviour {

    private PhaseChange phaseChange;
    private Vector3 expandToIce; 
    private Vector3 evaporate;
    private float speedOfEvaporation;
    private float iceExpandTime;
    private Renderer rend;
    private Vector3 currentScale;
    private Vector3 newScale;
    private Vector3 previousScale;
    private Vector3 originalScale;
    private Vector3 minScale = new Vector3(.1f, .1f, .1f);

    private bool vape = false;
    private float startTime;
    private float endTime;
    private float timeRate;

    private bool ice = false;
    private float timeRateIce;
    private float startIceTime;
    private float endTimeIce;

    bool reset;


    private void Awake()
    {
        AssignValues();//needs to be called in the awake
        
    }

    void AssignValues()
    {
        if (GameObject.FindGameObjectWithTag("WaterManager") == null)
        {
            if (this.gameObject.GetComponent<FreezeEvaporateProperties>() !=null)
            {
                FreezeEvaporateProperties values = this.gameObject.GetComponent<FreezeEvaporateProperties>();
                SetValues(values);
            }else
            {
                FreezeEvaporateProperties values = this.gameObject.AddComponent<FreezeEvaporateProperties>();
                SetValues(values);
            }
        }else
        {
            if (this.gameObject.GetComponent<FreezeEvaporateProperties>() != null)
            {
                FreezeEvaporateProperties values = this.gameObject.GetComponent<FreezeEvaporateProperties>();
                SetValues(values);
            }else
            {
                FreezeEvaporateManager values = GameObject.FindGameObjectWithTag("WaterManager").GetComponentInChildren<FreezeEvaporateManager>() as FreezeEvaporateManager;
                SetValues(values);
            }
        }
    }
    void SetValues(FreezeEvaporateProperties values)
    {
        Debug.Log("used default values");
        expandToIce = values.ExpandToIce;
        evaporate = values.Evaporate;
        speedOfEvaporation = values.SpeedOfEvaporation;
        iceExpandTime = values.IceExpandTime;
    }
    void SetValues(FreezeEvaporateManager values)
    {
        Debug.Log("used freeze manager" + " this " + values.expandToIce);
        expandToIce = values.expandToIce;
        evaporate = values.evaporate;
        speedOfEvaporation = values.speedOfEvaporation;
        iceExpandTime = values.iceExpandTime;
    }


    private void Start()
    {
        originalScale    = GetComponent<Element>().OriginalScale;
    }

    public void MakeIce()
    {

        if (this.gameObject.GetComponent<PhaseChange>() == null)
        {
            this.gameObject.AddComponent<PhaseChange>().ChangePhase(GetComponent<Element>().CurrentType, ElementType.Ice);
        }
        else
        {
            this.gameObject.GetComponent<PhaseChange>().ChangePhase(GetComponent<Element>().CurrentType, ElementType.Ice);
        }


        if (this.gameObject.GetComponent<Element>().OriginalType == ElementType.Ice)
        {
            newScale = this.gameObject.GetComponent<Element>().OriginalScale;

        }else
        {
            currentScale = transform.localScale;
            newScale = currentScale + expandToIce;
        }

        Freeze(newScale);
        //StartCoroutine(ExpandToIce(newScale));
        //StartCoroutine(Vape(newScale));
        CheckRenderer();

        Collider collider = this.gameObject.GetComponent<Collider>();
      

        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            reset = this.gameObject.GetComponent<Rigidbody>().isKinematic;
            this.gameObject.GetComponent<Rigidbody>().isKinematic.Equals(!reset);

        }

        EffectsManager.Instance.AddPhysicsIce(collider);

        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic.Equals(reset);

        }


    }

    private void Freeze(Vector3 iceExpandScale)
    {
        StartTimerIce();
        StartCoroutine(ExpandToIce(iceExpandScale));
    }
    private void CheckRenderer()
    {
        if (this.gameObject.GetComponent<Renderer>() != null)
        {
            rend = this.gameObject.GetComponent<Renderer>();
            rend.material = EffectsManager.Instance.iceMaterial;

        }
        else if (this.gameObject.GetComponentInChildren<Renderer>() != null)
        {
            rend = this.gameObject.GetComponentInChildren<Renderer>();
            rend.material = EffectsManager.Instance.iceMaterial;
        }else
        {
            Debug.Log(this.gameObject.name + " does not have a renderer...");
        }
    }
    public void Evaporate()
    {
        Vector3 original = GetComponent<Element>().OriginalScale;
        Vector3 newScale = transform.localScale + evaporate;
        
        StartTimerVape();
        StartCoroutine(Vape(newScale));

    }
    void StartTimerVape()
    {
        if (!vape)
        {
            startTime = Time.time;
            timeRate = speedOfEvaporation;
            endTime = startTime + timeRate;
            vape = true;
        }
     
    }

    void StartTimerIce()
    {
        if (!ice)
        {
            startIceTime = Time.time;
            timeRateIce = iceExpandTime;
            endTimeIce = startIceTime + timeRateIce;
            ice = true;
        }
    }

    IEnumerator ExpandToIce(Vector3 expandScale)
    {
        while (Time.time <= endTime)
        {
            yield return new WaitForEndOfFrame();
            this.gameObject.transform.localScale += new Vector3(transform.localScale.x * expandToIce.x, transform.localScale.y * expandToIce.y, transform.localScale.z * expandToIce.z) * Time.deltaTime;



            
        }
        if (Time.time > endTime)
        {
            StopIceExpand(expandScale);
        }
    

    }

    void StopIceExpand(Vector3 expandScale)
    {
        StopCoroutine(ExpandToIce(expandScale));
        ice = false;
    }
    IEnumerator Vape(Vector3 evaporateScale)
    {
       

        while (Time.time <= endTime)
        {
            yield return new WaitForEndOfFrame();
            Debug.Log("In Loop");

            this.gameObject.transform.localScale += new Vector3(transform.localScale.x * evaporate.x, transform.localScale.y * evaporate.y, transform.localScale.z * evaporate.z) * Time.deltaTime;
           
            if (this.transform.localScale.x > minScale.x)
            {
                Debug.Log(this.gameObject.name + " should probably be changed to air");
                //send this water into the air.
            }


        }
        if (Time.time > endTime)
        {
            StopVape(evaporate);
        }
       
        
        


    }

    void StopVape(Vector3 scale)
    {
        StopCoroutine(Vape(scale));
        vape = false;
        Debug.Log("Left Loop");
    }
}
