using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Публичная переменная для лопатки, будет ассоциироваться с префабом Pad
    public Pad pad;

    // Публичная переменная для лопатки, будет ассоциироваться с префабом Pad
    public Ball ball;

    // Публичная переменная со значением нижнего левого угла экрана
    public static Vector2 bottomLeft;

    // Публичная переменная со значением верхнего правого угла экрана
    public static Vector2 topRight;

    void Start()
    {
    	// получаем значение нижнего левого угла экрана
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));

        // получаем значение верхнего правого угла
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        // Создаем шар
        Instantiate(ball);

        // Создаем две лопатки	
        Pad padVar1 = Instantiate (pad) as Pad;        
        Pad padVar2 = Instantiate (pad) as Pad;
        padVar1.Init (true); // Инциализируем левую лопатку
        padVar2.Init (false); // Инциализируем правую лопатку
    }

}
