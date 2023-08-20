using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject controller;
    public GameObject moveplate;

    private int xboard = -1;
    private int yboard = -1;

    private string teamcolor;

    public Sprite b_q, b_r, b_k, b_p, b_kt, b_b;
    public Sprite w_q, w_r, w_k, w_p, w_kt, w_b;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        // settings the coordinates
        SetCoords();

        switch (this.name)
        {
            case "b_q":this.GetComponent<SpriteRenderer>().sprite = b_q;
                teamcolor = "black";
                break;
            case "b_k":
                this.GetComponent<SpriteRenderer>().sprite = b_k;
                teamcolor = "black";
                break;
            case "b_r":
                this.GetComponent<SpriteRenderer>().sprite = b_r;
                teamcolor = "black";
                break;
            case "b_kt":
                this.GetComponent<SpriteRenderer>().sprite = b_kt;
                teamcolor = "black";
                break;
            case "b_b":
                this.GetComponent<SpriteRenderer>().sprite = b_b;
                teamcolor = "black";
                break;
            case "b_p":
                this.GetComponent<SpriteRenderer>().sprite = b_p;
                teamcolor = "black";
                break;
            case "w_q":
                this.GetComponent<SpriteRenderer>().sprite = w_q;
                teamcolor = "white";
                break;
            case "w_k":
                this.GetComponent<SpriteRenderer>().sprite = w_k;
                teamcolor = "white";

                break;
            case "w_kt":
                this.GetComponent<SpriteRenderer>().sprite = w_kt;
                teamcolor = "white";

                break;
            case "w_p":
                this.GetComponent<SpriteRenderer>().sprite = w_p;
                teamcolor = "white";

                break;
            case "w_b":
                this.GetComponent<SpriteRenderer>().sprite = w_b;
                teamcolor = "white";

                break;
            case "w_r":
                this.GetComponent<SpriteRenderer>().sprite = w_r;
                teamcolor = "white";

                break;

        }
    }

    public void SetCoords()
    {
        float x = xboard;
        float y = yboard;
        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.35f;

        this.transform.position = new Vector3(x, y, 0);
    }

    public int Getxboard()
    {
        return xboard;
    }
    public int Getyboard()
    {
        return yboard;
    }
    public void Setxboard(int x)
    {
        this.xboard = x;
    }
    public void Setyboard(int y)
    {
        this.yboard = y;
    }


    private void OnMouseUp()
    {
        if(!controller.GetComponent<Game>().isGameover() && controller.GetComponent<Game>().Getcurentplayer() == this.teamcolor)
        {
        DestroyMovePlates();

        InitiateMovePlates();
        }


    }

    public void DestroyMovePlates()
    {
        GameObject[] moveplates = GameObject.FindGameObjectsWithTag("MovePlate");
        for(int i = 0;i< moveplates.Length; i++)
        {
            Destroy(moveplates[i]);
        }
        
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {

            case "b_q":
            case "w_q":
                LineMovePlate(1, 0);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(0, 1);
                LineMovePlate(-1, -1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                break;
            case "b_kt":
            case "w_kt":
                lMovePlate();
                break;
            case "b_b":
            case "w_b":
                LineMovePlate(-1, -1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, 1);
                break;
            case "b_k":
            case "w_k":
                SurroundMovePalte();
                break;
            case "b_r":
            case "w_r":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "b_p":
                Pawnmoveplate(xboard, yboard - 1);
                break;
            case "w_p":
                Pawnmoveplate(xboard, yboard + 1);
                break;








        }
    }
    public void LineMovePlate(int xincrease,int yincrease)
    {
        Game sc = controller.GetComponent<Game>();
        int x = xboard + xincrease;
        int y = yboard + yincrease;
        // moving wihtout attack
        while(sc.positiononboard(x,y) && sc.Getposition(x,y) == null)
        {
            Moveplatespawn(x, y);
            x += xincrease;
            y += yincrease;

        }
        if(sc.positiononboard(x,y) && sc.Getposition(x,y).GetComponent<player>().teamcolor != teamcolor)
        {
            MovePlateattackspawn(x, y);

        }

    }
    public void lMovePlate()
    {
        Pointmoveplate(xboard + 1, yboard + 2);
        Pointmoveplate(xboard - 1, yboard + 2);
        Pointmoveplate(xboard + 2, yboard + 1);
        Pointmoveplate(xboard +2, yboard - 1);
        Pointmoveplate(xboard +1, yboard - 2);
        Pointmoveplate(xboard -1, yboard - 2);
        Pointmoveplate(xboard -2, yboard + 1);
        Pointmoveplate(xboard -2, yboard - 1);


    }

    public void SurroundMovePalte() {
        Pointmoveplate(xboard + 1, yboard + 1);
        Pointmoveplate(xboard - 1, yboard - 1);
        Pointmoveplate(xboard + 0, yboard + 1);
        Pointmoveplate(xboard + 1, yboard + 0);
        Pointmoveplate(xboard - 1, yboard + 1);
        Pointmoveplate(xboard + 1, yboard - 1);
        Pointmoveplate(xboard + 0, yboard - 1);
        Pointmoveplate(xboard - 1, yboard + 0);



    }
    public void Pointmoveplate(int x,int y)
    {
        Game g =  controller.GetComponent<Game>();
        if (g.positiononboard(x, y))
        {
            GameObject pl = g.Getposition(x, y);
            if(pl == null) // if chess piece not exist in the pos we are moving
            {
                Moveplatespawn(x, y);
                
            }
            else if(pl.GetComponent<player>().teamcolor != teamcolor)
            {
                MovePlateattackspawn(x, y);
            }
        }

    }   
    public void Moveplatespawn(int x,int y)
    {
        float  localx = x;
        float localy = y;

        localx *= 0.66f;
        localy *= 0.66f;

        localx += -2.3f;
        localy += -2.35f;

        GameObject rf = Instantiate(moveplate, new Vector3(localx, localy, 0), Quaternion.identity);
        moveplate script = rf.GetComponent<moveplate>();
        script.SetRefrence(gameObject);
        script.SetCoords(x, y);





    }
    public void MovePlateattackspawn(int x,int y)
    {
        float localx = x;
        float localy = y;

        localx *= 0.66f;
        localy *= 0.66f;

        localx += -2.3f;
        localy += -2.35f;

        GameObject rf = Instantiate(moveplate, new Vector3(localx, localy, 0), Quaternion.identity);
        moveplate script = rf.GetComponent<moveplate>();
        script.attack = true;
        script.SetRefrence(gameObject);
        script.SetCoords(x, y);


    }
    public void Pawnmoveplate(int x,int y)
    {
        Game game = controller.GetComponent<Game>();
        if (game.positiononboard(x, y))
        {
            if(game.Getposition(x,y) == null)
            {
                Moveplatespawn(x, y);
            }
            if(game.positiononboard(x+1,y) && game.Getposition(x+1,y) != null && game.Getposition(x+1,y).GetComponent<player>().teamcolor != teamcolor)
            {
                MovePlateattackspawn(x+1,y);
            }
            if (game.positiononboard(x - 1, y) && game.Getposition(x - 1, y) != null && game.Getposition(x - 1, y).GetComponent<player>().teamcolor != teamcolor)
            {
                MovePlateattackspawn(x - 1, y);
            }
        }

    }
 


}
