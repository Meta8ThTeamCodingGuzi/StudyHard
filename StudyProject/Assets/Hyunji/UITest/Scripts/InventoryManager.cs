using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryUi;
    private bool InventoryOpen;

    public void Start()
    {
        InventoryOpen = false;
        InventoryUi.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            if (InventoryOpen == false)
            {
                InventoryUi.gameObject.SetActive(true);
            }

            else
            {
                InventoryUi.gameObject.SetActive(false);
            }

        }


    }





}