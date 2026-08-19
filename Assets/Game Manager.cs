using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int count = 0;
    public bool hasAnomaly;

    // 数字画像を登録
    public Sprite[] numberSprites;

    // 看板のSpriteRenderer
    public SpriteRenderer numberSign;

    // ポスター一覧
    public GameObject[] posters;

    // 現在異変になっているポスター
    private GameObject currentAnomalyPoster;

    public GameObject clearPanel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateNumberSign();
        // ゲーム開始時は異変なし
        hasAnomaly = false;
    }

    public void Correct()
    {
        count++;

        UpdateNumberSign();

        Debug.Log("正解! 現在:" + count);

        if (count >= 8)
        {
            Debug.Log("クリア!");
        }
    }

    public void Wrong()
    {
        count = 0;

        UpdateNumberSign();

        Debug.Log("間違い!");
    }

    void UpdateNumberSign()
    {
        if (count >= 0 && count < numberSprites.Length)
        {
            numberSign.sprite = numberSprites[count];
        }
    }

    public void GameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void GenerateAnomaly()
    {
        // 前回の異変を元に戻す
        if (currentAnomalyPoster != null)
        {
            currentAnomalyPoster.transform.localRotation = Quaternion.identity;

            Vector3 resetScale = currentAnomalyPoster.transform.localScale;
            resetScale.x = Mathf.Abs(resetScale.x);
            currentAnomalyPoster.transform.localScale = resetScale;

            currentAnomalyPoster = null;
        }

        // 25%の確率で異変発生
        hasAnomaly = Random.Range(0, 100) < 50;

        if (!hasAnomaly)
        {
            Debug.Log("異変なし");
            return;
        }

        // ランダムなポスターを選ぶ
        int index = Random.Range(0, posters.Length);
        currentAnomalyPoster = posters[index];

        // 異変の種類をランダムに決める
        int anomalyType = Random.Range(0, 4);

        switch (anomalyType)
        {
            case 0:
                // 左右反転
                Vector3 scale = currentAnomalyPoster.transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                currentAnomalyPoster.transform.localScale = scale;

                Debug.Log("異変：ポスターが左右反転");
                break;

            case 1:
                // 90度回転
                currentAnomalyPoster.transform.localRotation =
                    Quaternion.Euler(0, 0, 90);

                Debug.Log("異変：ポスターが90度回転");
                break;

            case 2:
                // 180度回転
                currentAnomalyPoster.transform.localRotation =
                    Quaternion.Euler(0, 0, 180);

                Debug.Log("異変：ポスターが180度回転");
                break;

            case 3:
                // 270度回転
                currentAnomalyPoster.transform.localRotation =
                    Quaternion.Euler(0, 0, 270);

                Debug.Log("異変：ポスターが270度回転");
                break;
        }
    }

}