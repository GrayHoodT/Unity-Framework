using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrayHoodT
{
    public static class Configs
    {
        /* 씬 전환 관련 환경 변수 모음. */
        public const float FADE_ACTIVE_VALUE = 1f;
        public const float FADE_DEACTIVE_VALUE = 0f;
        public const float FADE_DURATION_TIME = 0.8f;

        /* 오디오 관련 환경 변수 모음. */
        public const float AUDIO_MAX_VOLUME = 100f;
        public const float AUDIO_MIN_VOLUME = 0f;
        public const float AUDIO_MUTE_VOLUME = -80f; 
        public const float AUDIOSOURCE_MAX_VOLUME = 1f;
        public const float AUDIOSOURCE_MIN_VOLUME = 0f;
        public const float BGM_FADE_DURATION = 0.5f;

        /* Size 관련 모음. */
        public const long ONE_GB = 1000000000;
        public const long ONE_MB = 1000000;
        public const long ONE_KB = 1000;

        /* 숫자 단위 축약 모음. */
        public static readonly string[] UNIT_KR = new string[] { "", "만", "억", "조", "경", "해", "자", "양", "구", "간", "정", "재", "극", "항하사", "아승기", "불가사의", "무량대수" };
    }
}

