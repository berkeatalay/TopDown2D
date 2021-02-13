using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    [SerializeField] GameObject journalUI;
    [SerializeField] GameObject inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            journalUI.SetActive(!journalUI.activeSelf);

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

        }
    }
}
