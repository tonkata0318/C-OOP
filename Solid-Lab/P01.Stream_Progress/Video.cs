using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Stream_Progress
{
    public class Video : IStream
    {
        public int lentgh { get; private set; }
        public int bytesent { get; private set; }

        public Video(int lentgh, int bytesSent)
        {
            this.lentgh = lentgh;
            this.bytesent = bytesSent;
        }

        public int Lentgh=>this.lentgh;

        public int ByteSent=>this.bytesent;
    }
}
