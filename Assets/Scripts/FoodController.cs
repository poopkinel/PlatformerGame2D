using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public FoodCounter foodCounter;

    public GameObject UIImage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foodCounter.count--;
            Destroy(gameObject);
            Destroy(UIImage);
        }
    }
}
