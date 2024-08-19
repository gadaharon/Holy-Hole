using System;
using UnityEngine;
public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    public static Action<int> OnHoleSizeChange;

    [Header("PLAYER DETAILS")]
    [SerializeField] int size = 1;
    [SerializeField] float speed = 8f;

    [Tooltip("Determines the size increase per growth")]
    [Range(1f, 2f)]
    [SerializeField] float holeSizeMultiplier = 1.2f;

    [Header("SIZE GROWTH GAUGE")]
    [SerializeField] int baseGrowthGauge = 100;
    [SerializeField] float gaugeGrowthRate = 1.2f;

    [Header("CAMERA ZOOM OUT AMOUNT")]
    [Tooltip("Camera zoom out amount per growth")]
    [SerializeField] int cameraZoomOutAmount = 3;


    [Header("TESTING")]
    [SerializeField] int targetGrowthGauge = 100;
    [SerializeField] int currentGrowthGauge = 0;


    void Update()
    {
        if (GameManager.state == GameState.Playing)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    void OnObjectConsume(int points)
    {
        currentGrowthGauge += points;
        if (currentGrowthGauge >= targetGrowthGauge)
        {
            currentGrowthGauge = 0;
            size += 2;
            transform.localScale = transform.localScale + (Vector3.one * holeSizeMultiplier);
            targetGrowthGauge = Mathf.CeilToInt(baseGrowthGauge * Mathf.Pow(gaugeGrowthRate, size));
            OnHoleSizeChange?.Invoke(cameraZoomOutAmount);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BuildingStats building = other.gameObject.GetComponent<BuildingStats>();
        if (building != null && size >= building.eatSizeThreshold)
        {
            if (!building.HasFallen)
            {
                building.GivePlayerScore();
                OnObjectConsume(building.pointOnEat);
            }
        }
    }
}
