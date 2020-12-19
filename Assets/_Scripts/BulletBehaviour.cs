﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float range;
    public float radius;
    public bool debug;
    public bool isColliding;
    public Vector3 collisionNormal;
    public float penetration;
    public float mass;
    public float restitution;
    public float friction;
    public Vector3 vel;
    public BulletManager bulletManager;
    //public RigidBody3D rb ;//= new RigidBody3D();

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
       // var rb=gameObject.GetComponent<RigidBody3D>();
        restitution=0.8f;
        friction=0.8f;
        mass=1.0f;
        
        radius = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.5f;
        bulletManager = FindObjectOfType<BulletManager>();
       vel=direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        //rb.velocity+=direction * speed*Time.deltaTime;

        transform.position += vel * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > range)
        {
            bulletManager.ReturnBullet(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.magenta;

            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}