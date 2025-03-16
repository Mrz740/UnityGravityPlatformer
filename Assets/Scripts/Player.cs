using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    private void Update()
    {
        Vector2 InputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            InputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            InputVector.x = +1;
        }

        Vector3 moveDir = new Vector3(InputVector.x, InputVector.y, 0);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
