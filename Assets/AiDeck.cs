using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AiDeck : MonoBehaviour
{
    public List<Card> Cards = new List<Card>();
    public GameBoard GameBoard;

    public AiPile AiPile;
    public AiBench AiBench;

    private float delay = 0.2f;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBoard.GameState == GameBoard.AiTurn)
        {
            time += Time.deltaTime;

            if (time >= delay)
            {
                time = 0f;
                Play();
            }
        }
    }

    public void AddCard(Card card)
    {
        Cards.Add(card);

        card.SetTarget(transform.position, false);
    }

    void Play()
    {
        if (GameBoard.IsWar)
        {
            PlayCard(false);
            PlayCard(false);
            PlayCard(false);
            PlayCard(true);
        }
        else
        {
            PlayCard(true);
        }

        GameBoard.GameState = GameBoard.Resolving;
    }


    void PlayCard(bool reveal)
    {
        if (Cards.Count == 0)
        {
            if (AiBench.Cards.Count > 0)

            {
                foreach (Card c in AiBench.Cards)
                {
                    Cards.Add(c);

                    var position = transform.position;

                    c.SetTarget(position, false);
                }

                AiBench.Cards.Clear();
                Shuffle();
            }
            else
            {
                Debug.Log("Ai Death by draw");
                GameBoard.PlayerWon();
                return;
            }
        }

        Card card = Cards.First();
        Cards.Remove(card);
        AiPile.AddCard(card, reveal);
    }

    private void Shuffle()
    {
        Cards = Cards.OrderBy(a => Random.Range(0, int.MaxValue)).ToList();
    }
}
