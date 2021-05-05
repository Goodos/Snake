using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text _crystalText;
    [SerializeField] Text _foodText;

    void Start()
    {
        
    }

    void Update()
    {
        _crystalText.text = "Кристалов: " + Mathf.Round(GameController.singleton.CrystalValue).ToString();
        _foodText.text = "Еды: " + Mathf.Round(GameController.singleton.FoodValue).ToString();
    }
}
