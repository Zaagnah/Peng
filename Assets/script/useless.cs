using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useless : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        Animator anim = new Animator();   
    }

    public void PlayAnim()
    {
        anim.Play("jump");
    }
}
