using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocosSharp
{
    public class CCMenuLoader : CCLayerLoader
    {
        public override CCNode CreateCCNode()
        {
            return new CCMenu();
        }
    }
}