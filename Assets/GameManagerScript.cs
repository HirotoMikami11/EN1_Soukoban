using UnityEngine;

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
        if (field[moveTo.y,moveTo.x]!=null && field[moveTo.y,moveTo.x].tag == "Box")
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
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x,field.GetLength(0)- moveTo.y,0);

        //�v���C���[�E���ς�炸�̈ړ�����
        field[moveTo.y, moveTo.x] =field[moveFrom.y, moveFrom.x];
        field[moveFrom.y,moveFrom.x] = null;
        return true;

    }




    //�z��̐錾
    public GameObject PlayerPrefab;
    public GameObject BoxPrefab;

    //�񎟌��z��̐錾
    int[,] map;     //���x���f�U�C���p�̔z��
    //�Q�[���Ǘ��p�̔z��
    GameObject[,] field;



    // Start is called before the first frame update
    void Start()
    {    //�C�j�V�����C�Y�i��񂾂��j

        ///�z��̎��̂̍쐬�Ə�����
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

            MoveNumber("Box", playerIndex, (playerIndex + new Vector2Int(1, 0)));


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

            MoveNumber("Box", playerIndex, (playerIndex+ new Vector2Int(-1, 0)));


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

            MoveNumber("Box", playerIndex, (playerIndex + new Vector2Int(0, -1)));


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

            MoveNumber("Box", playerIndex, (playerIndex + new Vector2Int(0, 1)));


        }



    }
}
