namespace RaymanMArena_NoCD_Crack
{
    /*Did I need even an interface for that?
    I don't know a design patter that tells
    me having an Interface here would make sense*/

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
