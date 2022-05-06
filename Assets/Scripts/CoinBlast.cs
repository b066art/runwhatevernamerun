using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlast : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
