
using UnityEngine;

public enum ElementType
{
    Water,
    Fire,
    Wood,
    Metal,
    Ice
}

public class Element : MonoBehaviour {

    ElementType originalType;
    public ElementType OriginalType
    {
        get
        {
            return originalType;
        }
    }
    [SerializeField]
    ElementType type;
    public ElementType CurrentType
    {
        get
        {
            return type;
        }

    }

    private Vector3 originalScale;
    public Vector3 OriginalScale
    {
        get
        {
            return originalScale;
        }
    }

    Renderer rend;
    EffectsManager effects;

    [Header("Use Effects Manager Textures")]
    public bool UseEffectsManagerTexture;

    [Header("Interaction Settings for this object")]
    public bool useManagerInteractValues = true;

    public bool UsingTriggers { get { return useTriggers; } }
    public bool UsingColliders { get { return useColliders; } }
    [Header("Interaction Settings if not using manager settings")]
    [SerializeField]
    private bool useTriggers = false;
    [SerializeField]
    private bool useColliders = true;

    public LayerMask ElementLayer { get { return elementLayer; } }
    private LayerMask elementLayer;
    public int Layer { get { return layer; } }
    private int layer;

    private void Awake()
    {
        this.gameObject.layer = 17;
        layer = 17;
        elementLayer = 1 << 17;
        //this.gameObject.layer = layer;
        SetTriggers();
        AddInteractionScripts();
        CheckErrors();
    }
    private void CheckErrors()
    {
        if (!useColliders && !useTriggers && !useManagerInteractValues)
        {
            Debug.LogError(this.gameObject.name + " needs to be using Effects Manager interact values or using colliders or using triggers. All fields can not be false");
        }
    }
    private void SetTriggers()
    {
        if (EffectsManager.Instance !=null && useManagerInteractValues)
        {
            
            useTriggers = EffectsManager.Instance.useTriggers;
            useColliders = EffectsManager.Instance.useColliders;

            
        }
        else if (EffectsManager.Instance == null && !useManagerInteractValues)
        {
            if (useColliders && useTriggers || !useColliders && !useTriggers)
            {
                Debug.LogError(" Triggers and colliders are incorrectly set in the effects class. Choose one.");
            }

            useColliders = UsingColliders;
            useTriggers = UsingTriggers;//defaults to colliders.
        }
        
    }

    private void Start()
    {
    

       
        FindManagerAndRenderer();
        originalType = type;
        originalScale = this.gameObject.transform.localScale;


        switch (type)
        {
            case ElementType.Fire:
                AddFireScripts();
                break;

            case ElementType.Wood:
                AddWoodScripts();
                break;

            case ElementType.Water:
                AddWaterScripts();
                break;

            case ElementType.Metal:
                //
                break;

            case ElementType.Ice:
                AddIceScripts();
                break;
        }
    }

    private void FindManagerAndRenderer()
    {
      

        if (GetComponent<Renderer>() != null)
        {
            rend = GetComponent<Renderer>();
        }
        else if (GetComponentInChildren<Renderer>() != null)
        {
            rend = GetComponentInChildren<Renderer>();
        }
        else
        {
            Debug.Log(this.gameObject.name + " does not have a renderer");
        }
    }

    private void AddIceScripts()
    {
        if (this.gameObject.GetComponent<TempGauge>() == null)
        {
            this.gameObject.AddComponent<TempGauge>();
        }

        if (rend !=null)
        {
            if (UseEffectsManagerTexture)
            {
                EffectsManager.Instance.AddIceTexture(rend);
            }
        }
        else
        {
            Debug.Log(this.gameObject.name + " has no RENDERER, can not apply material");
        }

    }
   private void AddWaterScripts()
    {
        if (this.gameObject.GetComponent<TempGauge>() == null)
        {
            this.gameObject.AddComponent<TempGauge>();
        }

        if (rend != null)
        {
            if (UseEffectsManagerTexture)
            {
                EffectsManager.Instance.AddWaterTexture(rend);
            }

        }
        else
        {
            Debug.Log(this.gameObject.name + " has no RENDERER, can not apply material");

        }


    }
    private void AddWoodScripts()
    {

        if (this.gameObject.GetComponent<TempGauge>() == null)
        {
            this.gameObject.AddComponent<TempGauge>();
        }

        if (rend !=null)
        {
            if (UseEffectsManagerTexture)
            {
                EffectsManager.Instance.AddWoodTexture(rend);
            }

        }
        else
        {
            Debug.Log(this.gameObject.name + " has no RENDERER, can not apply material");

        }
        

    }
    private void AddFireScripts()
    {
        if (this.gameObject.GetComponent<FireSpreadTimer>() == null)
        {
             this.gameObject.AddComponent<FireSpreadTimer>();
        }

        if (this.gameObject.GetComponent<TempGauge>() == null)
        {
            this.gameObject.AddComponent<TempGauge>();

        }

        if (this.gameObject.GetComponent<CatchFire>() == null)
        {
            this.gameObject.AddComponent<CatchFire>();
        }




    }
    private void AddInteractionScripts()
    {

        if (this.gameObject.GetComponent<PhaseChange>() == null)
        {
            this.gameObject.AddComponent<PhaseChange>();
        }

        if (useColliders)
        {
            if (this.gameObject.GetComponent<SetCollisionInteraction>() == null)
            {
                this.gameObject.AddComponent<SetCollisionInteraction>();
            }
        }
        else if (useTriggers)
        {
            if (this.gameObject.GetComponent<SetTriggerInteraction>() == null)
            {
                this.gameObject.AddComponent<SetTriggerInteraction>();
            }
        }else if (!useTriggers && !useColliders && !useManagerInteractValues)
        {
            Debug.Log("MUST CHOOSE ONE: COLLIDERS OR TRIGGERS FOR INTERACTIONS");
        }
    }


    public void SetAsType(ElementType eType)
    {
        type = eType;
    }
    public void GetElementType(out ElementType currentType)
    {
        currentType = type;
    }
    public void SetOriginalScale()
    {
        this.gameObject.transform.localScale = originalScale;
    }


}
