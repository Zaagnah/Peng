
using UnityEngine;

public class FireProperties : MonoBehaviour {

    public float FreezeTemp {
        get
        {
            return freezeTemp;
        }
    }
    [SerializeField]
    private float freezeTemp = -5f;

    public float BurnTemp
    {
        get
        {
            return burnTemp;
        }
    }
    [SerializeField]
    private float burnTemp = 5f;

    public float MinTemp
    {
        get
        {
            return minTemp;
        }
    }
    [SerializeField]
    private float minTemp = -25f;

    public float MaxTemp
    {
        get
        {
            return maxTemp;
        }
    }
    [SerializeField]
    private float maxTemp = 25f;

    public float NextTouchRate
    {
        get
        {
            return nextTouchRate;
        }
    }
    [SerializeField]
    private float nextTouchRate = .1f;

 
}
