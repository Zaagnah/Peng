
using UnityEngine;

public class GetContactPoint : MonoBehaviour {
    //first contact point
    private Quaternion rot;
    public Quaternion Rot
    {
        get
        {
            return rot;
        }
    }
    private Vector3 pos;
    public Vector3 Pos
    {
        get
        {
            return pos;
        }

    }

    ContactPoint contact;


    public void SetFirstContactPoint(Collision collision)
    {
        contact = collision.contacts[0];
        rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        pos = contact.point;
    }

    public void SetFirstContactPoint()
    {

        pos = transform.position;
        rot = transform.rotation;
        
    }

    public void GetFirstContactPoint(out Vector3 firstContactPoint, out Quaternion firstContactPointRot)
    {
        firstContactPoint = pos;
        firstContactPointRot = rot;
    }

    public void SetContactPoint(Vector3 point, Quaternion rotation)
    {
         pos = point;
        rot = rotation;
    }
}
