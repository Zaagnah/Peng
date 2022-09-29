
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartiScript : MonoBehaviour
{
    public ParticleSystem part1;

    private void OnCollisionEnter(Collision collision)
    {
        part1.Play();
    }

}
