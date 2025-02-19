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
        gameObject.SetActive(GetUIState() == state);//�� Ŭ������ getuistate�� �ڽ��� Ŭ������ ���� uistate�� ��ȯ�ϰ� �̸� �Ű������� ���� state�� ���ؼ� setactive�Ѵ�.
    }


}
