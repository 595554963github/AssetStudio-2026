using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Assetstudio;
public static class OodleHelper
{
    [DllImport(@"oo2core_9_win64.dll")]
    static extern int OodleLZ_Decompress(ref byte compressedBuffer, int compressedBufferSize, ref byte decompressedBuffer, int decompressedBufferSize, int fuzzSafe, int checkCRC, int verbosity, IntPtr rawBuffer, int rawBufferSize, IntPtr fpCallback, IntPtr callbackUserData, IntPtr decoderMemory, IntPtr decoderMemorySize, int threadPhase);

    public static int Decompress(Span<byte> compressed, Span<byte> decompressed)
    {
        int numWrite = -1;
        try
        {
            numWrite = OodleLZ_Decompress(ref compressed[0], compressed.Length, ref decompressed[0], decompressed.Length, 1, 0, 0, 0, 0, 0, 0, 0, 0, 3);
        }
        catch (Exception)
        {
            throw new InvalidDataException($"Oodle解压缩数据长度不匹配:预期{decompressed.Length}字节,实际仅写入{numWrite} 字节");
        }

        return numWrite;
    }
}