using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SuperShip : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Vector2 rawInput;

    // Update is called once per frame
    void Update()
    {
        NewMethod();
    }

    void NewMethod()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
