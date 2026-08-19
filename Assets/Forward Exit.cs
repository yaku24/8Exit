using UnityEngine;

public class ForwardExit : MonoBehaviour
{
    public Transform player;
    public Transform startPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;


        // 8回クリアしたらワープせず、そのまま進める
        if (GameManager.Instance.count >= 8)
        {
            Debug.Log("ゴールへ進む！");
            return;
        }

        // 8回未満は今まで通りワープ

        player.position = startPoint.position;

        if (GameManager.Instance.hasAnomaly)
        {
            // 異変があるのに進んだので不正解
            GameManager.Instance.Wrong();
        }
        else
        {
            // 異変がないので進むのが正解
            GameManager.Instance.Correct();
        }

        GameManager.Instance.GenerateAnomaly();
    }
}