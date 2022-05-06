using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelMenu : MonoBehaviour
{
    public GameObject coinCounter;
    public GameObject[] stars;

    private Text ccText;
    private int maxCoin;

    void Start()
    {
        ccText = coinCounter.GetComponent<Text>();
        ccText.text = CoinCounter.cCounter.coinCount.ToString();
        int coins = CoinCounter.cCounter.coinCount;

        if (coins > 1 && coins < 5)
        {
            for (int i = 0; i < 1; i++)
            {
                StartCoroutine(ShowStar(stars[i], i));
            }
        }

        else if (coins > 4 && coins < 10)
        {
            for (int i = 0; i < 2; i++)
            {
                StartCoroutine(ShowStar(stars[i], i));
            }
        }

        else if (coins > 9)
        {
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(ShowStar(stars[i], i));
            }
        }
    }

    private IEnumerator ShowStar(GameObject star, int sec)
    {
        yield return new WaitForSeconds(sec + 0.5f);
        Sequence s = DOTween.Sequence();
        s.Append(star.GetComponent<RectTransform>().DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f));
        s.Append(star.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0.5f));
    }

    void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}
