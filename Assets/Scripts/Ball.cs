using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speedBreakpoint;
    [SerializeField] private float absSpeed;

    [SerializeField] Material material;
    [SerializeField] Color underBreakPoint;
    [SerializeField] Color overBreakPoint;

    private float underTime;
    private bool underMaterial;

    void Start()
    {
        
    }

    void Update()
    {
        absSpeed = Mathf.Abs(rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) < speedBreakpoint && !underMaterial)
        {
            material.color = underBreakPoint;
            underMaterial = true;
        }
        else if (Mathf.Abs(rb.velocity.y) > speedBreakpoint && underMaterial)
        {
            
            material.color = overBreakPoint;
            underMaterial = false;
        }

        if (underMaterial)
        {
            underTime += Time.deltaTime;
        }
        else if (!underMaterial && underTime != 0)
        {
            Debug.Log(underTime);
            underTime = 0;
        }
    }
}
