using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public const string Dealing = "Dealing";
    public const string PlayerTurn = "PlayerTurn";
    public const string AiTurn = "AiTurn";
    public const string Resolving = "Resolving";
    public const string PlayerWonRound = "PlayerWonRound";
    public const string AiWonRound = "AiWonRound";
    public const string PlayerWins = "PlayerWins";
    public const string AiWins = "AiWins";

    public static Color Green = new Color(0.1058322f, 0.3773585f, 0.09433962f);
    public static Color Red = new Color(0.4f, 0.08f, 0.08f);

    public string GameState = Dealing;

    public bool IsWar = false;

    private bool changingColor = false;
    private float time = 0f;
    private float duration = 0.6f;
    public Color StartColor = Green;
    public Color TargetColor = Green;

    private SpriteRenderer Renderer;

    public PlayerDeck PlayerDeck;
    public PlayerBench PlayerBench;
    public AiDeck AiDeck;
    public AiBench AiBench;

    public PlayerPile PlayerPile;
    public AiPile AiPile;

    public AudioSource playerWinsRound;
    public AudioSource aiWinsRound;
    public AudioSource playerWinsGame;
    public AudioSource aiWinsGame;
    public AudioSource warMusic;

    public Image playerWinsGraphic;
    public Image aiWinsGraphic;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        playerWinsGraphic.enabled = false;
        aiWinsGraphic.enabled = false;
    }

    public void PlayerWinRound()
    {
        GameState = PlayerWonRound;
        playerWinsRound.Play();
        EndWar();
    }

    public void AiWinRound()
    {
        GameState = AiWonRound;
        aiWinsRound.Play();
        EndWar();
    }

    public void PlayerWon()
    {
        GameState = PlayerWins;
        if (!playerWinsGame.isPlaying)
        {
            playerWinsGame.Play();
        }
        playerWinsGraphic.enabled = true;
    }

    public void AiWon()
    {
        GameState = AiWins;
        if (!aiWinsGame.isPlaying)
        {
            aiWinsGame.Play();
        }
        aiWinsGraphic.enabled = true;
    }

    public void StopWarMusic()
    {
        if (warMusic.isPlaying)
        {
            warMusic.Stop();
            warMusic.time = 0;
        }
    }

    public void BeginWar()
    {
        changingColor = true;
        time = 0f;
        IsWar = true;
        StartColor = Renderer.color;
        TargetColor = Red;
        GameState = PlayerTurn;

        warMusic.Play();
    }

    public void EndWar()
    {
        time = 0f;
        changingColor = true;
        StartColor = Renderer.color;
        TargetColor = Green;
        IsWar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changingColor)
        {
            if (time < duration)
            {
                time += Time.deltaTime;
                float t = time / duration;
                t = t * t * (3f - 2f * t);

                var result = Vector3.Lerp(
                    new Vector3(StartColor.r, StartColor.g, StartColor.b),
                    new Vector3(TargetColor.r, TargetColor.g, TargetColor.b),
                    t);

                Renderer.color = new Color(result.x, result.y, result.z);
            }
            else
            {
                changingColor = false;
                Renderer.color = TargetColor;
            }
        }

        if (GameState == Resolving)
        {
            StopWarMusic();

            if (PlayerPile.Cards.Count > AiPile.Cards.Count)
            {
                PlayerWon();
            }
            else if (PlayerPile.Cards.Count < AiPile.Cards.Count)
            {
                AiWon();
            }
            else if (PlayerPile.Cards.Last().Rank == AiPile.Cards.Last().Rank)
            {
                BeginWar();
            }
            else if (PlayerPile.Cards.Last().Rank > AiPile.Cards.Last().Rank)
            {
                if (AiDeck.Cards.Count + AiBench.Cards.Count == 0)
                {
                    PlayerWon();
                }
                else
                {
                    PlayerWinRound();
                }
            }
            else
            {
                if (PlayerDeck.Cards.Count + PlayerBench.Cards.Count == 0)
                {
                    AiWon();
                }
                else
                {
                    AiWinRound();
                }
            }
        }
    }
}
