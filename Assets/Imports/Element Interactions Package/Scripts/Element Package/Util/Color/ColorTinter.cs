
using UnityEngine;

public class ColorTinter : MonoBehaviour {

    Renderer rend;


    public void SetColorTintHot(float _currentTemp, float _burnTemp)
    {
        ElementType eType = this.gameObject.GetComponent<Element>().CurrentType;
        CheckRenderer();

        if (this.gameObject.GetComponent<Renderer>() != null)
        {
            rend = this.gameObject.GetComponent<Renderer>();
        }
        else if (this.gameObject.GetComponentInChildren<Renderer>() != null)
        {
            rend = this.gameObject.GetComponentInChildren<Renderer>();
        }
        else
        {
            Debug.Log(this.gameObject.name + " does not havea  renderer");
        }

        if (this.gameObject.GetComponent<ColorLerpHot>() != null)
        {
            ColorLerpHot tintColor = this.gameObject.GetComponent<ColorLerpHot>();
            tintColor.SetTintColorHot(_currentTemp, _burnTemp, eType, rend);
        }
        else
        {
            ColorLerpHot tintColor = this.gameObject.AddComponent<ColorLerpHot>();
            tintColor.SetTintColorHot(_currentTemp, _burnTemp, eType, rend);
        }
    }


    public void SetColorTintCold(float _currentTemp, float _freezeTemp)
    {
        ElementType eType = this.gameObject.GetComponent<Element>().CurrentType;
        CheckRenderer();



        if (this.gameObject.GetComponent<ColorLerpCold>() != null)
        {
            ColorLerpCold tintColor = this.gameObject.GetComponent<ColorLerpCold>();
            tintColor.SetTintColorCold(_currentTemp, _freezeTemp, eType, rend);
        }
        else
        {
            ColorLerpCold tintColor = this.gameObject.AddComponent<ColorLerpCold>();
            tintColor.SetTintColorCold(_currentTemp, _freezeTemp, eType, rend);
        }
    }

    private void CheckRenderer()
    {
        if (this.gameObject.GetComponent<Renderer>() !=null)
        {
            rend = this.gameObject.GetComponent<Renderer>();
        }else if (this.gameObject.GetComponentInChildren<Renderer>() !=null)
        {
            rend = this.gameObject.GetComponentInChildren<Renderer>();
        }else
        {
            Debug.Log(this.gameObject.name + " does not have a renderer...");
        }
    }
}
