using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMenu : MonoBehaviour
{
    public bool isActive;
    public int currentHandInt;

    public Animator animator;

    public GameObject playerCanvas;
    public RectTransform playerCanvasTransform;

    public InputActionReference leftHandInput, rightHandInput;

    void Start()
    {
        playerCanvas.SetActive(false);
    }

    void Update()
    {
        leftHandInput.action.Enable();
        rightHandInput.action.Enable();

        leftHandInput.action.started += x => Activate(1);
        rightHandInput.action.started += x => Activate(2);
    }

    public void Activate(int handInt)
    {
        if (isActive && handInt == currentHandInt)
        {
            isActive = false;

            currentHandInt = 0;

            playerCanvas.SetActive(false);
        }
        else
        {
            isActive = true;

            currentHandInt = handInt;

            playerCanvas.SetActive(true);

            if (handInt == 1)
            {
                animator.SetInteger("HandInt", 1);

                playerCanvasTransform.pivot = new Vector2(0, 0);
            }
            else if (handInt == 2)
            {
                animator.SetInteger("HandInt", 2);

                playerCanvasTransform.pivot = new Vector2(1, 0);
            }
        }
    }
}