using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class UI_Menu : MonoBehaviour
{
    public static UI_Menu Instance { get; private set; }

    public Sprite redButton;
    public Sprite greenButton;
    public TextMeshProUGUI mobsKilled;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject[] buttons;

    public int LevelsReached;
    
    private void Start()
    {
        
        
        LevelsReached = YandexGame.savesData.levelsReached;

        mobsKilled.text = YandexGame.savesData.mobsKilled.ToString();
        if (LevelsReached < 10)
        {
            LevelsReached++;
        }

        foreach (var button in buttons)
        {
            button.GetComponent<Button>().interactable = false;
            button.GetComponent<Image>().sprite = redButton;
        }
        
        for (int i = 0; i < LevelsReached; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].GetComponent<Image>().sprite = greenButton;
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    
}
