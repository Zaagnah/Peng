
using UnityEngine;

public class HoldAble : MonoBehaviour {

    Rigidbody rb;

    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
        }
    }


    public void Hold(GameObject holder, Transform holdPosition)
    {
        if (rb)
        {
            Destroy(rb);
          
        }
        this.gameObject.transform.SetParent(holder.transform);
        this.gameObject.transform.position = holdPosition.transform.position;
    }

    public void Drop()
    {
        this.gameObject.transform.parent = null;

        if (!rb)
        {
            rb = this.gameObject.AddComponent<Rigidbody>();
            
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
