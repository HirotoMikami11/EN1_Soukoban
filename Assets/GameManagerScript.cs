using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class NewBehaviourScript : MonoBehaviour
{
    //�N���X�̒����\�b�h�̊O�ɏ���

    //�P�̒l���i�[����Ă���C���f�b�N�X���擾���鏈���̃��\�b�h���B
    Vector2Int GetPlayerIndex()
    {

        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                //null�`�F�b�N����null�Ȃ烋�[�v�A�������tag�`�F�b�N����
                if (field[y, x] == null) { continue; }
                if (field[y, x].tag == "Player")//tag��Player�Ȃ�
                {
                    return new Vector2Int(x, y);//�񎟌��z�񂻂ꂼ��̃C���f�b�N�X��Vector2Int�^�ŕԂ�
                }

            }
        }
        return new Vector2Int(-1, -1);
    }



    //�ړ��̉s�𔻒f���Ĉړ������鏈�������\�b�h���B 

    /// <summary>
    /// �ړ��̉s�𔻒f���Ĉړ������郁�\�b�h
    /// </summary>
    /// <param name="number">�ړ����������l</param>
    /// <param name="moveFrom">�ړ����̈ʒu</param>
    /// <param name="moveTo">�ړ���̈ʒu</param>
    /// <returns></returns>
    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {
        //�����Ȃ������i�z��͈̔͊O�j
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; } //y���W
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }//x���W

        //�ړ���Ɂi���j������Ƃ��̏���
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            //�ǂ̕����Ɉړ����邩�Y�o
            Vector2Int velocity = moveTo - moveFrom;

            //  �v���C���[�̈ړ��悩��A�X�ɐ��2�i���j���ړ�������
            //  ���̈ړ������AMoveNumber���\�b�h����MoveNumber���\�b�h���ĂсA
            //  �������ċA���Ă���A�ړ��s��bool�ŕۑ�
            bool success = MoveNumber(tag, moveTo, moveTo + velocity);
            if (!success) { return false; }
        }

        //�z��̒l�̈ړ����s���O��moveFrom�ɂ���Q�[���I�u�W�F�N�g�̍��W��ύX����
        //�Q�[���I�u�W�F�N�g�̈ړ�
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        //particle�𐶐�
        for (int i = 0; i < Random.Range(3, 10); i++)
        {
            Instantiate(
     particlePrefab,
     new Vector3(moveFrom.x, map.GetLength(0) - moveFrom.y, 0),
     Quaternion.identity);
        }
        //�v���C���[�E���ς�炸�̈ړ�����
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;

    }

    bool IsCleard()
    {
        //Vector2Int�^�̉ϒ��z��̍쐬
        List<Vector2Int> goals = new List<Vector2Int>();
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                //�i�[�ꏊ���ۂ��𔻒f
                if (map[y, x] == 3)
                {
                    //�i�[�ꏊ�̃C���f�b�N�X���T���Ă���
                    goals.Add(new Vector2Int(x, y));
                }
            }
        }

        ///�S�Ă�3�̏ꏊ�ɔ������݂���Ƃ����ǂ����𔻒f����
        //�v�f����goals.Count�Ŏ擾����
        for (int i = 0; i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];
            ///f�̏ꏊ�ɔ����Ȃ���
            if (f == null || f.tag != "Box")
            {
                //�������B���Ƃ���
                return false;
            }
        }
        //�������B���łȂ���΃N���A
        return true;
    }


    //�z��̐錾
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    public GameObject goalPrefab;
    public GameObject particlePrefab;

    //
    public GameObject clearText;

    //�񎟌��z��̐錾
    int[,] map;     //���x���f�U�C���p�̔z��
    //�Q�[���Ǘ��p�̔z��
    GameObject[,] field;



    // Start is called before the first frame update
    void Start()
    {    //�C�j�V�����C�Y�i��񂾂��j

        Screen.SetResolution(1920, 1080, false);

        ///�z��̎��̂̍쐬�Ə�����
        map = new int[,] {
            {0,0,0,0,0 },
            {0,3,1,3,0 },
            {0,0,2,0,0 },
            {0,2,3,2,0 },
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
                    playerPrefab,
                    new Vector3(x, map.GetLength(0) - y, 0),
                    Quaternion.identity);
                }

                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(
                    boxPrefab,
                    new Vector3(x, map.GetLength(0) - y, 0),
                    Quaternion.identity);
                }
                if (map[y, x] == 3)
                {
                    Instantiate(
                    goalPrefab,
                    new Vector3(x, map.GetLength(0) - y, 0.01f),
                    Quaternion.identity);
                }

            }
        }
    }


    // Update is called once per frame
    void Update()
    {        //���t���[��

        /*-----------------------------------------------*/
        //
        //                �E�����Ɉړ�������
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //1.�P���i�[����Ă���C���f�b�N�X��T��
            Vector2Int playerIndex = GetPlayerIndex();



            MoveNumber("Player", playerIndex,
                (playerIndex + new Vector2Int(1, 0)));
            //�N���A�����𖞂����Ă�����
            if (IsCleard() == true)
            {
                //�Q�[���N���A�̃e�L�X�g��\������
                clearText.SetActive(true);
            }

        }

        /*-----------------------------------------------*/
        //
        //                �������Ɉړ�������
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //1.�P���i�[����Ă���C���f�b�N�X��T��
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Player", playerIndex, (playerIndex + new Vector2Int(-1, 0)));
            //�N���A�����𖞂����Ă�����
            if (IsCleard() == true)
            {
                //�Q�[���N���A�̃e�L�X�g��\������
                clearText.SetActive(true);
            }

        }
        /*-----------------------------------------------*/
        //
        //                ������Ɉړ�������
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //1.�P���i�[����Ă���C���f�b�N�X��T��
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Player", playerIndex, (playerIndex + new Vector2Int(0, -1)));
            //�N���A�����𖞂����Ă�����
            if (IsCleard() == true)
            {
                //�Q�[���N���A�̃e�L�X�g��\������
                clearText.SetActive(true);
            }

        }
        /*-----------------------------------------------*/
        //
        //                �������Ɉړ�������
        //
        /*-----------------------------------------------*/

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //1.�P���i�[����Ă���C���f�b�N�X��T��
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Player", playerIndex, (playerIndex + new Vector2Int(0, 1)));
            //�N���A�����𖞂����Ă�����
            if (IsCleard() == true)
            {
                //�Q�[���N���A�̃e�L�X�g��\������
                clearText.SetActive(true);
            }

        }





    }
}
