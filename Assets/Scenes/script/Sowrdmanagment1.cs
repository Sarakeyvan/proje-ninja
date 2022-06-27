using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sowrdmanagment1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int sowrd;
    public Text money;
    void Start()
    {
      sowrd = PlayerPrefs.GetInt("Money",0);
    }

    // Update is called once per frame
    void Update()
    {
          money.text= PlayerPrefs.GetInt("Money",0).ToString();
    }

    public void Addmoney()
    {
        sowrd++;
        PlayerPrefs.SetInt("Money" , sowrd);
    }
}
