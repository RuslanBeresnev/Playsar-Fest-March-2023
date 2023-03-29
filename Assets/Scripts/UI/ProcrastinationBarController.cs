using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProcrastinationBarController : MonoBehaviour
{
    [SerializeField] private float secondsToFill = 45f;
    [SerializeField] private Image bar;
    // Значение, после которого персонаж плавно начинает идти к кровати и произносит фразу
    [SerializeField] private float criticalValue = 0.5f;

    [SerializeField] private UnityEvent onCriticalValueReached;
    private bool criticalValueReached = false;

    /// <summary>
    /// Коэффициент прокрастинации от 0f до 1f
    /// </summary>
    public float ProcrastinationCoefficient { get; set; } = 0f;

    /// <summary>
    /// Общий экземпляр данного класса
    /// </summary>
    public static ProcrastinationBarController Shared { get; private set; }

    private void Awake()
    {
        Shared = this;
    }

    private void Update()
    {
        ProcrastinationCoefficient += Time.deltaTime / secondsToFill;
        bar.fillAmount = ProcrastinationCoefficient;
        ProcrastinationCoefficient = Mathf.Clamp(ProcrastinationCoefficient, 0f, 1f);

        if (ProcrastinationCoefficient >= criticalValue && !criticalValueReached)
        {
            criticalValueReached = true;
            onCriticalValueReached.Invoke();
        }

    }

    public void DecreaseProcrastination(float value)
    {
        ProcrastinationCoefficient -= value;
        ProcrastinationCoefficient = Mathf.Clamp(ProcrastinationCoefficient, 0f, 1f);
    }
}