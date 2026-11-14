using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public Transform startpoint;
    public Transform endpoint;
    public float journeyLength;
    public Transform direction;
    public AnimationCurve curve;
    public Vector3 startPos;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startpoint.position;
        direction = endpoint;
        t = 0f;
        startPos = transform.position;
        journeyLength = Vector3.Distance(startPos,endpoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        t += speed * Time.deltaTime / journeyLength;
        t = Mathf.Clamp01(t);
        float a = curve.Evaluate(t);
        transform.position = Vector3.Lerp(startPos,direction.position,a);
        if (t >= 1)
        {
            direction = direction == endpoint ? startpoint : endpoint;
            t = 0f;
            startPos = transform.position;
            journeyLength = Vector3.Distance(startPos, direction.position);

        }
    }
}
