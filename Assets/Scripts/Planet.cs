using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Planet : MonoBehaviour
{

    [SerializeField] private bool isEnemy;
    [SerializeField] private Color _color;
    [SerializeField] private AudioClip deathSound;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isEnemy)
            {
                print(YandexGame.savesData.mobsKilled);
                YandexGame.savesData.mobsKilled++;
                YandexGame.SaveProgress();
                YandexGame.NewLeaderboardScores("Mobs", YandexGame.savesData.mobsKilled);
                GetComponent<SpriteRenderer>().color = new Color(_color.r, _color.g, _color.b, 0.6f);
                GetComponent<SpriteRenderer>().sprite = GameManager.Instance.Kliaksa;
                ParticleSystem particles = Instantiate(Saw.Instance.enemyCollision);
                particles.transform.position = transform.position;
                particles.startColor = new Color(_color.r, _color.g, _color.b, 1f);
                particles.Play();

                AudioSource deathSource = Instantiate(GameManager.Instance.winSound);
                deathSource.clip = deathSound;
                deathSource.Play();
                
                Destroy(GetComponent<BoxCollider2D>());

                GameManager.Instance.enemyList.Remove(gameObject);
                if (GameManager.Instance.enemyList.Count <= 0)
                {
                    GameManager.Instance.Win();
                }

                Destroy(deathSource.gameObject, 1f);
                Destroy(particles.gameObject, 1f);
            }
            else
            {
                print("Lose");
            }
        }
    }
}
