using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FoodCounter : MonoBehaviour
{
    public int count;

    void Start()
    {
        count = 6;
    }

    void Update()
    {
        if (count == 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
