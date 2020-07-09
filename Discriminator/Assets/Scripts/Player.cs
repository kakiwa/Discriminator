using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Joystick joystick = default;

    [Range(1.0f, 20.0f)]
    [SerializeField] private float speed = 1.0f;

    [SerializeField] private Sprite[] sprites = default;

    private Rigidbody2D rb = default;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void setColorState(COLOR_STATE colorState)
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)colorState];
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }
}
