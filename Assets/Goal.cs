using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GoalTriggerに入った：" + other.name);

        if (!other.CompareTag("Player"))
            return;

        Debug.Log("ゴールに到達！");

        GameManager.Instance.GameClear();
    }
}
