using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log($"mousePos: {mousePos}");
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;

        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        // rb.rotation = angle;
        // Debug.Log(angle);

        float angle = Vector2.SignedAngle(Vector2.right, lookDir) -90f;
        transform.eulerAngles = new Vector3 (0, 0, angle);
    }
}