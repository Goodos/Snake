using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MonoBehaviour
{
    private int tailIndex;

    void GetIndex(int index)
    {
        tailIndex = index - 1;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, GameController.singleton._tails[tailIndex].transform.position.x, 5f * Time.deltaTime), transform.position.y, GameController.singleton._tails[tailIndex].transform.position.z - 1.5f);
    }
}
