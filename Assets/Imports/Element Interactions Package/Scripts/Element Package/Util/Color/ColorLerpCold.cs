
using UnityEngine;

public class ColorLerpCold : MonoBehaviour {

    private Color originalColor;
    private Color lerpTowardsColor;
    private Renderer rend;

    private float lerp;
    private float currentTemp;
    private float freezeTemp;
	

    public void SetTintColorCold(float cTemp, float lowestTemp, ElementType type, Renderer renderer)
    {
        #region assign values for tinting
        currentTemp = Mathf.Abs(cTemp);
        freezeTemp = Mathf.Abs(lowestTemp);

        if (renderer != null)
        {
            originalColor = renderer.material.color;

        }else
        {
            Debug.Log(this.gameObject.name + " does not have a renderer to apply cold effects to");
        }

        if (EffectsManager.Instance.cold !=null)
        {
            lerpTowardsColor = EffectsManager.Instance.cold;
        }else
        {
            Debug.Log("Cold Color has not been assigned on the Effects class");
        }

        #endregion

        switch (type)
        {
            case ElementType.Wood:
                DoTintWood(originalColor);
                break;
            case ElementType.Water:
                DoTintWater(originalColor);
                break;
            case ElementType.Ice:
                DoTintIce(originalColor);
                break;
        }
    }


    void DoTintWood(Color startingColor)
    {
     
            lerp = currentTemp / freezeTemp;
           Color newColor = Color.Lerp(startingColor, lerpTowardsColor, lerp);
            CheckRenderer();
            this.gameObject.GetComponent<Renderer>().material.color = newColor;
          
     
    }
    void DoTintWater(Color startingColor)
    {
 
            lerp = currentTemp / freezeTemp;
            Color newColor = Color.Lerp(startingColor, lerpTowardsColor, lerp);
            CheckRenderer();
            rend.material.color = newColor;
  
    }
    void DoTintIce(Color startingColor)
    {
      

            lerp = currentTemp / freezeTemp;
            Color newColor = Color.Lerp(startingColor, lerpTowardsColor, lerp);
            CheckRenderer();
            rend.material.color = newColor;
   
    }

    void CheckRenderer()
    {
        if (this.gameObject.GetComponent<Renderer>() !=null)
        {
            rend = this.gameObject.GetComponent<Renderer>();
        }else if (this.gameObject.GetComponentInChildren<Renderer>() !=null)
        {
            rend = this.gameObject.GetComponentInChildren<Renderer>();
        }else
        {
            Debug.Log(this.gameObject.name + " does not have a renderer....");
        }
    }
}
