
using UnityEngine;

public class SetFireHitReactionValues : MonoBehaviour {

    public float FireIncreaseWood;
    public float FireIncreasesWater;
    public float FireIncreasesIceOnTouch;
    public float WoodIncreasesFire;
    public float WaterDecreasesFire;
    public float IceDecreasesFire;


    public void SetValues()
    {
        if (GameObject.FindGameObjectWithTag("FireManager")== null)
        {
            if (this.gameObject.GetComponent<FireReactionProperties>() !=null)
            {
                FireReactionProperties reactionValues = this.gameObject.GetComponent<FireReactionProperties>();
                SetReactionValues(reactionValues);
            }else
            {
                FireReactionProperties reactionValues = this.gameObject.AddComponent<FireReactionProperties>() as FireReactionProperties;
                SetReactionValues(reactionValues);
            }
        }else
        {
            if (this.gameObject.GetComponent<FireReactionProperties>() == null)
            {
                FireHitTemperatureReactionsManager reactionValues = GameObject.FindGameObjectWithTag("FireManager").GetComponentInChildren<FireHitTemperatureReactionsManager>() as FireHitTemperatureReactionsManager;
                SetReactionValues(reactionValues);
            }else
            {
                FireReactionProperties reactionValues = this.gameObject.AddComponent<FireReactionProperties>() as FireReactionProperties;
                SetReactionValues(reactionValues);
            }
        }
    }

    void SetReactionValues(FireReactionProperties values)
    {
        FireIncreaseWood = values.FireIncreaseWood;
     FireIncreasesWater = values.FireIncreasesWater;
     FireIncreasesIceOnTouch = values.FireIncreasesIceOnTouch;
        WoodIncreasesFire = values.WoodIncreasesFire ;
        WaterDecreasesFire = values.WaterDecreasesFire;
        IceDecreasesFire = values.IceDecreasesFire;
}

    void SetReactionValues(FireHitTemperatureReactionsManager values)
    {
        FireIncreaseWood = values.fireIncreasesWoodOnTouch;
        FireIncreasesWater = values.fireIncreasesWaterOnTouch;
        FireIncreasesIceOnTouch = values.fireIncreasesIceOnTouch;
        WoodIncreasesFire = values.woodIncreasesFireOnTouch;
        WaterDecreasesFire = values.waterDecreasesFireOnTouch;
        IceDecreasesFire = values.iceDecreasesFireOnTouch;
    }
}
