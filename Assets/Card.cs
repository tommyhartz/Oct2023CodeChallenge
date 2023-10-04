using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int Rank;

    private static Vector3 startingPosition = new Vector3(-7f, 0f, -1f);
    private static Vector3 faceDownRotation = new Vector3(-90f, 90f, 90f);
    private static Vector3 faceUpRotation = new Vector3(90f, 0f, 180f);

    private bool moving = false;

    private float time = 0f;
    private float duration = 0.6f;
    private Vector3 startPosition = startingPosition;
    private Vector3 startRotation = faceDownRotation;

    private Vector3 targetPosition = startingPosition;
    private Vector3 targetRotation = faceDownRotation;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    // https://stackoverflow.com/questions/49736424/best-way-to-smoothly-move-a-character-from-one-point-to-another
    // https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/#lerp_with_easing
    void Update()
    {
        if (moving)
        {
            if (transform.position != targetPosition && time < duration)
            {
                time += Time.deltaTime;
                float t = time / duration;
                t = t * t * (3f - 2f * t);
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                transform.eulerAngles = Vector3.Lerp(startRotation, targetRotation, t);
            }
            else
            {
                moving = false;
                transform.position = targetPosition;
                transform.eulerAngles = targetRotation;
            }
        }
    }

    public void SetTarget(Vector3 target, bool reveal)
    {
        startRotation = transform.eulerAngles;
        targetRotation = reveal ? faceUpRotation : faceDownRotation;

        this.targetPosition = target;

        moving = true;
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            -52f
        );
        startPosition = transform.position;
        time = 0f;

        audioSource.Play();
    }

}
