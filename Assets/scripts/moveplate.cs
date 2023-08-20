using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplate : MonoBehaviour
{
    public GameObject controller;
    GameObject refrence = null;

    int markx, marky;


    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f,0.0f,0.0f,1.0f);
        }
    }
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if (attack)
        {
            GameObject cp = controller.GetComponent<Game>().Getposition(markx, marky);
            if(cp.name == "b_k")
            {
                controller.GetComponent<Game>().Winner("white");
            }
            else if(cp.name == "w_k")
            {
                controller.GetComponent<Game>().Winner("black");

            }
            Destroy(cp);
        }

        controller.GetComponent<Game>().Setpoistionempty(refrence.GetComponent<player>().Getxboard(), refrence.GetComponent<player>().Getyboard());

        refrence.GetComponent<player>().Setxboard(markx);
        refrence.GetComponent<player>().Setyboard(marky);
        refrence.GetComponent<player>().SetCoords();
        controller.GetComponent<Game>().Setposition(refrence);
        controller.GetComponent<Game>().Nextturn();
        refrence.GetComponent<player>().DestroyMovePlates();

    }

    public void SetCoords(int x,int y)
    {
        markx = x;
        marky = y;

    }

    public void SetRefrence(GameObject obj)
    {
        refrence = obj;
    }

    public GameObject Getrefrence()
    {
        return refrence;
    }



}
