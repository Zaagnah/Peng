
using UnityEngine;

public class TempGaugeFireResults : MonoBehaviour {


    public void ExtinguishFire()
    {
        this.gameObject.GetComponent<CatchFire>().ExtinguishFire();
      //  Debug.Log("destroy this " + gameObject.name);
    }

    public void IgniteFire()
    {
        //Debug.Log("reignite fire");
        if (this.gameObject.GetComponent<CatchFire>() !=null )
        {
            if (this.gameObject.GetComponent<GetContactPoint>() !=null)
            {

                this.gameObject.GetComponent<CatchFire>().SetObjectAblaze(GetComponent<GetContactPoint>().Pos, GetComponent<GetContactPoint>().Rot);

            }else
            {
                Debug.Log("Doesnt have contact point");
            }
        }
        else
        {
            //this.gameObject.AddComponent<CatchFire>().SetObjectAblaze(transform.position, transform.rotation);
        }

    }
}
