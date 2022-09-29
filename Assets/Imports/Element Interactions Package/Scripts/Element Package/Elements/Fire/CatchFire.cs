
using UnityEngine;

public class CatchFire : MonoBehaviour {

    GameObject fireclone;
    GameObject _clone;

    private ElementType savedType;

    public bool IsOnFire { get { return isOnFire; } }
    private bool isOnFire;
    public bool BeingDamage
    { get { return beingDamage; } }
    private bool beingDamage = false;

    private float catchOnFireTimer;
    private float nextCatchOnFire;

    [SerializeField]
    private float catchOnFireRate;
 

    public bool UseEffectsFirePrefab = true;
    bool usingEffectsFirePrefab { get { return UseEffectsFirePrefab; } }

    SetFireSpreadValues getValues;

    private void Awake()
    {
        AssignFirePrefab();
        AssignValues();
    }

    private void AssignFirePrefab()
    {
                if (usingEffectsFirePrefab)
                {
                    fireclone = EffectsManager.Instance.firePrefab;
                }
    }

    void Start () {

        catchOnFireTimer = Time.time;
        nextCatchOnFire = catchOnFireTimer + catchOnFireRate;
	}
    void AssignValues()
    {
        if (this.gameObject.GetComponent<SetFireSpreadValues>() != null)
        {
            getValues = this.gameObject.GetComponent<SetFireSpreadValues>();
        }else
        {
            getValues = this.gameObject.AddComponent<SetFireSpreadValues>();
        }
        getValues.SetValues();
        GetConvectionValues(getValues);
    }
    void GetConvectionValues(SetFireSpreadValues values)
    {
        catchOnFireRate = values.CatchOnFireRate;

    }
 
    public void SetObjectAblaze(Vector3 contactPoint, Quaternion rotation)
    {
        if (Time.time > nextCatchOnFire)
        {
            isOnFire = true;

            if (this.gameObject.GetComponent<Element>().CurrentType != ElementType.Fire)
            {
                if (EffectsManager.Instance.firePrefab != null)
                {
                    GameObject clone = Instantiate(EffectsManager.Instance.firePrefab, contactPoint, rotation);
                    clone.transform.SetParent(this.gameObject.transform);
                    SetFireCloneProperties(clone);
                    clone = _clone;
                    

                    ElementType savedType = this.gameObject.GetComponent<Element>().CurrentType;
                    this.gameObject.GetComponent<PhaseChange>().ChangePhase(savedType, ElementType.Fire);

                }
                else if (EffectsManager.Instance.firePrefab == null)
                {

                    Debug.Log("Missing firePrefab for " + this.gameObject.name);
                }


               

                if (!BeingDamage)
                {
                    beingDamage = true;
                }

                nextCatchOnFire = Time.time + catchOnFireRate;

            }
        }




    }

    private void SetFireCloneProperties(GameObject clone)
    {
        Element fire = clone.gameObject.AddComponent<Element>();
        fire.SetAsType(ElementType.Fire);
    }

    public void CreateFireVisuals(Vector3 contactPoint, Quaternion rotation)
    {
        if (EffectsManager.Instance.firePrefab !=null)
        {
            GameObject clone = Instantiate(EffectsManager.Instance.firePrefab, contactPoint, rotation);
            clone.transform.SetParent(this.gameObject.transform);
            
        }else
        {
            Debug.Log(this.gameObject.name + " is missing fire prefab on Effects Manager");
        }
      
    }

   

    




    public void ExtinguishFire()
    {
        //Debug.Log(this.gameObject.name + " is no longer on Fire");
        isOnFire = false;
        beingDamage = false;
        Destroy(_clone);

        if (this.gameObject != null)
        {
           if (this.gameObject.GetComponent<PhaseChange>() !=null)
            {
                ElementType type = this.gameObject.GetComponent<Element>().OriginalType;
                if (type != ElementType.Fire)
                {
                    this.gameObject.GetComponent<PhaseChange>().RevertChange();
                }else
                {
                   // Debug.Log("Original type was fire " + this.gameObject.name);
                }


            }

        } 
   
        }


    }



