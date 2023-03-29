using System.Collections;
using UnityEngine;

/// <summary>
/// –еализаци€ анимации надписи, объ€сн€ющей прокрастинацию
/// </summary>
public class Notification : MonoBehaviour
{
    [SerializeField] private CanvasGroup text;
    [SerializeField] private float speed;
    [SerializeField] private float readDuration;

    private void Awake()
    {
        text.alpha = 0f;
    }

    /// <summary>
    /// јнимировать по€вление и исчезание надписи
    /// </summary>
    public void Animate()
    {
        StartCoroutine(AnimateCoroutine());
    }

    private IEnumerator AnimateCoroutine()
    {
        while (true)
        {
            text.alpha = text.alpha + speed * Time.deltaTime;
            if (text.alpha >= 1f)
            {
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(readDuration);

        while (true)
        {
            text.alpha = text.alpha - speed * Time.deltaTime;
            if (text.alpha <= 0f)
            {
                break;
            }
            yield return null;
        }
    }
}