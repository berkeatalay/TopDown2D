using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractButton : MonoBehaviour
{
    [SerializeField] GameObject doorGameObject;
    [SerializeField] GameObject buttonUI = null;
    private IDoor door;
    private float interactRadius = 2f;
    private bool isUsed = false;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, interactRadius);
            foreach (Collider2D collider2D in collider2DArray)
            {
                if (collider2D.CompareTag("Player"))
                {
                    if (door != null)
                    {
                        door.ToggleDoor();
                        isUsed = !isUsed;
                        AdjustSprite();
                    }
                }

            }

        }
    }

    private void AdjustSprite()
    {
        if (isUsed)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isUsed)
        {
            spriteRenderer.color = Color.yellow;
        }

        buttonUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isUsed)
        {
            spriteRenderer.color = Color.red;
        }

        buttonUI.SetActive(false);
    }
}
