using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [SerializeField]
    private int mLove, mHunger, mClean, mGrowth;
    [SerializeField]
    private Text mTxtPet, mTxtLove, mTxtHunger, mTxtClean, mTxtGrowth, mTxtFail;
    [SerializeField]
    private GameObject mFullStatus, mMessStatus, mDirtyStatus, mTiredStatus;
    [SerializeField]
    private Button mBtnFeed, mBtnClean, mBtnShower, mBtnPlay;

    private float mGrowTime = 10;
    private float mHungryTime = 3;
    private float mCleanTime = 20;
    private float mPlayTime = 10;
    private int mLoveEvol, mHungerEvol, mCleanEvol;
    private void Awake()
    {
        mTxtPet.text = "알";
        mBtnFeed.onClick.AddListener(feedPet);
        mBtnClean.onClick.AddListener(cleanRoom);
        mBtnShower.onClick.AddListener(takeShower);
        mBtnPlay.onClick.AddListener(playTogether);
    }
    private void FixedUpdate()
    {
        mTxtLove.text = string.Format("{0} / 100", mLove);
        mTxtHunger.text = string.Format("{0} / 100", mHunger);
        mTxtClean.text = string.Format("{0} / 100", mClean);
        mTxtGrowth.text = string.Format("{0} / 100", mGrowth);

        if(mGrowth < 100)
        {
            mGrowTime -= Time.deltaTime;
            if (mGrowTime <= 0)
            {
                mGrowth += 10;
                mGrowTime = 10;
            }
        }
        if(mGrowth >=100)
        {
            mLoveEvol = mLove;
            mHungerEvol = mHunger;
            mCleanEvol = mClean;
            if(mLoveEvol == 100 && mHungerEvol == 100 && mCleanEvol == 0)
            {
                mTxtPet.text = "<color=red>용";
            }
            else if (mLoveEvol != 100 && mHungerEvol == 100 && mCleanEvol != 0)
            {
                mTxtPet.text = "<color=maroon>타도";
            }
            else if (mLoveEvol == 100 && mHungerEvol != 100 && mCleanEvol != 0)
            {
                mTxtPet.text = "<color=yello>오리";
            }
            else if (mLoveEvol != 100 && mHungerEvol != 100 && mCleanEvol == 0)
            {
                mTxtPet.text = "<color=green>도마뱀";
            }
            else
            {
                mTxtFail.gameObject.SetActive(true);
            }
            mGrowth = 0;
        }
        if(mHungryTime <= 3 && mHungryTime >=0 )
        {
            mHungryTime -= Time.deltaTime;
            if (mHungryTime <= 0)
            {
                mFullStatus.SetActive(false);
                mBtnFeed.interactable = true;
            }
        }
        
        if(mClean >= 80)
        {
            mDirtyStatus.SetActive(true);
        }
        else if(mClean < 80)
        {
            mDirtyStatus.SetActive(false);
        }

        if(mCleanTime <= 10 && mCleanTime >= 0)
        {
            mCleanTime -= Time.deltaTime;
            if (mCleanTime <= 0)
            {
                mMessStatus.SetActive(true);
                mBtnClean.interactable = true;
            }
        }

        if(mPlayTime <= 10 && mPlayTime >= 0)
        {
            mPlayTime -= Time.deltaTime;
            if (mPlayTime <= 0)
            {
                mTiredStatus.SetActive(false);
                mBtnPlay.interactable = true;
            }
        }
    }
    private void feedPet()
    {
        mBtnFeed.interactable = false;
        if(mHunger +20 >= 100)
        {
            mHunger = 100;
        }
        else if(mHunger + 20 <100)
        {
            mHunger += 20;
        }
        if (mClean + 10 >= 100)
        {
            mClean = 100;
        }
        else if (mClean + 10 < 100)
        {
            mClean += 10;
        }
        mFullStatus.SetActive(true);
        mHungryTime = 3;
    }

    private void cleanRoom()
    {
        mBtnClean.interactable = false;
        mMessStatus.SetActive(false);
        if (mLove + 10 >= 100)
        {
            mLove = 100;
        }
        else if (mLove + 10 < 100)
        {
            mLove += 10;
        }
        mCleanTime = 10;
    }
    private void takeShower()
    {
        mBtnShower.interactable = false;
        mClean = 0;
    }
    private void playTogether()
    {
        mBtnPlay.interactable = false;
        mTiredStatus.SetActive(true);
        if (mLove + 10 >= 100)
        {
            mLove = 100;
        }
        else if (mLove + 10 < 100)
        {
            mLove += 10;
        }
        
        if (mHunger - 40 <= 0)
        {
            mHunger = 0;
        }
        else if (mHunger - 40 > 0)
        {
            mHunger -= 40;
        }

        if (mClean + 50 >= 100)
        {
            mClean = 100;
        }
        else if (mClean + 50 < 100)
        {
            mClean += 50;
        }

        mPlayTime = 10;
    }
}
