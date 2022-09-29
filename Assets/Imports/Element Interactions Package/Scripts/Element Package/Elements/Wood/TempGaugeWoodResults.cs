
using UnityEngine;

public class TempGaugeWoodResults : MonoBehaviour {


    public void WoodSetFire()
    {
        if (this.gameObject.GetComponent<GetContactPoint>() != null)
        {

            Vector3 ignitePoint = this.gameObject.GetComponent<GetContactPoint>().Pos;

            if (this.gameObject.GetComponent<CatchFire>() == null)
            {
                this.gameObject.AddComponent<CatchFire>().SetObjectAblaze(ignitePoint, transform.rotation);
            }
            else if (!this.gameObject.GetComponent<TempGauge>().OnFire)
            {
                this.gameObject.GetComponent<CatchFire>().SetObjectAblaze(ignitePoint, transform.rotation);
            }else

                return;
            }
            
    }
}
