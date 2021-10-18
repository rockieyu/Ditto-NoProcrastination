using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    #region
    [Header("Studied Status")]
    [SerializeField] GameObject Ring00;
    [SerializeField] GameObject Ring01;
    [SerializeField] GameObject Ring02;
    float currentTime;
    float currentFillAmount;
    float RealCurrentTime;
    float RealInitialTime;
    [SerializeField] float maxTime = 10800;
    [SerializeField] Slider Pointer;


    [Header("POP-UP")]
    [SerializeField] GameObject POP_Cover;
    bool isPOPing;

    [Header("Import Course")]
    [SerializeField] GameObject POP_ImportCourse;
    [SerializeField] GameObject Right_After;
    [SerializeField] Button Bt_ImportCourse;
    bool isImported;

    [Header("Friend List")]
    [SerializeField] Button Bt_HoverList;
    [SerializeField] GameObject Left_After;
    [SerializeField] GameObject POP_AddFriend;
    [SerializeField] GameObject Left_Before;
    bool isAddFriend;
    [SerializeField] GameObject BeforeImported;
    [SerializeField] GameObject AfterImported01;
    [SerializeField] GameObject AfterImported02;
    [SerializeField] GameObject AfterImported03;

    [Header("Assessment Info")]
    [SerializeField] GameObject POP_6500_Orange;
    [SerializeField] GameObject POP_7180_Red;

    [Header("Chat Pages")]
    [SerializeField] GameObject CHAT;
    bool isChat;

    [Header("Map Functions")]
    [SerializeField] GameObject MAP;
    bool isMap;
    [SerializeField] GameObject MapLocation;
    [SerializeField] GameObject SendText;

    [Header("Fake Demo")]
    [SerializeField] GameObject MAP_01;
    [SerializeField] GameObject FakeDEMO;
    [SerializeField] GameObject ButtonFake01;
    [SerializeField] GameObject ButtonFake02;
    [SerializeField] GameObject Typing;
    [SerializeField] GameObject Accepted;


    [Header("Quest Manager")]
    [SerializeField] Button Assessment6500;
    [SerializeField] Button Assessment7180;
    [SerializeField] GameObject DeleteLine6500;
    [SerializeField] GameObject DeleteLine7180;
    bool is6500Done;
    bool is7180Done;
    #endregion

    #region               [MAIN]
    // Start is called before the first frame update
    void Start()
    {
        RealInitialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCurrentValue();
        CheckBt_ImportCourse();
        CheckIsImported();
        CheckRelatedFriendList();
        CheckBt_HoverList();
        CheckForAddFriend();
        CheckPOP();
        CheckForPointer();
        CheckForRing();
    }

    #endregion

    #region ===== Studied Time
    
    void CheckForCurrentValue()
    {
        RealCurrentTime = Time.time;
        currentTime = RealCurrentTime - RealInitialTime;
        currentFillAmount = currentTime / maxTime;
        if (currentFillAmount >= 1)
        {
            currentFillAmount = 1;
        }

    }

    void CheckForPointer()
    {
        Pointer.value = currentFillAmount;
    }

    void CheckForRing()
    {
        if (currentFillAmount <= 0.33f)
        {
            Ring00.SetActive(true);
            Ring01.SetActive(false);
            Ring02.SetActive(false);
        }
        else if(currentFillAmount <= 0.66f)
        {
            Ring00.SetActive(false);
            Ring01.SetActive(true);
            Ring02.SetActive(false);
        }
        else
        {
            Ring00.SetActive(false);
            Ring01.SetActive(false);
            Ring02.SetActive(true);
        }
    }


    #endregion

    #region ===== POP-UP
    void CheckPOP()
    {
        POP_Cover.SetActive(isPOPing);
    }

    void SetPOP_True()
    {
        isPOPing = true;
    }

    void SetPOP_false()
    {
        isPOPing = false;
    }

    #endregion

    #region ===== Import Course Functions

    void CheckIsImported()
    {
        isImported = Right_After.activeSelf;
    }

    void CheckRelatedFriendList()
    {
        BeforeImported.SetActive(!isImported);
        AfterImported01.SetActive(isImported);
        AfterImported02.SetActive(isImported);
        AfterImported03.SetActive(isImported);
    }

    void CheckBt_ImportCourse()
    {
        if (Right_After.activeSelf)
        {
            Bt_ImportCourse.interactable = false;
        }
    }

    void ClosePOP_ImportedCourse()
    {
        POP_ImportCourse.SetActive(false);
        SetPOP_false();
    }

    public void OnClick_ImportCourse()
    {
        POP_ImportCourse.SetActive(true);
        SetPOP_True();
    }

    public void OnClick_Close_ImportedCourse()
    {
        ClosePOP_ImportedCourse();
    }

    public void OnClick_Confirm_ImportedCourse()
    {
        Right_After.SetActive(true);
        ClosePOP_ImportedCourse();
    }

    #endregion

    #region ===== Hover List
    void CheckBt_HoverList()
    {
        Bt_HoverList.interactable = isImported;
    }
    #endregion

    #region ===== Add Friend
    void CheckForAddFriend()
    {
        Left_After.SetActive(isAddFriend);
        Left_Before.SetActive(!isAddFriend);
    }

    public void OnClick_AddFriend()
    {
        POP_AddFriend.SetActive(true);
        SetPOP_True();
    }

    void ClosePOP_AddFriend()
    {
        POP_AddFriend.SetActive(false);
        SetPOP_false();
    }

    public void OnClick_Close_AddFriend()
    {
        ClosePOP_AddFriend();
    }

    public void OnClick_Send_AddFriend()
    {
        ClosePOP_AddFriend();
        isAddFriend = true;
    }

    #endregion

    #region ===== Assessment Info

    void CheckPOP_7180()
    {
        POP_7180_Red.SetActive(isPOPing);
    }

    void CheckPOP_6500()
    {
        POP_6500_Orange.SetActive(isPOPing);
    }

    public void OnClick_7180_POP()
    {
        SetPOP_True();
        CheckPOP_7180();
    }

    public void OnClick_Close_7180()
    {
        SetPOP_false();
        CheckPOP_7180();
    }

    public void OnClick_6500_POP()
    {
        SetPOP_True();
        CheckPOP_6500();
    }

    public void OnClick_Close_6500()
    {
        SetPOP_false();
        CheckPOP_6500();
    }


    #endregion

    #region ===== Open Chat Pages

    public void OnClick_ChatInFriend()
    {
        isChat = !isChat;
        CheckChatInFriendList();
    }

    void CheckChatInFriendList()
    {
        CHAT.SetActive(isChat);
    }

    void Close_Chat()
    {
        CHAT.SetActive(false);
    }

    public void OnClick_Close_Chat()
    {
        //TODO: initial the Chat Page

        isChat = false;
        CheckChatInFriendList();
    }

    #endregion

    #region ===== Map Function

    public void OnClick_MapButton_Trigger()
    {
        isMap = !isMap;
        CheckMapInTrigger();
    }

    void CheckMapInTrigger()
    {
        MAP.SetActive(isMap);
    }

    void CloseMAP()
    {
        isMap = false;
        CheckMapInTrigger();
    }

    public void OnClick_Close_MapButton()
    {
        CloseMAP();
    }

    #endregion

    #region ===== Map: Open Location

    public void OnClick_OpenMapLocation()
    {
        Location_Open();
    }

    void Location_Open()
    {
        MapLocation.SetActive(true);
    }

    public void OnClick_CloseMapLocation()
    {
        Location_Close();
    }

    void Location_Close()
    {
        MapLocation.SetActive(false);
    }

    #endregion

    #region ===== Map: Select Location

    public void OnClick_SelectLocation()
    {
        ShowSendText();
    }

    void ShowSendText()
    {
        SendText.SetActive(true);
    }

    void HideSendText()
    {
        SendText.SetActive(false);
    }

    void ShowMap_01()
    {
        MAP_01.SetActive(true);
    }

    public void OnClick_SendText()
    {
        HideSendText();
        CloseMAP();
        ShowMap_01();
        ShowFakeDemo();
    }

    void ShowFakeDemo()
    {
        FakeDEMO.SetActive(true);
    }

    #endregion

    #region ===== Fake Demo

    public void OnClick_FakeDemo_01()
    {
        ButtonFake01.SetActive(false);
        ShowTyping();
    }

    public void OnClick_FakeDemo_02()
    {
        ButtonFake02.SetActive(false);
        HideTyping();
        ShowAccepted();
    }

    void ShowTyping()
    {
        Typing.SetActive(true);
    }

    void HideTyping()
    {
        Typing.SetActive(false);
    }

    void ShowAccepted()
    {
        Accepted.SetActive(true);
    }
    #endregion

    #region ===== Quest Manager

    public void OnToggle_6500()
    {
        is6500Done = !is6500Done;
        if (is6500Done)
        {
            SetButton6500_Off();
            ShowDeleteLine_6500();
        }
        else
        {
            SetButton6500_On();
            HideDeleteLine_6500();
        }
    }

    public void OnToggle_7180()
    {
        is7180Done = !is7180Done;
        if (is7180Done)
        {
            SetButton7180_Off();
            ShowDeleteLine_7180();
        }
        else
        {
            SetButton7180_On();
            HideDeleteLine_7180();
        }
    }

    void SetButton6500_On()
    {
        Assessment6500.interactable = true;
    }

    void SetButton6500_Off()
    {
        Assessment6500.interactable = false;
    }

    void SetButton7180_On()
    {
        Assessment7180.interactable = true;
    }

    void SetButton7180_Off()
    {
        Assessment7180.interactable = false;
    }

    void ShowDeleteLine_6500()
    {
        DeleteLine6500.SetActive(true);
    }

    void HideDeleteLine_6500()
    {
        DeleteLine6500.SetActive(false);
    }

    void ShowDeleteLine_7180()
    {
        DeleteLine7180.SetActive(true);
    }

    void HideDeleteLine_7180()
    {
        DeleteLine7180.SetActive(false);
    }

    #endregion
}
