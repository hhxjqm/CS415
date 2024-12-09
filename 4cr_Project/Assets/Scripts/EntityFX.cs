using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material defaultMat;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        defaultMat = sr.material;
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        yield return new WaitForSeconds(flashDuration);
        sr.material = defaultMat;
    }
}
