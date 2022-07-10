using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Button mBtnStart, mBtnSettings, mBtnExit, mBtnCloseSettings, mBtnGameSettings, mBtnGoMainMenu;
    [SerializeField]
    private GameObject mMainMenuPanel, mGamePlayPanel, mSettingsPanel;
    void Start()
    {
        mBtnStart.onClick.AddListener(() => pageMover(mMainMenuPanel, mGamePlayPanel));
        mBtnSettings.onClick.AddListener(settingOpen);
        mBtnCloseSettings.onClick.AddListener(settingClose);
        mBtnGoMainMenu.onClick.AddListener(() => pageMover(mGamePlayPanel, mMainMenuPanel));
        mBtnGameSettings.onClick.AddListener(settingOpen);
        mBtnExit.onClick.AddListener(quitGame);
    }
    private void pageMover(GameObject pClosePanel, GameObject pOpenPanel)
    {
       pClosePanel.SetActive(false);
       pOpenPanel.SetActive(true);
    }
    private void settingOpen()
    {
        mSettingsPanel.SetActive(true);
    }
    private void settingClose()
    {
        mSettingsPanel.SetActive(false);
    }

    private void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
