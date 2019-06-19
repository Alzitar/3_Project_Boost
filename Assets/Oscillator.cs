using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(0f,12f,0f); // just so you can see the script is on
    [SerializeField] float period = 4f; // time to complete full sinwave cycle

    float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos;

	// Use this for initialization
	void Start ()
    {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period; // grows continually from 0 to cycles, time divided by seconds.

        const float tau = Mathf.PI * 2; // pi * 2 = about 6.28 (just the tau number)

        float rawSinwave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinwave /2f +0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
