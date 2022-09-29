
using UnityEngine;


public enum PhysicalType
{
    HoldAble

}


public class Physicality : MonoBehaviour
{

    [SerializeField]
    PhysicalType type;
    public PhysicalType Type
    {
        get
        {
            return type;
        }

    }

    private void Start()
    {
        if (type == PhysicalType.HoldAble)
        {
            if (this.gameObject.GetComponent<HoldAble>() == null)
            {
                this.gameObject.AddComponent<HoldAble>();
            }else
            {
                this.gameObject.GetComponent<HoldAble>();
            }
        }
    }
}








  

