using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPersistenceManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarStat(string key)
    {
        int oldValue = PlayerPrefs.GetInt(key, 0);
        PlayerPrefs.SetInt(key, oldValue + 1);
        PlayerPrefs.Save();
    }

    public int GetValue(string key)
    {
        return (PlayerPrefs.GetInt(key, 0));
    }
}
