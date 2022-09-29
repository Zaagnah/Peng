using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchPlayer : MonoBehaviour {


    public GameObject target;
    public Vector3 offset;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");

        }

    }

    // Update is called once per frame
    void Update () {
        transform.position = target.transform.position - offset;
	}
}
