using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected MiniGameUIManager_1 uiManager;

    public virtual void Init(MiniGameUIManager_1 uiManager)
    {
        this.uiManager = uiManager;
    }


    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIState() == state);//각 클래스의 getuistate는 자신의 클래스와 같은 uistate를 반환하고 이를 매개변수로 받은 state와 비교해서 setactive한다.
    }


}
