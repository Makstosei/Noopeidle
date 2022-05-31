using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.onGameStart += GameStartEvent;
    }
    private void OnDisable()
    {

        EventManager.onGameStart -= GameStartEvent;
    }

    void GameStartEvent()
    {
        gameObject.SetActive(false);

    }

}
