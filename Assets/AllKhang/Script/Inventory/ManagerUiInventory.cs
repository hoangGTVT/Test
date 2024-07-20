using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUiInventory : MonoBehaviour
{
    [SerializeField] private GameObject buttonShowInformationPlayer;
    [SerializeField] private GameObject panelInformationPlayer;
    [SerializeField] private GameObject buttonShowInventory;
    [SerializeField] private GameObject objcetInventory;




    public void ShowPanelInformationPlayer()
    {
        buttonShowInformationPlayer.SetActive(false);
        panelInformationPlayer.SetActive(true);
    }
    public void ShowInventory()
    {
        objcetInventory.SetActive(true);
    }
}
