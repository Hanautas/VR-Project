using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.SceneManagement;
using EVMC4U;

public class GameManager : MonoBehaviour
{
    public ExternalReceiver externalReceiver;

    [Header("UI")]
    public GameObject playerMenu;

    [Header("Avatar")]
    public Transform playerAvatar;

    public List<GameObject> avatars;

    [Header("Position")]
    public Transform origin;
    public Transform headRotation;
    public Transform headOffset;
    public Transform head;
    public Transform target;

    [Header("Data")]
    public PlayerData playerData;

    void Start()
    {
        Recenter();
    }

    [ContextMenu("Recenter")]
    public void Recenter()
    {
        //Position
        headOffset.localPosition = new Vector3(-head.localPosition.x, 0f, -head.localPosition.z);

        //Rotation
        headRotation.localEulerAngles = new Vector3(0f, 180f, 0f);
    }

    public void SetSize(float value)
    {
        float playerSize = playerAvatar.localScale.y + value;

        playerSize = Mathf.Clamp(playerSize, 0.1f, 2f);

        playerAvatar.localScale = new Vector3(playerSize, playerSize, playerSize);

        playerData.playerSize = playerSize;
    }

    public void SetPlayerAvatar(int index)
    {
        foreach (GameObject obj in avatars)
        {
            obj.SetActive(false);
        }

        avatars[index].SetActive(true);

        externalReceiver.Model = avatars[index];
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

        Application.Quit();
    }
}