using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudEyesFileTranferServices
{
    public enum Headers : byte
    {
        Queue,
        Start,
        Stop,
        Pause,
        Chunk
    }
}
