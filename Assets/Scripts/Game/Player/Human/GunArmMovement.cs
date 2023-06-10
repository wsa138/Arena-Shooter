using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunArmMovement : MonoBehaviour
{
    public Camera cam;

    private Transform armTransform;

    Vector3 mousePos;

    private void Awake()
    {
        armTransform = transform.Find("Arm");
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Use for actual movement.
    private void FixedUpdate()
    {
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 180;
        armTransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
