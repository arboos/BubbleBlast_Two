using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Sprite Kliaksa;

    public List<GameObject> enemyList;
    public Animator Cell;

    public TextMeshProUGUI mobsKilled;

    public GameObject winMask;
    public GameObject pauseMask;
    
    [Header("Firework")]
    public GameObject firework;
    public ParticleSystem[] fireworksParticles;
    
    [Header("Sounds")]
    public AudioSource launchSound;
    public AudioSource explosionSound;
    public AudioSource winSound;
    public AudioSource grass;
    public AudioSource stone;
    public AudioSource wood;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy").ToList();
    }

    public void Win()
    {
        Saw.Instance.gameObject.SetActive(false);
        Cell.SetTrigger("Win");

        
        if (SceneManager.GetActiveScene().buildIndex > YandexGame.savesData.levelsReached)
        {
            YandexGame.savesData.levelsReached = SceneManager.GetActiveScene().buildIndex;
            YandexGame.SaveProgress();
        }

        mobsKilled.text = YandexGame.savesData.mobsKilled.ToString();
        
        StartCoroutine(WinIen());
    }

    public IEnumerator WinIen()
    {
        yield return new WaitForSeconds(0.5f);
        firework.SetActive(true);
        launchSound.Play();
        winSound.Play();

        yield return new WaitForSeconds(1.5f);
        foreach (var particle in fireworksParticles)
        {
            particle.Play();
        }
        explosionSound.Play();
        
        yield return new WaitForSeconds(2f);

        firework.SetActive(false);
        foreach (var particle in fireworksParticles)
        {
            particle.gameObject.SetActive(false);
        }
        
        winMask.SetActive(true);
    }

    public void LoadNext()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMask.SetActive(true);
    }
    
    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMask.SetActive(false);
    }
}
