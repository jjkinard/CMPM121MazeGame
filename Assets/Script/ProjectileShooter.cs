using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    Vector3 moveDir = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
if (Input.GetMouseButtonDown(0))
        {
            moveDir = new Vector3(0, 0, 1);
            moveDir *= 20;
            moveDir = transform.TransformDirection(moveDir);
        }
        }
    }
