﻿namespace RaymanMArena_NoCD_Crack
{
    class PatchNode
    {
        public static long OffsetM = 0x2630;

        public static byte[] OriginalM =
        {
            0x00, 0x00, 0x83, 0xC4, 0x0C, 0x6A, 0xFF, 0xFF, 0x15, 0x68, 0x32, 0x58, 0x00, 0xE8, 0x3E, 0xBE,
            0x02, 0x00, 0xE8, 0x2C, 0xF1, 0xFF, 0xFF, 0x85, 0xC0, 0x75, 0x0F, 0x5F, 0x5E, 0x83, 0xC8, 0xFF
        };

        public static byte[] PatchedM =
        {
            0x00, 0x00, 0x83, 0xC4, 0x0C, 0x6A, 0xFF, 0xFF, 0x15, 0x68, 0x32, 0x58, 0x00, 0xE9, 0x00, 0x00,
            0x00, 0x00, 0xE8, 0x2C, 0xF1, 0xFF, 0xFF, 0x85, 0xC0, 0x75, 0x0F, 0x5F, 0x5E, 0x83, 0xC8, 0xFF
        };

        public static long OffsetA = 0x2fb10;
        public static byte[] OriginalA =
        {
            0x00, 0x00, 0x68, 0x94, 0xBE, 0x5D, 0x00, 0x51, 0xE8, 0x3B, 0x7A, 0x09, 0x00, 0x83, 0xC4, 0x08,
            0x85, 0xC0, 0x0F, 0x84, 0x49, 0x01, 0x00, 0x00, 0x43, 0x83, 0xFB, 0x20, 0x7C, 0x96, 0x8D, 0x94
        };

        public static byte[] PatchedA =
        {
            0x00, 0x00, 0x68, 0x94, 0xBE, 0x5D, 0x00, 0x51, 0xE8, 0x3B, 0x7A, 0x09, 0x00, 0x83, 0xC4, 0x08,
            0x85, 0xC0, 0xE9, 0x4A, 0x01, 0x00, 0x00, 0x00, 0x43, 0x83, 0xFB, 0x20, 0x7C, 0x96, 0x8D, 0x94
        };
    }
}