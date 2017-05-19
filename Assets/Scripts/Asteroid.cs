﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    GameObject miniAsteroid;

    [SerializeField]
    float forceOnHit;

    [HideInInspector]
    public bool isHit;

    Rigidbody2D rb;
    Vector2 force;

    [SerializeField]
    bool randomSprite;
    [SerializeField]
    Sprite[] sprites;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));

        if (randomSprite)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            if (GetComponent<PolygonCollider2D>())
            {
                Destroy(GetComponent<PolygonCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>();
            }
        }
    }

    private void Update()
    {
        if (isHit)
        {
            rb.AddForce(force * forceOnHit * Time.deltaTime, ForceMode2D.Force);
        }
    }

    public void Break()
    {
        if (!isHit)
        {
            for (int i = 0; i < 4; i++)
            {
                miniAsteroid = Instantiate(gameObject);
                miniAsteroid.transform.localScale = transform.localScale / 2;
                miniAsteroid.GetComponent<Asteroid>().isHit = true;
            }
        }

        Destroy(gameObject);
    }
}
