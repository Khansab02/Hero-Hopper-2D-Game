using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    Rigidbody rb;
    float speed = 1f;
    private Transform currpos;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currpos = pointB.transform;
    }
    private void Update()
    {
        Vector2 point = currpos.position-transform.position;
        if(currpos==pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if(Vector2.Distance(transform.position, currpos.position)<0.5f && currpos==pointB.transform)
        {
            Flip();
            currpos = pointA.transform;
        }
        if(Vector2.Distance(transform.position,currpos.position)<0.5f && currpos==pointA.transform)
        {
            Flip();
            currpos = pointB.transform;
        }
    }
    void  Flip()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
}
