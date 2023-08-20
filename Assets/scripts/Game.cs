using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;
    // all the chess positions and game objects
    private GameObject[,] positions = new GameObject[8, 8];

    private GameObject[] playerblack = new GameObject[16];
    private GameObject[] playerwhite = new GameObject[16];

    private string currentplayer = "white";

    private bool gameover = false;



    void Start()
    {
        //Instantiate(chesspiece,new Vector3(0,0,0),Quaternion.identity);
        playerwhite = new GameObject[]
        {
        Create("w_r",0,0),
        Create("w_kt",1, 0),
        Create("w_b", 2, 0),
        Create("w_q", 3, 0),
        Create("w_k", 4, 0),
        Create("w_b", 5, 0),
        Create("w_kt", 6, 0),
        Create("w_r", 7, 0),
        Create("w_p", 0, 1),
        Create("w_p", 1, 1),
        Create("w_p", 2, 1),
        Create("w_p", 3, 1),
        Create("w_p", 4, 1),
        Create("w_p", 5, 1),
        Create("w_p", 6, 1),
        Create("w_p", 7, 1)

        };
        playerblack = new GameObject[] {

        Create("b_r", 0, 7),
        Create("b_kt", 1, 7),
        Create("b_b", 2, 7),
        Create("b_q", 3, 7),
        Create("b_k", 4, 7),
        Create("b_b", 5, 7),
        Create("b_kt", 6, 7),
        Create("b_r", 7, 7),
        Create("b_p", 0, 6),
        Create("b_p", 1, 6),
        Create("b_p", 2, 6),
        Create("b_p", 3, 6),
        Create("b_p", 4, 6),
        Create("b_p", 5, 6),
        Create("b_p", 6, 6),
        Create("b_p", 7, 6)


    };

        //set all the positions on the pos board
        for(int i = 0; i < playerblack.Length; i++)
        {
            Setposition(playerblack[i]);
            Setposition(playerwhite[i]);


        }

    }

    public GameObject Create(string name,int x,int y)
    {
        GameObject obj = Instantiate(chesspiece,new Vector3(0,0,0),Quaternion.identity);
        player p = obj.GetComponent<player>();
        p.name = name;
        p.Setxboard(x);
        p.Setyboard(y);
        p.Activate();

        return obj;
    }

    public void Setposition(GameObject obj)
    {
        player p = obj.GetComponent<player>();
        positions[p.Getxboard(), p.Getyboard()] = obj;

    }

    public void Setpoistionempty(int x,int y)
    {
        positions[x, y] = null;
    }
    public GameObject Getposition(int x,int y)
    {
        return positions[x, y];
    }
    public bool positiononboard(int x,int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;

        return true;
    }

  

}
