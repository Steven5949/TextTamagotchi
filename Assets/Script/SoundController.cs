using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private Button mBtnMusicOnOff, mBtnGameStart, mBtnGoMainMenu;
    [SerializeField]
    private Text mTxtMusic;
    [SerializeField]
    private AudioSource mMenuMusic, mGameMusic;
    [SerializeField]
    private int mMainMusic;
    private bool isMenuMusic, isGameMusic;
    void Start()
    {
        mMainMusic = StringHelper.MENU_MUSIC;
        mMenuMusic.Play();
        isMenuMusic = true;
        isGameMusic = false;
        mBtnMusicOnOff.onClick.AddListener(volumeControl);
        mBtnGameStart.onClick.AddListener(() => musicController(StringHelper.GAME_MUSIC));
        mBtnGoMainMenu.onClick.AddListener(() => musicController(StringHelper.MENU_MUSIC));
    }
    private void volumeControl()
    {
        if(isMenuMusic == true)
        {
            mMenuMusic.Pause();
            mTxtMusic.text = "음악 ON";
            mMainMusic = StringHelper.MENU_MUSIC;
            isMenuMusic = false;
            Debug.Log("menu music off");
        }
        else if(isGameMusic == true)
        {
            mGameMusic.Pause();
            mTxtMusic.text = "음악 ON";
            mMainMusic = StringHelper.GAME_MUSIC;
            isGameMusic = false;
            Debug.Log("game music off");
        }
        else if(isMenuMusic == false && isGameMusic == false)
        {
            if(mMainMusic == StringHelper.MENU_MUSIC)
            {
                mMenuMusic.Play();
                Debug.Log("menu music on");
                isMenuMusic = true;
            }
            if (mMainMusic == StringHelper.GAME_MUSIC)
            {
                mGameMusic.Play();
                Debug.Log("game music on");
                isGameMusic = true;
            }
            mTxtMusic.text = "음악 OFF";
        }
    }
    private void  musicController(int pMainMusic)
    {
        if(isMenuMusic == true && isGameMusic == false)
        {
            mMenuMusic.Stop();
            mGameMusic.Play();
            isMenuMusic = false;
            isGameMusic = true;
            mMainMusic = pMainMusic;
        }
        else if(isMenuMusic == false && isGameMusic == true)
        {
            mMenuMusic.Play();
            mGameMusic.Stop();
            isMenuMusic = true;
            isGameMusic = false;
            mMainMusic = pMainMusic;
        }
        else if(isMenuMusic == false && isGameMusic == false)
        {
            mMainMusic = pMainMusic;
        }
    }
}
