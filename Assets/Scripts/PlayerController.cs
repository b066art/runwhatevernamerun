using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public GameObject coinBlastPrefab;
    public bool controlOn;

    [SerializeField]
    private float moveSpeed = 7.5f;
    
    [SerializeField]
    private float xSpeed = 25f;

    private Animator animator;
    private CharacterController controller;

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (controlOn)
        {
            Move();
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isRunning", true);

            controller.Move(Vector3.forward * moveSpeed * Time.deltaTime);

            if (Input.GetAxis("Mouse X") > 0)
            {
                controller.Move(Vector3.right * Mathf.Abs(Input.GetAxis("Mouse X")) * xSpeed * Time.deltaTime);
            }

            else if (Input.GetAxis("Mouse X") < 0)
            {
                controller.Move(Vector3.left * Mathf.Abs(Input.GetAxis("Mouse X")) * xSpeed * Time.deltaTime);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Instantiate(coinBlastPrefab, other.transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
            Destroy(other.gameObject);
            CoinCounter.cCounter.AddCoin();
        }

        if (other.tag == "Finish")
        {
            GameManager.gameMgn.ShowLevelMenu();
        }
    }
}
