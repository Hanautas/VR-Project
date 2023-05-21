using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public bool isActive;

    public void ToggleObject(GameObject toggleObject)
    {
        isActive = !isActive;

        toggleObject.SetActive(isActive);
    }
}