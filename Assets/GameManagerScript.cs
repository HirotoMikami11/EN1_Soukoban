using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //�N���X�̒����\�b�h�̊O�ɏ���

    //�������\������
    //void PrintArray()
    //{
    //    //������̐錾�Ə�����
    //    string debugText = "";

    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        //������Ɍ������Ă���
    //        debugText += map[i].ToString() + ",";
    //    }
    //    //����������������o��
    //    Debug.Log(debugText);
    //}

    ////�P�̒l���i�[����Ă���C���f�b�N�X���擾���鏈���̃��\�b�h���B
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



    ////�ړ��̉s�𔻒f���Ĉړ������鏈�������\�b�h���B 
    
    ///// <summary>
    ///// �ړ��̉s�𔻒f���Ĉړ������郁�\�b�h
    ///// </summary>
    ///// <param name="number">�ړ����������l</param>
    ///// <param name="moveFrom">�ړ����̈ʒu</param>
    ///// <param name="moveTo">�ړ���̈ʒu</param>
    ///// <returns></returns>
    //bool MoveNumber(int number, int moveFrom, int moveTo)
    //{
    //    //�����Ȃ������i�z��͈̔͊O�j
    //    if (moveTo < 0 || moveTo >= map.Length) { return false; }

    //    //�ړ����2�i���j������Ƃ��̏���
    //    if (map[moveTo] == 2)
    //    {
    //        //�ǂ̕����Ɉړ����邩�Y�o
    //        int velocity = moveTo - moveFrom;


    //        //  �v���C���[�̈ړ��悩��A�X�ɐ��2�i���j���ړ�������
    //        //  ���̈ړ������AMoveNumber���\�b�h����MoveNumber���\�b�h���ĂсA
    //        //  �������ċA���Ă���A�ړ��s��bool�ŕۑ�
    //        bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //        if (!success) { return false; }
    //    }


    //    //�v���C���[�E���ς�炸�̈ړ�����
    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;

    //}



    //�z��̐錾
    //�񎟌��z��̐錾
    int[,] map;


    // Start is called before the first frame update
    void Start()
    {    //�C�j�V�����C�Y�i��񂾂��j

        ///�z��̎��̂̍쐬�Ə�����
        map = new int[,] {
            {0,0,0,0,0 },
            {0,0,1,0,0 },    
            {0,0,0,0,0 },    
        };

        string debugText = "";
        //�@��dfor���œ񎟌��z��̏����o��
        for (int y = 0;y<map.GetLength(0);y++)
        {
            for(int x = 0; x < map.GetLength(1); x++)
            {

                debugText += map[y,x].ToString() + ",";
            }
            debugText += "\n";//���s����
        }
        Debug.Log(debugText);
    }



    // Update is called once per frame
    //void Update()
    //{        //���t���[��

    //    /*-----------------------------------------------*/
    //    //
    //    //                �E�����Ɉړ�������
    //    //
    //    /*-----------------------------------------------*/

    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        //1.�P���i�[����Ă���C���f�b�N�X��T��
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex + 1);

    //        PrintArray();
    //    }

    //    /*-----------------------------------------------*/
    //    //
    //    //                �������Ɉړ�������
    //    //
    //    /*-----------------------------------------------*/

    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        //1.�P���i�[����Ă���C���f�b�N�X��T��
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex - 1);

    //        PrintArray();
    //    }
    //}
}
