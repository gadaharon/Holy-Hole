using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] int size = 1;
    [SerializeField] float speed = 8f;

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
        if (ScoreManager.instance.objectsEaten % 2 == 0)
        {
            size += 2;
            transform.localScale = transform.localScale + Vector3.one;
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
