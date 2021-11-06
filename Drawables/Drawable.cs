using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public abstract class Drawable
    {
        public HashSet<Drawable> AdjacentDrawables { get; private set; }

        public Drawable(Drawable d) => this.AdjacentDrawables = new HashSet<Drawable> { d };
        public Drawable(HashSet<Drawable> drawables) => this.AdjacentDrawables = drawables;
        
        public abstract void Print(Action<Action> how);
        public abstract void Move(Action<Drawable> how);

        public void MoveToPreview() => this.Move((Drawable d) => Designer.Instance.MoveToPreview(d));
        public void MoveToMain()    => this.Move((Drawable d) => Designer.Instance.MoveToMain(d));

        public abstract void Delete();
        public abstract void Register();
        public abstract void Deregister();
        public abstract void AddToMain();

        public abstract void PreMove();
        public abstract void PostMove();
        public abstract void Move(Point p);
    }
}
