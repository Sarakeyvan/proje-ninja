using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanager : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
      SceneManager.LoadScene("menu");  
    }
}
