using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Terrence
public class AltitudeScript : MonoBehaviour
{
    //[SerializeField] GameObject ground;
    //[SerializeField] GameObject player;
    GameObject ground;
    GameObject player;
    GameObject altitudeTopBar;
    GameObject altitudeBottomBar;
    public float ScaleDistance;
    float extraheight;
    float maxheight = 75;
    float percentageScale;
    float heightdifferenceWorld;
    float heightdifferenceHUD;


    void Start()
    {
        heightdifferenceWorld = ground.transform.position.y * -1;
        heightdifferenceHUD = altitudeTopBar.transform.position.y - altitudeBottomBar.transform.position.y;
        percentageScale = (player.transform.position.y + heightdifferenceWorld) / (maxheight - ground.transform.position.y);
        extraheight = altitudeBottomBar.transform.position.y + heightdifferenceHUD * percentageScale;
    }

    public void Update()
    {
        percentageScale = (player.transform.position.y + heightdifferenceWorld) / (maxheight - ground.transform.position.y);
        extraheight = altitudeBottomBar.transform.position.y + heightdifferenceHUD * percentageScale;
        transform.position = new Vector3(transform.position.x, extraheight, transform.position.z);
    }

    public GameObject Ground {
        get { return ground; }
        set { ground = value; }
    }

    public GameObject Player {
        get { return player; }
        set { player = value; }
    }

    public GameObject AltitudeTopBar {
        get { return altitudeTopBar; }
        set { altitudeTopBar = value; }
    }

    public GameObject AltitudeBottomBar {
        get { return altitudeBottomBar; }
        set { altitudeBottomBar = value; }
    }
}