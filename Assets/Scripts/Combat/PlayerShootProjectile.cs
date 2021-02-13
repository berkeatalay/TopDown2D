using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    [SerializeField] private Transform pfBullet;
    private void Awake()
    {
        GetComponent<PlayerAimWeapon>().OnShoot += PlayerShootProjectile_OnShoot;
    }

    private void PlayerShootProjectile_OnShoot(object sender, PlayerAimWeapon.OnShootEventArgs e)
    {
        Transform bulletTransform = Instantiate(pfBullet, e.gunEndPointPosition, Quaternion.identity);
        bulletTransform.eulerAngles = e.aimAngle;
    }
}
