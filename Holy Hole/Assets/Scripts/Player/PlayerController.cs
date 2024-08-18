using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static Action<int> OnHoleSizeChange;

    [SerializeField] int size = 1;
    [SerializeField] float speed = 8f;

    int sizeToZoomThreshold = 4;
    int lastSizeCheck = 0;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }


    void OnObjectConsume()
    {
        if (ScoreManager.Instance.objectsEaten % 2 == 0)
        {
            size += 2;
            transform.localScale = transform.localScale + Vector3.one;
        }
        if (size >= lastSizeCheck + sizeToZoomThreshold)
        {
            lastSizeCheck = size;
            OnHoleSizeChange?.Invoke(2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BuildingStats building = other.gameObject.GetComponent<BuildingStats>();
        if (building != null && size >= building.eatSizeThreshold)
        {
            building.GivePlayerScore();
            OnObjectConsume();
            Destroy(other.gameObject);
        }
    }
}
