using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public GameObject player;
    public GameObject finish;

    private Text progressText;
    private float dist;

    void Start()
    {
        progressText = GetComponent<Text>();
        dist = player.transform.position.z - finish.transform.position.z;
    }

    void Update()
    {
        float curPos = player.transform.position.z - finish.transform.position.z;
        float progress = 100 - (curPos * 100 / dist);
        progressText.text = Mathf.RoundToInt(progress).ToString() + "%";
    }
}
