using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text _crystalText;
    [SerializeField] Text _foodText;
    [SerializeField] GameObject _loseGamePanel;
    [SerializeField] GameObject _winGamePanel;

    void Start()
    {
        GameController.singleton.LoseGameAction += LoseGamePanelShow;
        GameController.singleton.WinGameAction += WinGamePanelShow;

    }

    void Update()
    {
        _crystalText.text = "Кристаллы: " + Mathf.Round(GameController.singleton.CrystalValue).ToString();
        _foodText.text = "Еда: " + Mathf.Round(GameController.singleton.FoodValue).ToString();
    }

    void LoseGamePanelShow()
    {
        Instantiate(_loseGamePanel, transform);
    }

    void WinGamePanelShow()
    {
        Instantiate(_winGamePanel, transform);
    }
}
