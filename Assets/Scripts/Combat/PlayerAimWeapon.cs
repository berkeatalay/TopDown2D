using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] private Transform aimTransform = null;
    [SerializeField] private Transform shootTransform = null;
    [SerializeField] private Transform aimShellPositionTransform;

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector2 shootPosition;
        public Vector2 shellPosition;
        public Vector3 aimAngle;
    }

    private Vector2 aimDirection;
    private float aimAngle;

    private void Awake()
    {

    }


    private void Update()
    {
        if (aimTransform == null) return;
        HandleAiming();
        if (shootTransform == null) return;
        HandleShooting();

    }

    private void HandleAiming()
    {
        Vector2 mousePosition = GetMouseWorldPosition();
        aimDirection = (mousePosition - (Vector2)transform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        Vector3 aimlocalScale = Vector3.one;

        if (aimAngle > 90 || aimAngle < -90)
        {
            aimlocalScale.y = -1f;
        }
        else
        {
            aimlocalScale.y = 1f;
        }

        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);
        aimTransform.localScale = aimlocalScale;
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = GetMouseWorldPosition();

            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = shootTransform.position,
                shootPosition = mousePosition,
                shellPosition = aimShellPositionTransform.position,
                aimAngle = new Vector3(0, 0, aimAngle)

            });

        }
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
}
