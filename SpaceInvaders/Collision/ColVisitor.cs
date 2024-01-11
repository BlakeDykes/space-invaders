using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ColVisitor : DLink
    {
        public virtual void Visit(AlienGrid aG)
        {
            //Debug.WriteLine("Collision with AlienGrid not Implemented");
        }
        public virtual void Visit(AlienColumn aC)
        {
            //Debug.WriteLine("Collision with AlienColumn not Implemented");
        }
        public virtual void Visit(AlienCrab a)
        {
            //Debug.WriteLine("Collision with AlienCrab not Implemented");
        }
        public virtual void Visit(AlienSquid a)
        {
            //Debug.WriteLine("Collision with AlienSquid not Implemented");
        }
        public virtual void Visit(AlienOcto a)
        {
            //Debug.WriteLine("Collision with AlienOcto not Implemented");
        }
        public virtual void Visit(MissleGroup m)
        {
            //Debug.WriteLine("Collision with MissleGroup not Implemented");
        }
        public virtual void Visit(Missle m)
        {
            //Debug.WriteLine("Collision with Missle not Implemented");
        }

        public virtual void Visit(ShipGroup s)
        {
            //Debug.WriteLine("Collision with ShipGroup not Implemented");
        }

        public virtual void Visit(Ship s)
        {
           //Debug.WriteLine("Collision with Ship not Implemented");
        }

        public virtual void Visit(GameObjectNull n)
        {
            //Debug.WriteLine("Collision with Null Object not implemented");
        }

        public virtual void Visit(WallGroup w)
        {
            //Debug.WriteLine("Collision with WallGroup not implemented");
        }

        public virtual void Visit(WallTop w)
        {
            //Debug.WriteLine("Collision with WallTop not implemented");
        }

        public virtual void Visit(WallLeft w)
        {
            //Debug.WriteLine("Collision with WallLeft not implemented");
        }

        public virtual void Visit(WallRight w)
        {
            //Debug.WriteLine("Collision with WallRight not implemented");
        }

        public virtual void Visit(WallBottom w)
        {
            //Debug.WriteLine("Collision with WallBottom not implemented");
        }

        public virtual void Visit(ShieldGroup s)
        {
            //Debug.WriteLine("Collision with ShieldGroup not implemented");
        }
        public virtual void Visit(ShieldGrid s)
        {
            //Debug.WriteLine("Collision with ShieldGrid not implemented");
        }

        public virtual void Visit(ShieldColumn s)
        {
            //Debug.WriteLine("Collision with ShieldColumn not implemented");
        }
        public virtual void Visit(ShieldBrick s)
        {
           //Debug.WriteLine("Collision with ShieldBrick not implemented");
        }

        public virtual void Visit(BombGroup b)
        {
            //Debug.WriteLine("Collision with BombGroup not implemented");
        }

        public virtual void Visit(BombBase b)
        {
            //Debug.WriteLine("Collision with BombBase not implemented");
        }

        public virtual void Visit(UFOGroup u)
        {
            //Debug.WriteLine("Collision with UFOGroup not implemented");
        }

        public virtual void Visit(UFO u)
        {
            //Debug.WriteLine("Collision with UFO not implemented");
        }

        public abstract void Accept(ColVisitor other);
    }
}
