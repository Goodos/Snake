using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPointController : MonoBehaviour
{
    public Data.ColorPick PointColor;
    [SerializeField] private ParticleSystem[] _ps = new ParticleSystem[3];

    private void Start()
    {
        foreach (ParticleSystem ps in _ps)
        {
            var _colorOverLifeTime = ps.colorOverLifetime;
            _colorOverLifeTime.color = Data.GetColor(PointColor);
        }
    }
}
