
using UnityEngine;

public class ColorLerpHot : MonoBehaviour {

    private Color startingColor;
    private float lerp;
    private float currentTemp;
    private float burnTemp;


    public void SetTintColorHot(float _CurrentTemp, float _BurnTemp, ElementType type, Renderer renderer)
    {
        if (gameObject.GetComponent<Element>().UseEffectsManagerTexture)
        {


            //Debug.Log("Starts setting tint...");
            currentTemp = Mathf.Abs(_CurrentTemp);
            burnTemp = Mathf.Abs(_BurnTemp);

            if (renderer.material.color != null)
            {

                startingColor = renderer.material.color;


            }
            else
            {
                Debug.Log(this.gameObject.name + " does not have a color with its renderer");
            }

            switch (type)
            {
                case ElementType.Wood:
                    DoTintWood(startingColor);
                    break;
                case ElementType.Water:
                    DoTintWater(startingColor);
                    break;
                case ElementType.Ice:
                    DoTintIce(startingColor);
                    break;
            }
        }
    }


    void DoTintWood(Color startingColor)
    {
        if (startingColor != null)
        {
            lerp = currentTemp / burnTemp;
            //Debug.Log(lerp + " is the lerp %");
            Color newColor = Color.Lerp(startingColor, EffectsManager.Instance.hot, lerp);
            this.gameObject.GetComponent<Renderer>().material.color = newColor;
            //rend.material.color = newColor;
        }
        else
        {
            //Debug.Log("Starting Color is null");
        }
    }
    void DoTintWater(Color startingColor)
    {
        if (startingColor != null)
        {
            lerp = currentTemp / burnTemp;
            //Debug.Log(lerp + " is the lerp %");
            Color newColor = Color.Lerp(startingColor, EffectsManager.Instance.hot, lerp);

            if (this.gameObject.GetComponent<Renderer>() !=null)
            {
                this.gameObject.GetComponent<Renderer>().material.color = newColor;

            }else if (this.gameObject.GetComponentInChildren<Renderer>() !=null)
            {
                this.gameObject.GetComponentInChildren<Renderer>().material.color = newColor;
            }else
            {
                Debug.Log(this.gameObject.name + " does not have a renderer...");
            }

            //rend.material.color = newColor;
        }
        else
        {
            //Debug.Log("Starting Color is null");
        }
    }
    void DoTintIce(Color startingColor)
    {
        if (startingColor != null)
        {
            lerp = currentTemp / burnTemp;
            //Debug.Log(lerp + " is the lerp %");
            Color newColor = Color.Lerp(startingColor, EffectsManager.Instance.hot, lerp);

            if (this.gameObject.GetComponent<Renderer>() !=null)
            {
                this.gameObject.GetComponent<Renderer>().material.color = newColor;
            }else if(this.gameObject.GetComponentInChildren<Renderer>() !=null)
            {
                this.gameObject.GetComponentInChildren<Renderer>().material.color = newColor;

            }else
            {
                Debug.Log(this.gameObject.name + " does not have a renderer....");
            }
            //rend.material.color = newColor;
        }
        else
        {
            //Debug.Log("Starting Color is null");
        }
    }

  
}
