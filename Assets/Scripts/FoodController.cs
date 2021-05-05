using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public Data.ColorPick FoodColor;

    private void Start()
    {
        transform.Find("Food").GetComponent<MeshRenderer>().sharedMaterial.color = Data.GetColor(FoodColor);
    }
}
