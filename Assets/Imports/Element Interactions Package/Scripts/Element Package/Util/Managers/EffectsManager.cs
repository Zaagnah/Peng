
using UnityEngine;

public class EffectsManager : UnitySingleton<EffectsManager> {

    [Header("Objects")]
    public GameObject firePrefab;

    [Header("Materials for Renderers")]
    public Material iceMaterial;
    public Material waterMaterial;
    public Material woodMaterial;

    [Header("Materials for Physics")]
    public PhysicMaterial icePhysicsMaterial;
    public PhysicMaterial waterPhysicsMaterial;

    [Header("Colors")]
    public Color hot;
    public Color cold;
   // public Color Cold;

        [Header("Interaction Settings for objects")]
        public bool useTriggers;
    public bool useColliders;


  
  
    public void AddPhysicsIce(Collider obj)
    {
        if (icePhysicsMaterial != null)
        {

            //PhysicMaterial icePhysics = icePhysicsMaterial;
            obj.material = icePhysicsMaterial;

        }
        else
        {
            Debug.Log(this.gameObject.name + " is missing ice PHYSICS MATERIAL on Effects Prefab");

        }
    }
    public void AddPhysicsWater(Collider obj)
    {
        if (waterPhysicsMaterial !=null)
        {
            obj.material = waterPhysicsMaterial;

        }else
        {
            Debug.Log(this.gameObject.name + " is missing water PHYSICS MATERIAL on Effects Prefab");

        }
    }

    public void AddWaterTexture(Renderer rendererToApplyTo)
    {
        if (waterMaterial !=null)
        {
            rendererToApplyTo.material = waterMaterial;
        }else
        {
            Debug.Log(this.gameObject.name + " is missing water material on Effects Prefab");
            return;
        }
    }
    public void AddIceTexture(Renderer rendererToApplyTo)
    {
        if (iceMaterial !=null)
        {
            rendererToApplyTo.material = iceMaterial;

        }else
        {
            Debug.Log(this.gameObject.name + " is missing Ice material on Effects Prefab");

            return;
        }
    }
    public void AddWoodTexture(Renderer rendererToApplyTo)
    {
        if (woodMaterial != null)
        {
            rendererToApplyTo.material = woodMaterial;

        }
        else
        {
            Debug.Log(this.gameObject.name + " is missing Wood material on Effects Prefab");

            return;
        }
    }
}
