using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //クラスの中メソッドの外に書く

    //１の値が格納されているインデックスを取得する処理のメソッド化。
    Vector2Int GetPlayerIndex()
    {

        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                //nullチェックしてnullならループ、違ったらtagチェックする
                if (field[y, x] == null) { continue; }
                if (field[y, x].tag == "Player")//tagがPlayerなら
                {
                    return new Vector2Int(x, y);//二次元配列それぞれのインデックスをVector2Int型で返す
                }

            }
        }
        return new Vector2Int(-1, -1);
    }



    //移動の可不可を判断して移動させる処理をメソッド化。 

    /// <summary>
    /// 移動の可不可を判断して移動させるメソッド
    /// </summary>
    /// <param name="number">移動させたい値</param>
    /// <param name="moveFrom">移動元の位置</param>
    /// <param name="moveTo">移動先の位置</param>
    /// <returns></returns>
    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {
        //動けない条件（配列の範囲外）
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; } //y座標
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }//x座標

        //移動先に（箱）があるときの処理
        if (field[moveTo.y,moveTo.x]!=null && field[moveTo.y,moveTo.x].tag == "Box")
        {
            //どの方向に移動するか産出
            Vector2Int velocity = moveTo - moveFrom;

            //  プレイヤーの移動先から、更に先へ2（箱）を移動させる
            //  箱の移動処理、MoveNumberメソッド内でMoveNumberメソッドを呼び、
            //  処理が再帰している、移動可不可をboolで保存
            bool success = MoveNumber(tag, moveTo, moveTo + velocity);
            if (!success) { return false; }
        }

        //配列の値の移動を行う前にmoveFromにあるゲームオブジェクトの座標を変更する
        //ゲームオブジェクトの移動
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x,field.GetLength(0)- moveTo.y,0);

        //プレイヤー・箱変わらずの移動処理
        field[moveTo.y, moveTo.x] =field[moveFrom.y, moveFrom.x];
        field[moveFrom.y,moveFrom.x] = null;
        return true;

    }




    //配列の宣言
    public GameObject PlayerPrefab;
    public GameObject BoxPrefab;

    //二次元配列の宣言
    int[,] map;     //レベルデザイン用の配列
    //ゲーム管理用の配列
    GameObject[,] field;



    // Start is called before the first frame update
    void Start()
    {    //イニシャライズ（一回だけ）

        ///配列の実体の作成と初期化
        map = new int[,] {
            {0,0,0,0,0 },
            {0,2,1,0,0 },
            {0,0,2,2,0 },
            {0,0,0,0,0 },
            {0,0,0,0,0 },
        };

        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
            ];
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                    PlayerPrefab,
                    new Vector3(x, map.GetLength(0) - y, 0),
                    Quaternion.identity);
                }

                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(
                    BoxPrefab,
                    new Vector3(x, map.GetLength(0) - y, 0),
                    Quaternion.identity);
                }


            }
        }
    }


    // Update is called once per frame
    void Update()
    {        //毎フレーム

        /*-----------------------------------------------*/
        //
        //                右方向に移動させる
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //1.１が格納されているインデックスを探す
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Box", playerIndex, (playerIndex + new Vector2Int(1, 0)));


        }

        /*-----------------------------------------------*/
        //
        //                左方向に移動させる
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //1.１が格納されているインデックスを探す
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Box", playerIndex, (playerIndex+ new Vector2Int(-1, 0)));


        }
        /*-----------------------------------------------*/
        //
        //                上方向に移動させる
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //1.１が格納されているインデックスを探す
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Box", playerIndex, (playerIndex + new Vector2Int(0, -1)));


        }
        /*-----------------------------------------------*/
        //
        //                下方向に移動させる
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //1.１が格納されているインデックスを探す
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Box", playerIndex, (playerIndex + new Vector2Int(0, 1)));


        }



    }
}
