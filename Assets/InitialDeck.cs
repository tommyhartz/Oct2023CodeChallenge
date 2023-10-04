using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InitialDeck : MonoBehaviour
{

    public GameBoard GameBoard;

    public PlayerDeck PlayerDeck;
    public AiDeck AiDeck;

    public List<Card> Cards;


    public bool controlMode = false;
    public bool autoDealing = false;

    public bool goesToPlayer = true;

    private float time = 0.0f;
    public float dealingInterval = 0.06f;


    // Start is called before the first frame update
    void Start()
    {
        Cards = new List<Card>() {
            GameObject.Find("Blue_PlayingCards_Spade13_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade12_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade11_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade10_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade09_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade08_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade07_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade06_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade05_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade04_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade03_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade02_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Spade01_00").GetComponent<Card>(),

            GameObject.Find("Blue_PlayingCards_Heart13_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart12_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart11_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart10_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart09_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart08_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart07_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart06_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart05_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart04_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart03_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart02_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Heart01_00").GetComponent<Card>(),

            GameObject.Find("Blue_PlayingCards_Diamond13_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond12_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond11_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond10_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond09_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond08_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond07_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond06_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond05_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond04_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond03_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond02_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Diamond01_00").GetComponent<Card>(),

            GameObject.Find("Blue_PlayingCards_Club13_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club12_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club11_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club10_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club09_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club08_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club07_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club06_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club05_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club04_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club03_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club02_00").GetComponent<Card>(),
            GameObject.Find("Blue_PlayingCards_Club01_00").GetComponent<Card>(),

        };

        Cards[0].Rank = 13;
        Cards[1].Rank = 12;
        Cards[2].Rank = 11;
        Cards[3].Rank = 10;
        Cards[4].Rank = 9;
        Cards[5].Rank = 8;
        Cards[6].Rank = 7;
        Cards[7].Rank = 6;
        Cards[8].Rank = 5;
        Cards[9].Rank = 4;
        Cards[10].Rank = 3;
        Cards[11].Rank = 2;
        Cards[12].Rank = 14;  // ace is high

        Cards[13].Rank = 13;
        Cards[14].Rank = 12;
        Cards[15].Rank = 11;
        Cards[16].Rank = 10;
        Cards[17].Rank = 9;
        Cards[18].Rank = 8;
        Cards[19].Rank = 7;
        Cards[20].Rank = 6;
        Cards[21].Rank = 5;
        Cards[22].Rank = 4;
        Cards[23].Rank = 3;
        Cards[24].Rank = 2;
        Cards[25].Rank = 14;  // ace is high

        Cards[26].Rank = 13;
        Cards[27].Rank = 12;
        Cards[28].Rank = 11;
        Cards[29].Rank = 10;
        Cards[30].Rank = 9;
        Cards[31].Rank = 8;
        Cards[32].Rank = 7;
        Cards[33].Rank = 6;
        Cards[34].Rank = 5;
        Cards[35].Rank = 4;
        Cards[36].Rank = 3;
        Cards[37].Rank = 2;
        Cards[38].Rank = 14;  // ace is high

        Cards[39].Rank = 13;
        Cards[40].Rank = 12;
        Cards[41].Rank = 11;
        Cards[42].Rank = 10;
        Cards[43].Rank = 9;
        Cards[44].Rank = 8;
        Cards[45].Rank = 7;
        Cards[46].Rank = 6;
        Cards[47].Rank = 5;
        Cards[48].Rank = 4;
        Cards[49].Rank = 3;
        Cards[50].Rank = 2;
        Cards[51].Rank = 14;  // ace is high

        ShuffleDeck();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controlMode = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controlMode = false;
        }

        if (autoDealing && GameBoard.GameState == GameBoard.Dealing && Cards.Count > 0)
        {
            time += Time.deltaTime;
            if (time >= dealingInterval)
            {
                time = 0f;

                DealCard();
            }
        }
    }

    private void OnMouseDown()
    {
        if (!autoDealing && GameBoard.GameState == GameBoard.Dealing && Cards.Count > 0)
        {
            if (controlMode)
            {
                autoDealing = true;
            }
            else
            {
                DealCard();
            }

        }
    }

    void ShuffleDeck()
    {
        Cards = Cards.OrderBy(a => Random.Range(int.MinValue, int.MaxValue)).ToList();
    }

    void DealCard()
    {
        Card card = Cards.First();

        if (goesToPlayer)
        {
            PlayerDeck.AddCard(card);
        }
        else
        {
            AiDeck.AddCard(card);
        }

        Cards.Remove(card);

        goesToPlayer = !goesToPlayer;

        if (Cards.Count == 0)
        {
            GameBoard.GameState = GameBoard.PlayerTurn;
            autoDealing = false;
        }
    }
}
