using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSIS.Pack
{
    public class RepositoryUpdateEventArgs
        : EventArgs
    {
        public RepositoryUpdateEventArgs( )
            : this( RepositoryState.Idle, null )
        {
        }

        public RepositoryUpdateEventArgs( RepositoryState state, IPackIndexEntry pack )
        {
            if( pack == null && ( state != RepositoryState.Idle ) && (state != RepositoryState.DownloadingIndex ) )
                throw new ArgumentNullException( nameof( pack ), "pack cannot be null for states other than idle" );

            if( ( ( state == RepositoryState.Idle) || ( state == RepositoryState.DownloadingIndex ) ) && pack != null )
                throw new ArgumentException( "pack must be null for this state", nameof( pack ) );

            State = state;
            Pack = pack;
        }

        public RepositoryState State { get; private set; }
        public IPackIndexEntry Pack { get; private set; }
    }
}