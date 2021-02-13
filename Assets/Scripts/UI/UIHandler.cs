using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    [SerializeField] GameObject journalUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            journalUI.SetActive(!journalUI.activeSelf);

        }
    }
}
