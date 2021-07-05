using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodDisplay : MonoBehaviour
{
    public FoodCounter fc;

    TextMeshProUGUI foodCount;

    void Start()
    {
        foodCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        foodCount.text = "Food Count: " + fc.count.ToString();
    }
}
