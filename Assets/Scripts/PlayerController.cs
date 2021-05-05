using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Color _currColor;
    private Rigidbody _rb;
    private float _speed;

    private float _crystalCounter = 0;
    private bool _feverCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameController.singleton.CrystalValue++;
            other.GetComponent<Animator>().Play("EatedCoin");
            _crystalCounter++;
        }

        if (other.CompareTag("ChangeColorPoint"))
        {
            GameController.singleton.NewColor(Data.GetColor(other.GetComponent<ColorPointController>().PointColor));
        }

        if (other.CompareTag("Food"))
        {
            if (Data.GetColor(other.GetComponent<FoodController>().FoodColor) == _currColor || _feverCheck)
            {
                GameController.singleton.FoodValue++;
                _crystalCounter = 0;
                other.GetComponent<Animator>().Play("EatedFood");
                GameController.singleton.SpawnTailSegment();
            } 
            else
            {
                GameController.singleton.LoseGameAction.Invoke();
            }
        }

        if (other.CompareTag("Block"))
        {
            if (!_feverCheck)
            {
                _crystalCounter = 0;
                GameController.singleton.LoseGameAction.Invoke();
            }
            else
            {
                _crystalCounter = 0;
                other.GetComponent<Animator>().Play("EatedBlock");
                GameController.singleton.SpawnTailSegment();
            }
        }

        if (other.CompareTag("Finish"))
        {
            GameController.singleton.WinGameAction.Invoke();
        }
    }

    void Start()
    {
        GameController.singleton._tails.Add(gameObject);
        _rb = GetComponent<Rigidbody>();
        _currColor = Data.GetColor(GameController.singleton.Data.FirstColor);
        transform.Find("Player").GetComponent<MeshRenderer>().sharedMaterial.color = _currColor;
        _speed = GameController.singleton.Data.StartSpeed;
        GameController.singleton.LoseGameAction += StopMovement;
        GameController.singleton.WinGameAction += StopMovement;
    }

    void Update()
    {
        _currColor = GameController.singleton.CurrentColor;
        if (_crystalCounter >= 3)
        {
            _crystalCounter = 0;
            _feverCheck = true;
            StartCoroutine(FeverMode());
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector3.forward * _speed;
        if (GameController.singleton._canMove)
        {
            Movement();
        }
    }

    void Movement()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 10f));
            //transform.Translate(new Vector3(Mathf.Lerp(transform.position.x, Mathf.Clamp(mousePos.x, -4f, 4f), 5f * Time.deltaTime), 0, 0));
            _rb.MovePosition(new Vector3(Mathf.Lerp(_rb.position.x, Mathf.Clamp(mousePos.x, -4f, 4f), 5f * Time.deltaTime), _rb.position.y, _rb.position.z));
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 10f));
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    _rb.MovePosition(new Vector3(Mathf.Lerp(_rb.position.x, Mathf.Clamp(mousePos.x, -4f, 4f), 5f * Time.deltaTime), _rb.position.y, _rb.position.z));
                    break;
                case TouchPhase.Stationary:
                    _rb.MovePosition(new Vector3(Mathf.Lerp(_rb.position.x, Mathf.Clamp(mousePos.x, -4f, 4f), 5f * Time.deltaTime), _rb.position.y, _rb.position.z));
                    break;
            }
        }
#endif
    }

    IEnumerator FeverMode()
    {
        _speed *= 3;
        _rb.MovePosition(new Vector3(0, _rb.position.y, _rb.position.z));
        GameController.singleton._canMove = false;
        yield return new WaitForSeconds(3);
        _speed /= 3;
        GameController.singleton._canMove = true;
        _feverCheck = false;
    }

    void StopMovement()
    {
        _feverCheck = false;
        GameController.singleton._canMove = false;
        _speed = 0;
    }
}

