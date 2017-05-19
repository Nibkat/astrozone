﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
<<<<<<< HEAD
=======

>>>>>>> ec792f55fda1041e98791741b9328b1782982ceb
    [SerializeField]
    GameObject powerUp;
    GameObject powerUpInstance;

    [SerializeField]
    Vector2 spawnDelay;

    float timer;

    [SerializeField]
    float spawnPointOffset = 2.5f;

    Vector2 horizontal;
    Vector2 vertical;

    [SerializeField]
    bool spawnWithX;

    private void Start()
    {
        timer = Random.Range(spawnDelay.x, spawnDelay.y);

        horizontal = new Vector2(
            Camera.main.ScreenToWorldPoint(Vector3.zero).x + spawnPointOffset,
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x - spawnPointOffset
        );

        vertical = new Vector2(
            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y - spawnPointOffset,
            Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y + spawnPointOffset
        );
    }

    private void Update()
    {
        timer -= Time.deltaTime * 2;

        if (timer <= 0 || (Input.GetKeyDown(KeyCode.X) && spawnWithX))
        {
            powerUpInstance = Instantiate(powerUp);
            powerUpInstance.transform.position = new Vector3(Random.Range(horizontal.x, horizontal.y), Random.Range(vertical.x, vertical.y));

            timer = Random.Range(spawnDelay.x, spawnDelay.y);
        }
    }
}