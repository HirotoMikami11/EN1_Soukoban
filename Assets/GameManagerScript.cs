using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //クラスの中メソッドの外に書く

    //文字列を表示する
    //void PrintArray()
    //{
    //    //文字列の宣言と初期化
    //    string debugText = "";

    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        //文字列に結合していく
    //        debugText += map[i].ToString() + ",";
    //    }
    //    //結合した文字列を出力
    //    Debug.Log(debugText);
    //}

    ////１の値が格納されているインデックスを取得する処理のメソッド化。
    //int GetPlayerIndex()
    //{
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        if (map[i] == 1)
    //        {
    //            return i;
    //        }

    //    }
    //    return -1;
    //}



    ////移動の可不可を判断して移動させる処理をメソッド化。 
    
    ///// <summary>
    ///// 移動の可不可を判断して移動させるメソッド
    ///// </summary>
    ///// <param name="number">移動させたい値</param>
    ///// <param name="moveFrom">移動元の位置</param>
    ///// <param name="moveTo">移動先の位置</param>
    ///// <returns></returns>
    //bool MoveNumber(int number, int moveFrom, int moveTo)
    //{
    //    //動けない条件（配列の範囲外）
    //    if (moveTo < 0 || moveTo >= map.Length) { return false; }

    //    //移動先に2（箱）があるときの処理
    //    if (map[moveTo] == 2)
    //    {
    //        //どの方向に移動するか産出
    //        int velocity = moveTo - moveFrom;


    //        //  プレイヤーの移動先から、更に先へ2（箱）を移動させる
    //        //  箱の移動処理、MoveNumberメソッド内でMoveNumberメソッドを呼び、
    //        //  処理が再帰している、移動可不可をboolで保存
    //        bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //        if (!success) { return false; }
    //    }


    //    //プレイヤー・箱変わらずの移動処理
    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;

    //}



    //配列の宣言
    //二次元配列の宣言
    int[,] map;


    // Start is called before the first frame update
    void Start()
    {    //イニシャライズ（一回だけ）

        ///配列の実体の作成と初期化
        map = new int[,] {
            {0,0,0,0,0 },
            {0,0,1,0,0 },    
            {0,0,0,0,0 },    
        };

        string debugText = "";
        //　二重for文で二次元配列の情報を出力
        for (int y = 0;y<map.GetLength(0);y++)
        {
            for(int x = 0; x < map.GetLength(1); x++)
            {

                debugText += map[y,x].ToString() + ",";
            }
            debugText += "\n";//改行する
        }
        Debug.Log(debugText);
    }



    // Update is called once per frame
    //void Update()
    //{        //毎フレーム

    //    /*-----------------------------------------------*/
    //    //
    //    //                右方向に移動させる
    //    //
    //    /*-----------------------------------------------*/

    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        //1.１が格納されているインデックスを探す
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex + 1);

    //        PrintArray();
    //    }

    //    /*-----------------------------------------------*/
    //    //
    //    //                左方向に移動させる
    //    //
    //    /*-----------------------------------------------*/

    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        //1.１が格納されているインデックスを探す
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex - 1);

    //        PrintArray();
    //    }
    //}
}
