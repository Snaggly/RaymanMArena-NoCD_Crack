namespace RaymanMArena_NoCD_Crack
{
    interface IPatcher
    {
        byte[] OriginalBytes { get; set; }

        byte[] ToPatchBytes { get; set; }

        long Offset { get; set; }

        bool IsPatchable { get; }

        void GetPatchable();

        bool IsAlreadyPatched();

        void PatchFile(bool? MakeBackup);
    }
}
