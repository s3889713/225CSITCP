using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject CreditMenu;
    [SerializeField]
    private GameObject InstructionMenu;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject PauseButton;
    [SerializeField]
    private GameObject ForwardButton;
    [SerializeField]
    private GameObject MoveLeftButton;
    [SerializeField]
    private GameObject MoveRightButton;
    [SerializeField]
    private GameObject MoveDownButton;

    public void OnButtonClicked()
    {
        MainMenu.SetActive(false);
        CreditMenu.SetActive(true);
        Debug.Log("1");
    }

    public void CreditToMain()
    {
        CreditMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        PauseButton.SetActive(true);
        ForwardButton.SetActive(true);
        MoveLeftButton.SetActive(true);
        MoveDownButton.SetActive(true);
        MoveRightButton.SetActive(true);
    }

    public void Quit()
    {
        MainMenu.SetActive(false);
    }

    public void MainToInstruction()
    {
        MainMenu.SetActive(false);
        InstructionMenu.SetActive(true);
    }

    public void InstructionToMain()
    {
        InstructionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        ForwardButton.SetActive(true);
        MoveLeftButton.SetActive(true);
        MoveDownButton.SetActive(true);
        MoveRightButton.SetActive(true);
    }

    public void PauseToMain()
    {
        PauseMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void PauseAppearsP()
    {
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        ForwardButton.SetActive(false);
        MoveLeftButton.SetActive(false);
        MoveDownButton.SetActive(false);
        MoveRightButton.SetActive(false);
    }
}
