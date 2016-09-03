using System;

namespace CMSIS.Pack
{
    /// <summary>Value type used to indicate the static state a file download</summary>
    public struct FileDownloadProgress 
    {
        public FileDownloadProgress( Uri source, TimeSpan elapsedTime, long sizeSoFar, long totalSize)
        {
            SourceUrl = source;
            ElapsedTime = elapsedTime;
            SizeSoFar = sizeSoFar;
            TotalSize = totalSize;
        }

        public double PercentComplete => 100.0 * SizeSoFar / TotalSize;

        public bool IsCompleted => SizeSoFar == -1 || TotalSize == -1;

        public Uri SourceUrl { get; }

        public TimeSpan ElapsedTime { get; }

        public long SizeSoFar { get; }

        public long TotalSize { get; }
    }
}