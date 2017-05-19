﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    int health = 100;
    int initialHealth;

    [SerializeField]
    bool godMode;

    private void Start()
    {
        initialHealth = health;
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, initialHealth);

        if (godMode)
        {
            health = initialHealth;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
<<<<<<< HEAD
        Destroy(gameObject);
=======

>>>>>>> ec792f55fda1041e98791741b9328b1782982ceb
    }

    public int Health
    {
        set
        {
            health = value;
        }
        get
        {
            return health;
        }
    }
}