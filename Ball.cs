﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;

    }

    void Update()
    {
        // Обрабатываем движение шара
        transform.Translate(direction * speed * Time.deltaTime);
        
        // Обрабатываем столкновения с краями экрана
        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        // Обрабатываем выигрыш игрока
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            UnityEngine.Debug.Log("Right win");
        }

        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            UnityEngine.Debug.Log("Left win");
            direction.x = -direction.x;
        }
    }

    // Обрабатываем столкновение лопатки и шара
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Pad")
        {
            bool isRight = other.GetComponent<Pad>().isRightPad;
            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}
