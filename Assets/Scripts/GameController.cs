using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController singleton { get; private set; }
    public bool _canMove = true;
    public List<GameObject> _tails = new List<GameObject>();
    public Data Data;
    public Color CurrentColor;
    public UnityAction LoseGameAction;
    public UnityAction WinGameAction;
    public float CrystalValue = 0;
    public float FoodValue = 0;

    [SerializeField] GameObject _tailPrefab;
    

    private void Awake()
    {
        singleton = this;
        Data = Resources.Load("Data") as Data;
    }

    void Start()
    {
        CurrentColor = Data.GetColor(Data.FirstColor);
        SpawnTailSegment();
    }

    void Update()
    {
        
    }

    public void SpawnTailSegment()
    {
        if (_tails.Capacity <= 5)
        {
            GameObject newTail = Instantiate(_tailPrefab);
            _tails.Add(newTail);
            newTail.SendMessage("GetIndex", _tails.IndexOf(newTail));
        }
    }

    public void NewColor(Color color)
    {
        CurrentColor = color;
        _tails[1].GetComponent<MeshRenderer>().sharedMaterial.color = color;
        //StartCoroutine(SetColor(color));
    }

    IEnumerator SetColor(Color color)
    {
        foreach (GameObject tail in _tails)
        {
            if (tail.GetComponent<MeshRenderer>() != null)
            {
                tail.GetComponent<MeshRenderer>().sharedMaterial.color = color;
                yield return new WaitForSeconds(.5f);
            }
        }
    }

}
