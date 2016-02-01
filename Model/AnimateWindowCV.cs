using System;

namespace Model
{
    public static class AnimateWindowCV
    {
        public static readonly Int32 AW_ACTIVATE = 0x00020000;
        public static readonly Int32 AW_BLEND = 0x00080000;
        public static readonly Int32 AW_CENTER = 0x00000010;
        public static readonly Int32 AW_HIDE = 0x00010000;
        public static readonly Int32 AW_HOR_POSITIVE = 0x00000001;
        public static readonly Int32 AW_HOR_NEGATIVE = 0x00000002;
        public static readonly Int32 AW_SLIDE = 0x00040000;
        public static readonly Int32 AW_VER_POSITIVE = 0x00000004;
        public static readonly Int32 AW_VER_NEGATIVE = 0x00000008;

        //鼠标位置标记
        public static readonly int WM_NCHITTEST = 0x0084;
        public static readonly int HT_LEFT = 10;
        public static readonly int HT_RIGHT = 11;
        public static readonly int HT_TOP = 12;
        public static readonly int HT_TOPLEFT = 13;
        public static readonly int HT_TOPRIGHT = 14;
        public static readonly int HT_BOTTOM = 15;
        public static readonly int HT_BOTTOMLEFT = 16;
        public static readonly int HT_BOTTOMRIGHT = 17;
        public static readonly int HT_CAPTION = 2;
    }
}
