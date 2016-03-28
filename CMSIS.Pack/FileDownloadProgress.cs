using System;

namespace CMSIS.Pack
{
    /// <summary>Value type used to indicate the static state a file download</summary>
    public struct FileDownloadProgress 
    {
        public FileDownloadProgress( Uri source, TimeSpan elapsedTime, long sizeSoFar, long totalSize)
        {
            SourceUrl_ = source;
            ElapsedTime_ = elapsedTime;
            SizeSoFar_ = sizeSoFar;
            TotalSize_ = totalSize;
        }

        public double PercentComplete
        {
            get { return 100.0 * (double)SizeSoFar/(double)TotalSize; }
        }

        public bool IsCompleted { get { return SizeSoFar_ == -1 || TotalSize_ == -1; } }
        public Uri SourceUrl { get { return SourceUrl_; } }
        private readonly Uri SourceUrl_;

        public TimeSpan ElapsedTime { get { return ElapsedTime_; } }
        private readonly TimeSpan ElapsedTime_;

        public long SizeSoFar { get { return SizeSoFar_;  } }
        private readonly long SizeSoFar_;

        public long TotalSize { get { return TotalSize_;  } }
        private readonly long TotalSize_;
    }
}