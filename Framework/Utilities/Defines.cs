using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrayHoodT
{
    public static class Defines
    {
        /* �� ��ȯ ���� ȯ�� ���� ����. */
        public const float FADE_ACTIVE_VALUE = 1f;
        public const float FADE_DEACTIVE_VALUE = 0f;
        public const float FADE_DURATION_TIME = 0.8f;

        /* ����� ���� ȯ�� ���� ����. */
        public const float AUDIO_MAX_VOLUME = 100f;
        public const float AUDIO_MIN_VOLUME = 0f;
        public const float AUDIO_MUTE_VOLUME = -80f; 
        public const float AUDIOSOURCE_MAX_VOLUME = 1f;
        public const float AUDIOSOURCE_MIN_VOLUME = 0f;
        public const float BGM_FADE_DURATION = 0.5f;

        /* Size ���� ����. */
        public const long ONE_GB = 1000000000;
        public const long ONE_MB = 1000000;
        public const long ONE_KB = 1000;

        /* ���� ���� ��� ����. */
        public static readonly string[] UNIT_KR = new string[] { "", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "���ϻ�", "�ƽ±�", "�Ұ�����", "�������" };
    }
}

