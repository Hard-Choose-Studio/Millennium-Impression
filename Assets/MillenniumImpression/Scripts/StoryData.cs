using System.Collections.Generic;

namespace MillenniumImpression
{
    public static class StoryData
    {
        public static readonly Dictionary<Scenes, string[]> stories = new()
        {
            {
                Scenes.AquaOilScene,
                new string[]
                {
                    "�U�ȭn�}�l��ѤF�A",
                    "�@�Q��n���墨�ǱЬ�ѡA",
                    "�N�O�ڴ����_�l�A",
                    "�u�n���X�ڪ������n�٦�X�X",
                    "��o��C",
                    "�@���}��o��A",
                    "���@�ѲD�n���������������R���F��өж��A",
                    "�S�p�@�ѲM�s���O�q�A",
                    "���ڥ��_�믫�A",
                    "�h�ԳӨ����}�ߪ����ѡC"
                }
            },
            {
                Scenes.TapeScene,
                new string[]
                {
                    "���F�����U�Ӫ��ǲ߮ɥ���[�r�֡A",
                    "�ڨM�w��@�ǭ��֨�ť�C",
                    "����������v�T�A",
                    "���F�̪�y�檺���Ǻq���H�~�A",
                    "�ڤ]�ܳ��w����������d�a�A",
                    "ı�o����_�K����CD�A",
                    "�˱a�B½�����M�ݩ�d�a���ާ@�A",
                    "�ϥ����ۻP�����P�������C",
                    "���ޤw���A�y��A",
                    "�d�a�W�����֤��ϧڨH���䤤�A",
                    "���F�@�����F�����R�M�w���C"
                }
            }
        };

        public static Scenes nextScene;
    }
}