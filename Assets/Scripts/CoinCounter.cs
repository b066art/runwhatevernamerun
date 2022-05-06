using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter cCounter;
    public Image coinIcon;
    public int coinCount;
    
    private Text ccText;

    void Awake()
    {
        cCounter = this;
    }

    void Start()
    {
        ccText = GetComponent<Text>();
    }

    void Update()
    {
        ccText.text = coinCount.ToString();
    }

    public void AddCoin()
    {
        coinCount++;
        Sequence s = DOTween.Sequence();
        s.Append(coinIcon.rectTransform.DOShakeAnchorPos(0.25f, 5, 20, 50, true));
    }
}
