using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager gameMgn;
    public GameObject coinPrefab;
    public GameObject levelMenu;
    public GameObject uiPanel;
    public GameObject goText;

    void Awake()
    {
        gameMgn = this;
    }

    void Start()
    {
        SpawnCoins();
        StartGame();
    }

    private void SpawnCoins()
    {
        float[] coinPosX = {-1.5f, 0, 1.5f};

        GameObject[] piers;

        piers = GameObject.FindGameObjectsWithTag("Pier");

        foreach (GameObject pier in piers)
        {
            Instantiate(coinPrefab, pier.transform.position + new Vector3(coinPosX[Random.Range(0, 3)], 0.5f, 0), new Quaternion(0, 90, 0, 1));
        }
    }

    private void StartGame()
    {
        StartCoroutine(ShowGoText());
        StartCoroutine(WaitAndStart());
    }

    private IEnumerator ShowGoText()
    {
        yield return new WaitForSeconds(1f);

        Sequence s = DOTween.Sequence();

        s.Append(goText.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0.75f));
        s.Append(goText.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), 0.75f));
    }

    private IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(2.5f);
        uiPanel.SetActive(true);
        PlayerController.player.controlOn = true;
    }

    public void ShowLevelMenu()
    {
        PlayerController.player.controlOn = false;
        levelMenu.SetActive(true);
        levelMenu.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0.75f);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
