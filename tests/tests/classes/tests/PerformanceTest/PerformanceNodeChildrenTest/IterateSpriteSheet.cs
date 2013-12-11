using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CocosSharp;
using Random = CocosSharp.CCRandom;

namespace tests
{
    public class IterateSpriteSheet : NodeChildrenMainScene
    {

        public override void updateQuantityOfNodes()
        {
            CCSize s = CCDirector.SharedDirector.WinSize;

            // increase nodes
            if (currentQuantityOfNodes < quantityOfNodes)
            {
                StartTimer();
                for (int i = 0; i < (quantityOfNodes - currentQuantityOfNodes); i++)
                {
                    CCSprite sprite = new CCSprite(batchNode.Texture, new CCRect(0, 0, 32, 32));
                    batchNode.AddChild(sprite);
                    sprite.Position = new CCPoint(CCRandom.Next() * s.Width, CCRandom.Next() * s.Height);
                }
            }

            // decrease nodes
            else if (currentQuantityOfNodes > quantityOfNodes)
            {
                StartTimer();
                for (int i = 0; i < (currentQuantityOfNodes - quantityOfNodes); i++)
                {
                    int index = currentQuantityOfNodes - i - 1;
                    batchNode.RemoveChildAtIndex(index, true);
                }
            }

            currentQuantityOfNodes = quantityOfNodes;
        }

        public override void initWithQuantityOfNodes(int nNodes)
        {
            batchNode = new CCSpriteBatchNode("Images/spritesheet1");
            AddChild(batchNode);
            
            base.initWithQuantityOfNodes(nNodes);

            ScheduleUpdate();
        }

        public override void Update(float dt)
        {
        }

        public virtual string profilerName()
        {
            return "none";
        }


        protected CCSpriteBatchNode batchNode;

        //#if CC_ENABLE_PROFILERS
        //    CCProfilingTimer    *_profilingTimer;
        //#endif
    }
}
