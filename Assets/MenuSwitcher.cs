using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditMenu;

    public void SwitchMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        creditMenu.SetActive(!creditMenu.activeSelf);
    }
}

