using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        foreach (var mus in music)
        {
            if (mus != gameObject)
            {
                Destroy(mus);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }
        
    }

}
