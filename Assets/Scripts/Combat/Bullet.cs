using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 50f;
    [SerializeField] ParticleSystem bulletHit = null;
    private Vector2 lastPosition;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.Translate(new Vector3(bulletSpeed, 0, 0) * Time.deltaTime);
        lastPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (lastPosition != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(lastPosition, transform.position);
            if (hit.collider != null)
            {
                Debug.Log(hit.point);
                if (bulletHit != null)
                {
                    bulletHit.Play();
                }
                Destroy(gameObject);
            }
        }


        // if (other.GetComponent<Transform>() != null)
        // {
        //     if (other.GetComponent<Target>() != null)
        //     {
        //         other.GetComponent<Target>().GetHit();
        //     }
        //     Destroy(gameObject);

        // }

    }
}
