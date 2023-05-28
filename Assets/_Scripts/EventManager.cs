using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action OnItemPicked;
    public event Action OnShooting;
    public void ItemPicked()
    {
        OnItemPicked?.Invoke();
    }
    public void Shooting()
    {
        OnShooting?.Invoke();
    }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != null && Instance != this) Destroy(this.gameObject);
    }




}
