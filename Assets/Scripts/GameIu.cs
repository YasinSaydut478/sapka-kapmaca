using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using System.Runtime.CompilerServices;

public class GameIu : MonoBehaviour
{
    public PlayerUIContainer[] playerContainers;
    public TextMeshProUGUI winText;

    public static GameIu instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitializePlayerUI();
    }

    void InitializePlayerUI()
    {
        for(int x = 0; x < playerContainers.Length; ++x)
        {
            PlayerUIContainer container = playerContainers[x];

            if (x < PhotonNetwork.PlayerList.Length)
            {
                container.obj.SetActive(true);
                container.nameText.text = PhotonNetwork.PlayerList[x].NickName;
                container.hatTimesSlider.maxValue = GameManager.instance.timeToWin;
            }
            else
            {
                container.obj.SetActive(false);
            }

        }
    }

    private void Update()
    {
        UpdatePlayerUI();
    }

    void UpdatePlayerUI()
    {
        for(int x=0;x< GameManager.instance.players.Length;++x)
        {
            if (GameManager.instance.players[x]!=null)
            {
                playerContainers[x].hatTimesSlider.value = GameManager.instance.players[x].curHatTime;
            }
        }
    }

    public void SetWintext(string winnerName)
    {
        winText.gameObject.SetActive(true);
        winText.text = winnerName + "wins";
    }
}

[System.Serializable]
public class PlayerUIContainer
{
    public GameObject obj;
    public TextMeshProUGUI nameText;
    public Slider hatTimesSlider;
}
