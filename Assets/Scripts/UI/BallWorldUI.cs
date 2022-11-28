using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallWorldUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _countText;

    [SerializeField]
    private Animator _perfectAnim;
    [SerializeField]
    private Animator _bounceAnim;
    [SerializeField]
    private Animator _countAnim;

    private void Awake()
    {
        //EventManager.Instance.ballCatch.AddListener(Show);
    }

    public void Show()
    {

            this.transform.up = Vector2.up;
            int wallBounceMultiplier = Ball.Instance.WALL_BOUNCE_COUNT == 0 ? 1 : 2;
            _countText.text = "+" + (1 * GameManager.Instance.COMBO_MULTIPLIER * wallBounceMultiplier).ToString();
            StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        if (Ball.Instance.BOUNCE_COUNT == 0)
        {
            _perfectAnim.SetTrigger("Show");
            yield return new WaitForSeconds(0.5f);
        }
        if (Ball.Instance.WALL_BOUNCE_COUNT > 0)
        {
            _bounceAnim.SetTrigger("Show");
            yield return new WaitForSeconds(0.5f);
        }
        _countAnim.SetTrigger("Show");
    }

}
