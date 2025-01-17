﻿using System;
using Box2D.Common;
using Box2D.Dynamics;
using CocosSharp;

namespace Game
{
    internal class CCPhysicsSprite : CCSprite
    {
        readonly float ptmRatio;

        public CCPhysicsSprite (CCTexture2D f, CCRect r, float ptmRatio) : base (f, r)
        {
            this.ptmRatio = ptmRatio;
        }

        public b2Body PhysicsBody { get; set; }

        public void UpdateBallTransform()
        {
            if (PhysicsBody != null)
            {
                b2Vec2 pos = PhysicsBody.Position;

                float x = pos.x * ptmRatio;
                float y = pos.y * ptmRatio;

                if (IgnoreAnchorPointForPosition) 
                {
                    x += AnchorPointInPoints.X;
                    y += AnchorPointInPoints.Y;
                }

                // Make matrix
                float radians = PhysicsBody.Angle;
                var c = (float)Math.Cos (radians);
                var s = (float)Math.Sin (radians);

                if (!AnchorPointInPoints.Equals (CCPoint.Zero)) 
                {
                    x += c * -AnchorPointInPoints.X + -s * -AnchorPointInPoints.Y;
                    y += s * -AnchorPointInPoints.X + c * -AnchorPointInPoints.Y;
                }

                Position = new CCPoint(x, y);
            }
        }
    }
}