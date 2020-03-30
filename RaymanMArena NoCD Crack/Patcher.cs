using System;
using System.IO;
using System.Linq;

namespace RaymanMArena_NoCD_Crack
{
    class Patcher : IPatcher
    {
        private readonly string FilePath;
        private byte[] pattern;

        public Patcher(string FilePath, long offset, byte[] BytePattern, byte[] ToPatchPattern)
        {
            this.FilePath = FilePath;
            OriginalBytes = BytePattern;
            ToPatchBytes = ToPatchPattern;
            Offset = offset;
            GetPatchable();
        }


        public byte[] OriginalBytes
        {
            get { return pattern; }
            set
            {
                pattern = value;
                GetPatchable(pattern);
            }
        }
        public byte[] ToPatchBytes { get; set; }
        public long Offset { get; set; }
        public bool IsPatchable { get; private set; }


        public void GetPatchable() { GetPatchable(OriginalBytes); }
        public void GetPatchable(byte[] Pattern)
        {
            byte[] buffer = new byte[Pattern.Length];
            IsPatchable = false;
            using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                fileStream.Position = Offset;
                fileStream.Read(buffer, 0, buffer.Length);
                if (buffer.SequenceEqual(Pattern))
                    IsPatchable = true;
            }
        }

        public bool IsAlreadyPatched()
        {
            GetPatchable(ToPatchBytes);
            return IsPatchable;
        }

        public void PatchFile(bool? MakeBackup)
        {
            if (!IsPatchable)
            {
                throw new NotSupportedException();
            }

            if (MakeBackup.Value)
            {
                File.Copy(FilePath, Path.Combine(Path.GetDirectoryName(FilePath), Path.GetFileNameWithoutExtension(FilePath) + ".bak"), true);
            }

            using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                fileStream.Position = Offset;
                fileStream.Write(ToPatchBytes, 0, ToPatchBytes.Length);
            }
        }
    }
}
